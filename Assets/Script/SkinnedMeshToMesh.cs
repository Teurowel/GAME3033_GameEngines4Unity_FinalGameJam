using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SkinnedMeshToMesh : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMesh;
    public VisualEffect VFXGraph;
    public float refreshRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Debug.Log("Start updating VFG graph");
        StartCoroutine(UpdateVFXGraph());
    }

    private void OnDisable()
    {
        Debug.Log("Stop updating VFG graph");
        StopCoroutine(UpdateVFXGraph());
    }

    IEnumerator UpdateVFXGraph()
    {
        while(gameObject.activeSelf)
        {
            Mesh m = new Mesh(); //create mesh
            skinnedMesh.BakeMesh(m); //save current skinnedmesh's vertex's position to mesh

            Vector3[] vertices = m.vertices;
            Mesh m2 = new Mesh();
            m2.vertices = vertices;

            VFXGraph.SetMesh("Mesh", m2); //assign mehs to VFXGraph

            yield return new WaitForSeconds(refreshRate);
        }
    }
}
