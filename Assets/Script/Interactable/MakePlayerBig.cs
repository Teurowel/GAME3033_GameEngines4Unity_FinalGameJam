using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlayerBig : MonoBehaviour, IInteractable
{
    [SerializeField] float effectTime = 5;
    [SerializeField] List<Renderer> rendererToDiable;

    [SerializeField] float playerMass = 30;
    [SerializeField] float playerMoveForce = 30;

    float originPlayerMoveForce = 0.0f;
    float originPlayerMass = 0.0f;

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
        //interacter.SetScale(new Vector3(2, 2, 2));
        interacter.transform.localScale = new Vector3(2, 2, 2);

        originPlayerMass = interacter.GetComponent<Rigidbody>().mass;
        interacter.GetComponent<Rigidbody>().mass = playerMass;
        originPlayerMoveForce = interacter.GetComponent<PlayerMovement>().moveForce;
        interacter.GetComponent<PlayerMovement>().moveForce = playerMoveForce;

        foreach (Renderer renderer in rendererToDiable)
        {
            renderer.enabled = false;
        }

        _collider.enabled = false;

        //call disable effect after some time
        Invoke(nameof(DisableEffect), effectTime);
    }

    public void DisableEffect()
    {
        //interacter.SetScale(new Vector3(1, 1, 1));
        interacter.transform.localScale = new Vector3(1, 1, 1);
        interacter.GetComponent<Rigidbody>().mass = originPlayerMass;
        interacter.GetComponent<PlayerMovement>().moveForce = originPlayerMoveForce;

        foreach (Renderer renderer in rendererToDiable)
        {
            renderer.enabled = true;
        }

        _collider.enabled = true;
    }
}
