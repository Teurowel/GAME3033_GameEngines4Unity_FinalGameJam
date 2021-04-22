using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUI : MonoBehaviour
{
    Text scoreText;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Data.HasInstance)
        {
            Data.instance.OnScoreChanged.AddListener(OnScoreChangedCallback);
        }
        scoreText = GetComponent<Text>();
    }

    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnScoreChangedCallback(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
