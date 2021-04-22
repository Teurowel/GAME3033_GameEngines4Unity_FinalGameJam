using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] GameObject projectilePrefab;
    //[SerializeField] Transform projectileSpawnTransform;
    //[SerializeField] ParticleSystem gunShotFXPrefab;
    //[SerializeField] AudioSource gunShotSFX;

    ////comp
    //Animator animator;
    //Player player;
    //Stats stats;


    ////Variable
    //bool isFiringPressed = false;
    //bool hasFired = false;

    //ParticleSystem gunShotFX;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        //player = GetComponent<Player>();
        //stats = GetComponent<Stats>();

        //gunShotFX = Instantiate(gunShotFXPrefab, projectileSpawnTransform.position, projectileSpawnTransform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //if(isFiringPressed)
        //{
        //    SpawnProjectile();
        //}
    }

    public void OnFire(InputValue value)
    {
        //if (player.gameMenu.isPaused == false)
        //{
        //    isFiringPressed = value.isPressed;
        //}

        //SEt animator
        //animator.SetBool("IsFiring", value.isPressed);
    }

    //void SpawnProjectile()
    //{
    //    //check if we already fired and has ammo
    //    if (hasFired == false && player.GetAmmo(player.projectileColor) != 0)
    //    {
    //        if (projectilePrefab != null && projectileSpawnTransform != null)
    //        {
    //            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnTransform.position, transform.rotation);
                
    //            Projectile projectileComp = projectile.GetComponent<Projectile>();
    //            if(projectileComp != null)
    //            {
    //                projectileComp.SetMaterial(player.projectileMaterial);
    //                projectileComp.SetLayer(player.projectileLayerNumber);
    //                projectileComp.projectileColor = player.projectileColor;
    //                projectileComp.damage = stats.damage;
    //            }

    //            //ammo modify
    //            player.AmmoModify(player.projectileColor, -1);

    //            //trigger attack anim
    //            animator.SetTrigger("attackTrigger");

    //            //Play particle
    //            gunShotFX.gameObject.transform.position = projectileSpawnTransform.position;
    //            gunShotFX.gameObject.transform.rotation = projectileSpawnTransform.rotation;
    //            gunShotFX.Play();

    //            //sound
    //            gunShotSFX.Play();

    //            hasFired = true;
    //            Invoke(nameof(ResetHasFired), 1 / stats.attackSpeed);
    //        }
    //    }
    //}

    //void ResetHasFired()
    //{
    //    hasFired = false;
    //}
}
