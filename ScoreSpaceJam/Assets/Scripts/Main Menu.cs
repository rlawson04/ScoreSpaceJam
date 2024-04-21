using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Log in success");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
            }
            else
            {
                Debug.Log("Fail");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
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
