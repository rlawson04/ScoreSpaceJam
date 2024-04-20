using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private string gameScene = "Game Scene";
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject controlsCanvas;

    private void Start()
    {
        mainCanvas.SetActive(true);
        controlsCanvas.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void OpenControls()
    {
        mainCanvas.SetActive(false);
        controlsCanvas.SetActive(true);
    }

    public void CloseControls()
    {
        mainCanvas.SetActive(true);
        controlsCanvas.SetActive(false);
    }
}
