using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Data : Singleton<Data>
{
    public enum EColor
    {
        RED,
        GREEN,
        BLUE,
        WHITE
    }

    public Material redMaterial;
    public Material greenMaterial;
    public Material blueMaterial;
    public Material whiteMaterial;

    [HideInInspector]
    public UnityEvent<int> OnScoreChanged;
    public int score = 0;

    protected override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
        AddScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckColorRelation(EColor attackerColor, EColor takerColor)
    {
        if(attackerColor == EColor.RED && takerColor == EColor.GREEN)
        {
            return true;
        }
        else if(attackerColor == EColor.GREEN && takerColor == EColor.BLUE)
        {
            return true;
        }
        else if(attackerColor == EColor.BLUE && takerColor == EColor.RED)
        {
            return true;
        }
        //can damage any color with white
        else if(attackerColor == EColor.WHITE)
        {
            return true;
        }

        return false;
    }

    public void AddScore(int modifier)
    {
        score += modifier;
        if (OnScoreChanged != null)
        {
            OnScoreChanged.Invoke(score);
        }
    }
}
