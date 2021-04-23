using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string gameLevelScene;

    [SerializeField] Canvas mainMenuCanvas;
    [SerializeField] Canvas creditCanvas;
    [SerializeField] Canvas instructionCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(gameLevelScene);
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }

    public void OnCreditButtonClicked()
    {
        mainMenuCanvas.enabled = false;
        creditCanvas.enabled = true;
    }

    public void OnBackButtonClicked()
    {
        mainMenuCanvas.enabled = true;
        creditCanvas.enabled = false;
        instructionCanvas.enabled = false;
    }

    public void OnInstructionButtonClicked()
    {
        mainMenuCanvas.enabled = false;
        instructionCanvas.enabled = true;
    }
}
