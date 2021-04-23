using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveResetPosition : MonoBehaviour
{
    [SerializeField] Transform resetPosition = null;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(resetPosition != null)
            {
                other.GetComponent<Player>().resetPosition = resetPosition.position;
            }
        }
    }
}
