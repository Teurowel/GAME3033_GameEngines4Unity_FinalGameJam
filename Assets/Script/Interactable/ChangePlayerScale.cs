using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerScale : MonoBehaviour, IInteractable
{
    [SerializeField] float effectTime = 5;
    [SerializeField] List<Renderer> rendererToDiable;

    [SerializeField] float playerMass = 30;
    [SerializeField] float playerMoveForce = 30;
    [SerializeField] Vector3 playerScale = Vector3.zero;
    [SerializeField] float playerMaxSpeed = 0;

    float originPlayerMoveForce = 0.0f;
    float originPlayerMass = 0.0f;
    Vector3 originPlayerScale = Vector3.zero;
    float originPlayerMaxSpeed = 0.0f;

    Player interacter = null;
    Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    public void OnInteracted(Player _interacter)
    {
        Debug.Log("OnInteracted");
        interacter = _interacter;
        
        //Set scale
        originPlayerScale = interacter.transform.localScale;
        interacter.transform.localScale = playerScale;

        //Set mass
        originPlayerMass = interacter.GetComponent<Rigidbody>().mass;
        interacter.GetComponent<Rigidbody>().mass = playerMass;

        //Set move force
        originPlayerMoveForce = interacter.GetComponent<PlayerMovement>().moveForce;
        interacter.GetComponent<PlayerMovement>().moveForce = playerMoveForce;

        //Set max speed
        originPlayerMaxSpeed = interacter.GetComponent<PlayerMovement>().maxSpeed;
        interacter.GetComponent<PlayerMovement>().maxSpeed = playerMaxSpeed;

        //Disable renderer
        foreach (Renderer renderer in rendererToDiable)
        {
            renderer.enabled = false;
        }

        //Disable collider
        _collider.enabled = false;

        //Set player on effect
        interacter.SetIsOnEffect(true);

        //call disable effect after some time
        Invoke(nameof(DisableEffect), effectTime);
    }

    public void DisableEffect()
    {
        interacter.transform.localScale = originPlayerScale;
        interacter.GetComponent<Rigidbody>().mass = originPlayerMass;
        interacter.GetComponent<PlayerMovement>().moveForce = originPlayerMoveForce;
        interacter.GetComponent<PlayerMovement>().maxSpeed = originPlayerMaxSpeed;

        interacter.SetIsOnEffect(false);

        foreach (Renderer renderer in rendererToDiable)
        {
            renderer.enabled = true;
        }

        _collider.enabled = true;
    }
}
