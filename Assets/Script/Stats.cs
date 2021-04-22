using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    public float hp = 100;
    public float maxHp = 100;
    public float attackRange = 4;
    public float detectRange = 6;
    public float attackSpeed = 1.0f;
    public float damage = 10;
    public bool isDead = false;

    [HideInInspector]
    public UnityEvent<float, float> OnHealthChanged;
    [HideInInspector]
    public UnityEvent OnHealthBelowZero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealthModify(float modifier)
    {
        hp += modifier;

        if(hp >= maxHp)
        {
            hp = maxHp;
        }

        if(OnHealthChanged != null)
        {
            OnHealthChanged.Invoke(hp, maxHp);
        }

        if(hp <= 0)
        {
            if(OnHealthBelowZero != null)
            {
                OnHealthBelowZero.Invoke();
            }
        }
    }
}
