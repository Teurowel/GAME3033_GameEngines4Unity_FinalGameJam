using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlayerBig : MonoBehaviour, IInteractable
{
    [SerializeField] float effectTime = 5;
    
    GameObject interacter = null;

    public void OnInteracted(GameObject _interacter)
    {
        Debug.Log("OnInteracted");
        interacter = _interacter;
        interacter.transform.localScale = new Vector3(2, 2, 2);

        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //call disable effect after some time
        Invoke(nameof(DisableEffect), effectTime);
    }

    public void DisableEffect()
    {
        interacter.transform.localScale = new Vector3(1, 1, 1);


        Destroy(gameObject);
    }
}
