using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    float timer;
    public static float finalScore;
    float healthRemaining;
    [SerializeField] private TextMeshProUGUI scoreText;

    // Properties
    public float FinalScore {  get { return finalScore; } }

    // Start is called before the first frame update
    void Start()
    {
        finalScore = 0;
        timer = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        healthRemaining = Player.instance.Health;
        
    }
   
    public void CalculateScore()
    {
        finalScore = timer * healthRemaining;
        timer = (int)timer;
        healthRemaining = (int)healthRemaining; ;
        finalScore = (int)finalScore;

        scoreText.text = "Time: " + timer + "\nX\n" + "Health Remaining: " + healthRemaining + "\n=\n" + "Final Score: " + finalScore;
    }
}
