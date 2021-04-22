using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectileSpawnTransform;
    [SerializeField] ParticleSystem gunShotFXPrefab;
    [SerializeField] AudioSource gunShotSFX;

    Enemy enemyComp;
    Stats stats;
    Animator animator;

    bool hasFired = false;

    ParticleSystem gunShotFX;

    // Start is called before the first frame update
    void Start()
    {
        enemyComp = GetComponent<Enemy>();
        stats = GetComponent<Stats>();
        animator = GetComponent<Animator>();

        gunShotFX = Instantiate(gunShotFXPrefab, projectileSpawnTransform.position, projectileSpawnTransform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.isDead == true)
        {
            return;
        }

        //if target is in attack range..
        Vector3 vectorToTarget = enemyComp.target.position - transform.position;
        vectorToTarget.Normalize();

        //Calculate angle between vector to player and forward
        float angleBetweenTarget = Mathf.Acos(Vector3.Dot(vectorToTarget, transform.forward)) * Mathf.Rad2Deg;
        //If that angle is less than..
        if (enemyComp.targetDistance <= stats.attackRange && angleBetweenTarget <= 15)
        {
            SpawnProjectile();
        }
    }

    void SpawnProjectile()
    {
        //check if we already fired and has ammo
        if (hasFired == false)
        {
            if (projectilePrefab != null && projectileSpawnTransform != null)
            {
                GameObject projectile = Instantiate(projectilePrefab, projectileSpawnTransform.position, transform.rotation);

                Projectile projectileComp = projectile.GetComponent<Projectile>();
                if (projectileComp != null)
                {
                    projectileComp.SetMaterial(enemyComp.projectileMaterial);
                    projectileComp.SetLayer(enemyComp.projectileLayerNumber);
                    projectileComp.projectileColor = enemyComp.projectileColor;
                    projectileComp.damage = stats.damage;
                }


                //trigger attack anim
                animator.SetTrigger("attackTrigger");

                //Play particle
                gunShotFX.gameObject.transform.position = projectileSpawnTransform.position;
                gunShotFX.gameObject.transform.rotation = projectileSpawnTransform.rotation;
                gunShotFX.Play();

                //sound
                gunShotSFX.Play();

                hasFired = true;
                Invoke(nameof(ResetHasFired), 1 / stats.attackSpeed);
            }
        }
    }

    void ResetHasFired()
    {
        hasFired = false;
    }
}
