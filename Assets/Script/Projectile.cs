using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;

    [SerializeField] float destroyTime = 5.0f;
    float destroyTimeCheck = 0.0f;

    public Data.EColor projectileColor;

    public float damage = 0.0f;

    //comp
    Renderer projectileRenderer;
    Material projectileMaterial;

    // Start is called before the first frame update
    void Start()
    {
        projectileRenderer = GetComponent<Renderer>();
        projectileRenderer.material = projectileMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        //Just move forward
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        

        //Auto destroy
        destroyTimeCheck += Time.deltaTime;
        if(destroyTimeCheck >= destroyTime )
        {
            Destroy(gameObject);
        }
    }

    public void SetMaterial(Material newMaterial)
    {
        projectileMaterial = newMaterial;
    }

    public void SetLayer(int projectileLayer)
    {
        gameObject.layer = projectileLayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
