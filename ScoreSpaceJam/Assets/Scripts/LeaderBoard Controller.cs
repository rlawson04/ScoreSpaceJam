using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class LeaderBoardController : MonoBehaviour
{
    public TMP_InputField MemberID;
    public float playerScore;
    public string leaderboardKey;
    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;
    bool loggedin = false;

    private void Start()
    {
        LoginRoutine();
        playerScore = Score.finalScore; 
    }

    private void Update()
    {
        // Fetches the highscores after the login has been completed
        if (loggedin)
        {
            StartCoroutine(FetchTopHighscoresRoutine());
            loggedin = false;
        }
    }

    // Logs into the loot locker API
    public void LoginRoutine()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                Debug.Log("Log in success");
                loggedin = true;
            }
            else
            {
                Debug.Log("Fail");
            }
        });
    }

    // Pushes the score entered into the loot locker api
    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(MemberID.text, (int)playerScore, leaderboardKey, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Fail");
            }
        });
    }

    // Grabs the top scores from the loot locker leaderboard and displays them
    IEnumerator FetchTopHighscoresRoutine()
    {
        Debug.Log("starting getting highscores");

        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, 0, (response) =>
        {
            if (response.success)
            {
                Debug.Log("High scores sucess");
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;
                
                for (int i = 0; i < members.Length; i++)
                {
                    Debug.Log(members[i].member_id);
                    
                    tempPlayerNames += members[i].rank + ". ";

                        if (members[i].member_id != "")
                        {
                            tempPlayerNames += members[i].member_id;
                        }
                        else
                        {
                            tempPlayerNames += members[i].member_id;
                        }
                        tempPlayerScores += members[i].score + "\n";
                        tempPlayerNames += "\n";
                    
                    
                }
                done = true;
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("Fail" + response.errorData);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
