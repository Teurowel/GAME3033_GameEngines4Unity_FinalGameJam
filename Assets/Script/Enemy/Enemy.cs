using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public enum EState
    {
        PATROL,
        DETECT_TARGET
    }

    [SerializeField] LayerMask enemyLayer;
    [SerializeField] LayerMask neutralLayer;

    [SerializeField] LayerMask currentLayer;
    [SerializeField] int score = 0;

    [SerializeField] ParticleSystem bloodSplatFX;

    //comp
    [SerializeField] Renderer surfaceRenderer;
    Stats stats;
    NavMeshAgent navMeshAgent;
    Animator animator;
    Collider collider;
    Rigidbody rb;

    public Transform patrolPoint1;
    public Transform patrolPoint2;

    public Data.EColor enemyColor;
    public Transform target { get; private set; }
    public EState enemyState { get; private set; } = EState.PATROL;

    public float targetDistance { get; private set; } = 0.0f;

    public Material projectileMaterial { get; private set; }

    public int projectileLayerNumber; //has to be the number of layer

    public Data.EColor projectileColor;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();

        //Save current layer
        currentLayer = 1 << gameObject.layer; //convert int to layer mask

        //Find target with player tag
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target == null)
        {
            Debug.LogWarning("EnemyMove : Can't find player with tag(Player)");
        }

        if (Data.HasInstance)
        {
            projectileMaterial = Data.instance.whiteMaterial;
            projectileColor = Data.EColor.WHITE;

            SetEnemyMaterialColor();
        }

        stats.OnHealthBelowZero.AddListener(OnHealthBelowZeroCallback);

        //renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.isDead == true)
        {
            return;
        }

        //Get target distance and check if it is close than attack range and im patrolling
        targetDistance = Vector3.Distance(target.position, transform.position);
        if (targetDistance <= stats.detectRange && enemyState == EState.PATROL)
        {
            enemyState = EState.DETECT_TARGET;
            navMeshAgent.stoppingDistance = stats.attackRange;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (stats.isDead == true)
        {
            return;
        }

        //If this is neutral... only collide with player, enemy projectile
        if (currentLayer == neutralLayer)
        {
            surfaceRenderer.material = other.gameObject.GetComponent<Renderer>().material;
        }
        //If this is enemy
        else
        {
            Projectile projectile = other.gameObject.GetComponent<Projectile>();
            if (projectile != null)
            {
                if (Data.HasInstance)
                {
                    bool result = Data.instance.CheckColorRelation(projectile.projectileColor, enemyColor);
                    if (result == true)
                    {
                        stats.HealthModify(-projectile.damage);

                        Instantiate(bloodSplatFX, transform.position, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));

                        //Sound
                        if (SoundManager.HasInstance)
                        {
                            SoundManager.instance.PlaySFX("HitSFX", 2.0f);
                        }
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (stats != null)
        {
            //Draw detect range
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, stats.detectRange);

            //Draw attack range
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, stats.attackRange);
        }
    }

    void SetEnemyMaterialColor()
    {
        if (enemyColor == Data.EColor.RED)
        {
            surfaceRenderer.material = Data.instance.redMaterial;
        }
        else if (enemyColor == Data.EColor.GREEN)
        {
            surfaceRenderer.material = Data.instance.greenMaterial;
        }
        else if (enemyColor == Data.EColor.BLUE)
        {
            surfaceRenderer.material = Data.instance.blueMaterial;
        }
    }

    void OnHealthBelowZeroCallback()
    {
        stats.isDead = true;
        
        animator.SetTrigger("deathTrigger");
        
        Data.instance.AddScore(score);

        collider.enabled = false;

        navMeshAgent.isStopped = true;
        navMeshAgent.velocity = Vector3.zero;
        rb.velocity = Vector3.zero;
    }

    public void OnDeathAnimationFinished()
    {
        Destroy(gameObject);
    }
}
