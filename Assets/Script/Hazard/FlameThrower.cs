using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    [SerializeField] float damage = 1.0f;
    [SerializeField] float damageInterval = 0.5f;
    [SerializeField] Player.EShieldType shieldType = Player.EShieldType.None;

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();

            if (player.shieldType != shieldType)
            {
                InvokeRepeating(nameof(DamagePlayer), 0.0f, damageInterval);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CancelInvoke(nameof(DamagePlayer));
        }
    }

    void DamagePlayer()
    {
        if(player != null)
        {
            if (player.isDead == false)
            {
                player.GetComponent<Stats>().HealthModify(-damage);
            }
            else
            {
                CancelInvoke(nameof(DamagePlayer));
            }
        }
    }
}
