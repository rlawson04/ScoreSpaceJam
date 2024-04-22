using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour
{
    [SerializeField] private string gameScene = "Game Scene";
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject controlsCanvas;

    private void Start()
    {
        // Displays main menu and hides controls
        mainCanvas.SetActive(true);
        controlsCanvas.SetActive(false);
    }

    // Loads scene on button press
    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    // Opens menu for controls
    public void OpenControls()
    {
        mainCanvas.SetActive(false);
        controlsCanvas.SetActive(true);
    }

    // Closes menu for controls
    public void CloseControls()
    {
        mainCanvas.SetActive(true);
        controlsCanvas.SetActive(false);
    }
}
