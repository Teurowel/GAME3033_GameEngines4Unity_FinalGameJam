using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] float health = 50.0f;

    [SerializeField] float rotateSpeed = 50.0f;

    [SerializeField] int score = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Stats playerStats = other.gameObject.GetComponent<Stats>();
            if (playerStats != null)
            {
                playerStats.HealthModify(health);

                if (Data.HasInstance)
                {
                    Data.instance.AddScore(score);
                }

                if (SoundManager.HasInstance)
                {
                    SoundManager.instance.PlaySFX("HealthPickupSFX");
                }

                Destroy(gameObject);
            }
        }
    }
}
