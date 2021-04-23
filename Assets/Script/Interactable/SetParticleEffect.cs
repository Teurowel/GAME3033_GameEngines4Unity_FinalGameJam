using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SetParticleEffect : MonoBehaviour, IInteractable
{
    [SerializeField] float effectTime = 5;
    [SerializeField] List<Renderer> rendererToDiable;

    Player interacter = null;
    Collider _collider;
    VisualEffect VFX;
    SkinnedMeshToMesh skinnedMeshToMesh;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
        VFX = GetComponentInChildren<VisualEffect>();
        skinnedMeshToMesh = GetComponent<SkinnedMeshToMesh>();
    }


    public void OnInteracted(Player _interacter)
    {
        Debug.Log("OnInteracted");
        interacter = _interacter;

        //enable skiined mesh to mesh
        interacter.skinnedMeshToMesh.enabled = true;

        //Enable VFX and set color
        interacter.VFX.enabled = true;
        interacter.VFX.SetVector4("Color", VFX.GetVector4("Color"));



        
        skinnedMeshToMesh.enabled = false;
        VFX.enabled = false;

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
        //enable skiined mesh to mesh
        interacter.skinnedMeshToMesh.enabled = false;

        //Enable VFX and set color
        interacter.VFX.enabled = false;


        skinnedMeshToMesh.enabled = true;
        VFX.enabled = true;

        interacter.SetIsOnEffect(false);

        foreach (Renderer renderer in rendererToDiable)
        {
            renderer.enabled = true;
        }

        _collider.enabled = true;
    }


}
