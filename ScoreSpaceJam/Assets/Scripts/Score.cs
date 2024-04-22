using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    float timer;
    float finalScore;
    float healthRemaining;

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
    }
}
