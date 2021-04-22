using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 10.0f;
    public float maxSpeed = 5.0f;
    Vector3 moveDirection = Vector3.zero;

    //Comp
    Animator animator;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        //If movedirection's magnitude is bigger than 0
        if (moveDirection.magnitude > 0)
        {
            //normalize it first
            //moveDirection.Normalize();
            //moveDirection *= moveSpeed; //multiply it by speed
            //transform.Translate(moveDirection);

            //Move based on keyboard
            //Vector3 origin = rb.velocity;
            //rb.velocity = moveDirection.normalized * moveSpeed;

            //Move based on mouse
            Vector3 origin = rb.velocity;
            Vector3 localMoveDirection = Quaternion.Euler(transform.rotation.eulerAngles) * moveDirection.normalized;
            localMoveDirection.Normalize();
            localMoveDirection.y = origin.y;
            //rb.velocity = localMoveDirection * moveSpeed;
            rb.AddForce(localMoveDirection * moveForce);
            if(rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;

        }
    }

    void UpdateAnimator()
    {
        //make move direction(world) to relatve(player's rotation)
        Vector3 localMoveDirection = Quaternion.Euler(transform.rotation.eulerAngles) * moveDirection.normalized;
        localMoveDirection.Normalize();

        //Calculate velocityZ and X based on move direction and forward direction, right direction
        float velocityZ = Vector3.Dot(localMoveDirection, transform.forward);
        float velocityX = Vector3.Dot(localMoveDirection, transform.right);

        animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
    }

    public void OnMovement(InputValue value)
    {
        //Get move direction
        Vector2 dir = value.Get<Vector2>();

        //Save move direction
        moveDirection.x = dir.x;
        moveDirection.z = dir.y;
    }
}
