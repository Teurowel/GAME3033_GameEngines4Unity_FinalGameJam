using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    //Comp
    NavMeshAgent navMeshAgent;
    Enemy enemyComp;
    Animator animator;
    Stats stats;

    Vector3 patrolPosition1;
    Vector3 patrolPosition2;
    bool patrollingTo1 = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyComp = GetComponent<Enemy>();
        animator = GetComponent<Animator>();
        stats = GetComponent<Stats>();

        //Save patrol position
        patrolPosition1 = enemyComp.patrolPoint1.position;
        patrolPosition2 = enemyComp.patrolPoint2.position;

        //Find player with tag
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        //if (target == null)
        //{
        //    Debug.LogWarning("EnemyMove : Can't find player with tag(Player)");
        //}

        SetNextPatrolPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.isDead == true)
        {
            return;
        }

        if (enemyComp.enemyState == Enemy.EState.PATROL)
        {
            if (navMeshAgent.remainingDistance <= 0)
            {
                SetNextPatrolPosition();
            }
        }
        else if(enemyComp.enemyState == Enemy.EState.DETECT_TARGET)
        {
            //if target is in attack range..
            if (enemyComp.targetDistance <= stats.attackRange)
            {
                FaceTarget();
            }
            //or move to target
            else
            {
                navMeshAgent.SetDestination(enemyComp.target.position);
            }
        }
        //navMeshAgent.SetDestination(target.position);

        UpdateAnimator();
    }

    void SetNextPatrolPosition()
    {
        if(patrollingTo1 == false)
        {
            navMeshAgent.SetDestination(patrolPosition1);
            patrollingTo1 = true;
        }
        else
        {
            navMeshAgent.SetDestination(patrolPosition2);
            patrollingTo1 = false;
        }
    }

    void UpdateAnimator()
    {
        
        //make move direction(world) to relatve(player's rotation)
        //Vector3 localMoveDirection = Quaternion.Euler(transform.rotation.eulerAngles) * moveDirection.normalized;
        //localMoveDirection.Normalize();

        ////Calculate velocityZ and X based on move direction and forward direction, right direction
        float velocityZ = Vector3.Dot(navMeshAgent.velocity.normalized, transform.forward);
        float velocityX = Vector3.Dot(navMeshAgent.velocity.normalized, transform.right);

        animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
    }

    void FaceTarget()
    {
        //DIrection from enemy to player
        Vector3 direction = (enemyComp.target.position - transform.position).normalized;

        //Calculate Quaternion rotation based on look direction
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        //Slerp between current rotation and lookrotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
