using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerRotation : MonoBehaviour
{
    //[SerializeField] float rotationSensitivity = 10.0f;
    //[SerializeField] LayerMask groundLayer;
    [SerializeField] Texture2D cursorTexture;

    //float rotationDir = 0.0f; //-1 rotate to left, +1 rotate to right

    Camera mainCam;
    Player player;

    Vector3 mousePos = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        //Vector2 cursorOffset = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        //Cursor.SetCursor(cursorTexture, cursorOffset, CursorMode.Auto);
        //hide cursor and lock
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        mainCam = Camera.main;

        player = GetComponent<Player>();
    }

    // Update is called once per frame
    //void Update()
    //{



    //    // transform.Rotate(Vector3.up, rotationDir * rotationSensitivity * Time.deltaTime);
    //}

    //public void OnMouseMove(InputValue value)
    //{
    //    //Get move direction
    //    //Vector2 delta = value.Get<Vector2>();

    //    //Only use left and right movement of mouse
    //    //rotationDir = delta.x;
    //}

    public void OnMousePosition(InputValue value)
    {
        if(player.gameMenu.isPaused == true)
        {
            return;
        }

        Vector2 mouse = value.Get<Vector2>();
        mousePos.x = mouse.x;
        mousePos.y = mouse.y;

        Ray ray = mainCam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            Vector3 hitPosition = hit.point;
            hitPosition.y = 0.0f;

            transform.forward = (hitPosition - transform.position).normalized;
        }
    }
}
