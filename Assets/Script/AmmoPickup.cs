using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    //[SerializeField] int redBallAmmo = 0;
    //[SerializeField] int greenBallAmmo = 0;
    //[SerializeField] int blueBallAmmo = 0;

    //[SerializeField] Color ammoColor = Color.red;

    //[SerializeField] float rotateSpeed = 50.0f;

    //[SerializeField] int score = 0;

    //Renderer renderer;
    

    // Start is called before the first frame update
    void Start()
    {
        //renderer = GetComponent<Renderer>();
        //renderer.material.color = ammoColor;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    Player player = other.gameObject.GetComponent<Player>();
        //    if(player != null)
        //    {
        //        player.AmmoModify(Data.EColor.RED, redBallAmmo);
        //        player.AmmoModify(Data.EColor.GREEN, greenBallAmmo);
        //        player.AmmoModify(Data.EColor.BLUE, blueBallAmmo);

        //        if(Data.HasInstance)
        //        {
        //            Data.instance.AddScore(score);
        //        }

        //        if(SoundManager.HasInstance)
        //        {
        //            SoundManager.instance.PlaySFX("AmmoPickupSFX");
        //        }
             
        //        Destroy(gameObject);
        //    }
        //}
    }
}
