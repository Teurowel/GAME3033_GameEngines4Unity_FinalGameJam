using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] Canvas hudCanvas;
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas gameOverCanvas;

    [SerializeField] Text gameOverText;
    [SerializeField] Text finalScoreText;

    [SerializeField] string mainMenuScene;
    [SerializeField] string gameLevelScene;
    public bool isPaused { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPause()
    {
        //show cursor and lock
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;

        //pause
        Time.timeScale = 0;

        hudCanvas.enabled = false;
        pauseCanvas.enabled = true;

        isPaused = true;

        if (SoundManager.HasInstance)
        {
            SoundManager.instance.PlaySFX("ButtonSFX");
        }
    }

    public void OnResumeClicked()
    {
        //hide cursor and lock
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        //unpause
        Time.timeScale = 1;

        hudCanvas.enabled = true;
        pauseCanvas.enabled = false;

        isPaused = false;

        if (SoundManager.HasInstance)
        {
            SoundManager.instance.PlaySFX("ButtonSFX");
        }
    }

    public void OnMainMenuClicked()
    {
        if (SoundManager.HasInstance)
        {
            SoundManager.instance.PlaySFX("ButtonSFX");
        }

        //unpause
        Time.timeScale = 1;



        SceneManager.LoadScene(mainMenuScene);

    }

    public void OnGameOver(string gameOverString)
    {
        gameOverText.text = gameOverString;

        hudCanvas.enabled = false;
        gameOverCanvas.enabled = true;

        //show cursor and lock
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;

        //pause
        Time.timeScale = 0;

        if(Data.HasInstance)
        {
            finalScoreText.text = "Score: " + Data.instance.score.ToString();
        }
        
    }

    public void OnPlayAgainClicked()
    {
        if (SoundManager.HasInstance)
        {
            SoundManager.instance.PlaySFX("ButtonSFX");
        }

        //pause
        Time.timeScale = 1;

        SceneManager.LoadScene(gameLevelScene);
    }
}
