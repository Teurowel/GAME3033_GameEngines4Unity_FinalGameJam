using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameMenu gameMenu;

    //[SerializeField] Transform[] goalPositions;

    // Start is called before the first frame update
    void Start()
    {
        //int randomGoalIdx = Random.Range(0, goalPositions.Length);
        //transform.position = goalPositions[randomGoalIdx].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Win");
        gameMenu.OnGameOver("Game Win");
    }
}
