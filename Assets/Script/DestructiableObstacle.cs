using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiableObstacle : MonoBehaviour
{

    [SerializeField] Data.EColor obstacleColor;
    [SerializeField] int playerProjectileLayerNumber; //has to be the number of layer

    //Comp
    Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        stats.OnHealthBelowZero.AddListener(OnHealthBelowZeroCallback);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerProjectileLayerNumber)
        {
            Projectile projectile = other.gameObject.GetComponent<Projectile>();
            if (projectile != null)
            {
                if (Data.HasInstance)
                {
                    bool result = Data.instance.CheckColorRelation(projectile.projectileColor, obstacleColor);
                    if (result == true)
                    {
                        stats.HealthModify(-projectile.damage);

                    }
                }
            }
        }
    }

    void OnHealthBelowZeroCallback()
    {
        if (SoundManager.HasInstance)
        {
            SoundManager.instance.PlaySFX("WallDestroySFX", 0.5f);
        }
        Destroy(gameObject);
    }
}
