using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    //public Material projectileMaterial { get; private set; }

    //public int projectileLayerNumber; //has to be the number of layer

    //public Data.EColor projectileColor;

    //[HideInInspector]
    //public UnityEvent<int> OnRedBallAmmoChanged;
    //[HideInInspector]
    //public UnityEvent<int> OnGreenBallAmmoChanged;
    //[HideInInspector]
    //public UnityEvent<int> OnBlueBallAmmoChanged;
    

    //[SerializeField] int redBallAmmo = 10;
    //[SerializeField] int greenBallAmmo = 10;
    //[SerializeField] int blueBallAmmo = 10;

    //[SerializeField] ParticleSystem bloodSplatFX;

    public GameMenu gameMenu;

    //public Data.EColor playerColor;
    bool isDead = false;

    [Header("Raycast Settings")]
    [SerializeField] float rayDistance = 100;
    [SerializeField] float rayYOffset = 0;
    [SerializeField] LayerMask interactableLayerMask;

    GameObject detectedInteractable = null; //Detected interactable object

    [SerializeField] Transform modelHip; //TO scale up and down player

    bool isOnEffect = false; //is player having effect?

    //Event
    [HideInInspector]
    public UnityEvent OnDetectInteractable; //FtoInteract UI will subscribte this
    [HideInInspector]
    public UnityEvent OnUnDetectInteractable; //FtoInteract UI will subscribte this

    //Comp
    Stats stats;
    Animator animator;
    PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        stats.OnHealthBelowZero.AddListener(OnHealthBelowZeroCallback);

        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();

        //if (Data.HasInstance)
        //{
        //    projectileMaterial = Data.instance.redMaterial;
        //    projectileColor = Data.EColor.RED;
        //}

        //AmmoModify(Data.EColor.RED, 0);
        //AmmoModify(Data.EColor.GREEN, 0);
        //AmmoModify(Data.EColor.BLUE, 0);

        //Every 0.1s, call detect interactable object
        InvokeRepeating(nameof(DetectInteractableObject), 0.0f, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (isDead == false)
        //{
        //    Projectile projectile = other.gameObject.GetComponent<Projectile>();
        //    if (projectile != null)
        //    {
        //        if (Data.HasInstance)
        //        {
        //            bool result = Data.instance.CheckColorRelation(projectile.projectileColor, playerColor);
        //            if (result == true)
        //            {
        //                stats.HealthModify(-projectile.damage);


        //                Instantiate(bloodSplatFX, transform.position, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));

        //                //Sound
        //                if (SoundManager.HasInstance)
        //                {
        //                    SoundManager.instance.PlaySFX("HitSFX", 2.0f);
        //                }
        //            }
        //        }
        //    }
        //}
    }

    //public void OnNumber1(InputValue value)
    //{
    //    if(Data.HasInstance)
    //    {
    //        projectileMaterial = Data.instance.redMaterial;
    //        projectileColor = Data.EColor.RED;

    //        if (SoundManager.HasInstance)
    //        {
    //            SoundManager.instance.PlaySFX("ButtonSFX");
    //        }
    //    }
    //}

    //public void OnNumber2(InputValue value)
    //{
    //    if (Data.HasInstance)
    //    {
    //        projectileMaterial = Data.instance.greenMaterial;
    //        projectileColor = Data.EColor.GREEN;

    //        if (SoundManager.HasInstance)
    //        {
    //            SoundManager.instance.PlaySFX("ButtonSFX");
    //        }
    //    }
    //}

    //public void OnNumber3(InputValue value)
    //{
    //    if (Data.HasInstance)
    //    {
    //        projectileMaterial = Data.instance.blueMaterial;
    //        projectileColor = Data.EColor.BLUE;

    //        if (SoundManager.HasInstance)
    //        {
    //            SoundManager.instance.PlaySFX("ButtonSFX");
    //        }
    //    }
    //}

    //public void AmmoModify(Data.EColor ammoColor, int modifier)
    //{
    //    switch (ammoColor)
    //    {
    //        case Data.EColor.RED :
    //            redBallAmmo += modifier;
    //            if(OnRedBallAmmoChanged != null)
    //            {
    //                OnRedBallAmmoChanged.Invoke(redBallAmmo);
    //            }
    //            break;

    //        case Data.EColor.GREEN:
    //            greenBallAmmo += modifier;
    //            if (OnGreenBallAmmoChanged != null)
    //            {
    //                OnGreenBallAmmoChanged.Invoke(greenBallAmmo);
    //            }
    //            break;

    //        case Data.EColor.BLUE:
    //            blueBallAmmo += modifier;
    //            if (OnBlueBallAmmoChanged != null)
    //            {
    //                OnBlueBallAmmoChanged.Invoke(blueBallAmmo);
    //            }
    //            break;
    //    }
    //}

    //public int GetAmmo(Data.EColor ammoColor)
    //{
    //    if(ammoColor == Data.EColor.RED)
    //    {
    //        return redBallAmmo;
    //    }
    //    else if (ammoColor == Data.EColor.GREEN)
    //    {
    //        return greenBallAmmo;
    //    }
    //    else if (ammoColor == Data.EColor.BLUE)
    //    {
    //        return blueBallAmmo;
    //    }

    //    return 0;
    //}

    public void OnPause(InputValue value)
    {
        if(gameMenu != null)
        {
            if (gameMenu.isPaused == false)
            {
                gameMenu.OnPause();
            }
            else
            {
                gameMenu.OnResumeClicked();
            }
        }
    }

    void OnHealthBelowZeroCallback()
    {
        isDead = true;
        playerInput.enabled = false;
        animator.SetTrigger("deathTrigger");
    }

    public void OnDeathAnimationFinished()
    {
        gameMenu.OnGameOver("Game Over");
    }

    //Keeep calling this function to detect interactable object
    void DetectInteractableObject()
    {
        //If player is alreay having effect, return
        if(isOnEffect == true)
        {
            return;
        }

        //Raycast to detect interactable layer
        RaycastHit hitResult;
        Vector3 origin = transform.position;
        origin.y += rayYOffset;
        if (Physics.Raycast(origin, transform.forward, out hitResult, rayDistance, interactableLayerMask))
        {
            //Debug.Log(hitResult.collider.gameObject.name);
            if (detectedInteractable == null)
            {
                Debug.Log("Detect Interactable");
                detectedInteractable = hitResult.collider.gameObject;

                if (OnDetectInteractable != null)
                {
                    OnDetectInteractable.Invoke();
                }
            }
        }
        else
        {
            if (detectedInteractable != null)
            {
                Debug.Log("UnDetect Interactable");
                detectedInteractable = null;
                OnUnDetectInteractable.Invoke();
            }
        }
    }

    //Will be called when press F
    public void OnInteract(InputValue value)
    {
        if(detectedInteractable != null)
        {
            IInteractable interactable = detectedInteractable.GetComponent<IInteractable>();
            if(interactable != null)
            {
                interactable.OnInteracted(this);
            }

            if (detectedInteractable != null)
            {
                Debug.Log("UnDetect Interactable");
                detectedInteractable = null;
                OnUnDetectInteractable.Invoke();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 origin = transform.position;
        origin.y += rayYOffset;
        Gizmos.DrawRay(origin, transform.forward * rayDistance);
    }

    public void SetScale(Vector3 newScale)
    {
        modelHip.localScale = newScale;
    }

    public void SetIsOnEffect(bool isEffect)
    {
        isOnEffect = isEffect;
    }
}
