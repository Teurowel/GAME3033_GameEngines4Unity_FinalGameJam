using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FtoInteract : MonoBehaviour
{
    [SerializeField] float yOffset = 0.0f;
    [SerializeField] float zOffset = 0.0f;

    //References
    Player player;
    Transform cam; //Main camera

    // Start is called before the first frame update
    void Start()
    {
        //Find camera
        cam = Camera.main.transform;

        //Find player
        player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.OnDetectInteractable.AddListener(OnDetectInteractableCallback);
            player.OnUnDetectInteractable.AddListener(OnUnDetectInteractableCallback);
        }

        gameObject.SetActive(false);
    }
    void LateUpdate()
    {
        if (player != null)
        {
            //Set UI's position to player's position
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, player.transform.position.z + zOffset);

            //Align UI that makes UI always face to camera
            transform.forward = cam.forward;
        }
    }

    void OnDetectInteractableCallback()
    {
        gameObject.SetActive(true);
    }

    void OnUnDetectInteractableCallback()
    {
        gameObject.SetActive(false);
    }
}
