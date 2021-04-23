using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomActivation : MonoBehaviour
{
    [SerializeField] Transform roomToActivate;
    [SerializeField] Transform roomToDeActivate;

    private void OnTriggerEnter(Collider other)
    {
        if(roomToActivate != null)
            roomToActivate.gameObject.SetActive(true);

        if(roomToDeActivate != null)
            roomToDeActivate.gameObject.SetActive(false);
    }
}
