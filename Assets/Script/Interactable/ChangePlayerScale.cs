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

    float originPlayerMoveForce = 0.0f;
    float originPlayerMass = 0.0f;
    Vector3 originPlayerScale = Vector3.zero;

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

        //Disable renderer
        foreach (Renderer renderer in rendererToDiable)
        {
            renderer.enabled = false;
        }

        //Disable collider
        _collider.enabled = false;

        //call disable effect after some time
        Invoke(nameof(DisableEffect), effectTime);
    }

    public void DisableEffect()
    {
        interacter.transform.localScale = originPlayerScale;
        interacter.GetComponent<Rigidbody>().mass = originPlayerMass;
        interacter.GetComponent<PlayerMovement>().moveForce = originPlayerMoveForce;

        foreach (Renderer renderer in rendererToDiable)
        {
            renderer.enabled = true;
        }

        _collider.enabled = true;
    }
}
