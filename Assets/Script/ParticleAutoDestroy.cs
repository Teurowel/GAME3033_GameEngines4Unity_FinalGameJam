using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestroy : MonoBehaviour
{
    ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if(ps)
        {
            if(ps.IsAlive() == false)
            {
                Destroy(gameObject);
            }
        }
    }
}
