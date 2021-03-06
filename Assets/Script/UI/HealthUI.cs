//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Stats))]
public class HealthUI : MonoBehaviour
{
    public GameObject uiPrefab;//Health UI prefab

    Transform ui; //Health UI itself
    Image healthSlider; //Greenpart of Health UI

    Transform cam; //Main camera

    float visibleTime = 5f; //After 5 seconds, ui will be invisible
    float lastVisibleTime = 0f;

    public float yOffset = 1f; //Y offset from target's position
    public float zOffset = 1f; //Y offset from target's position

    // Start is called before the first frame update
    void Start()
    {
        //Find camera
        cam = Camera.main.transform;

        //Find worldspace Canvas so that we can add Healt UI
        foreach (Canvas c in FindObjectsOfType<Canvas>())
        {
            if (c.renderMode == RenderMode.WorldSpace)
            {
                //Create Health UI and make it as child of Canvas
                ui = Instantiate(uiPrefab, c.transform).transform;
                //Get green part of Health UI which is child of UI itself
                healthSlider = ui.GetChild(0).GetComponent<Image>();

                //It is not visible at first
                ui.gameObject.SetActive(false);
                break;
            }
        }

        //Subscribe this event
        GetComponent<Stats>().OnHealthChanged.AddListener(OnHealthChangedCallback);
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    void LateUpdate()
    {
        if (ui != null)
        {
            //Set Health UI's position to target(player ,enemy)'s position
            ui.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z + zOffset);

            //Align UI that makes UI always face to camera
            ui.forward = -cam.forward;

            //Check visible time
            if (Time.time - lastVisibleTime > visibleTime)
            {
                ui.gameObject.SetActive(false);
            }
        }
    }

    void OnHealthChangedCallback(float health, float maxHealth)
    {
        if (ui != null)
        {
            //Make health UI visible
            ui.gameObject.SetActive(true);
            lastVisibleTime = Time.time; //Save the last time when UI was visible

            //Calculate healthPercent and set it to ui
            float healthPercent = health / maxHealth;
            healthSlider.fillAmount = healthPercent;

            //If character was dead, destroy ui
            if (health <= 0)
            {
                Destroy(ui.gameObject);
            }
        }
    }
}
