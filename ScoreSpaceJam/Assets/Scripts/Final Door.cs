using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject score;
    [SerializeField] private Score scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0;
        hud.SetActive(false);
        score.SetActive(true);
        scoreManager.CalculateScore();
    }

    public void Ending()
    {
        SceneManager.LoadScene("Ending Scene");
    }
}
