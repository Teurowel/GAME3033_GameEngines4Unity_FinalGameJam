using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//every interactable object will inherit this class

public interface IInteractable
{
    void OnInteracted(Player _interacter);
    void DisableEffect();
}
