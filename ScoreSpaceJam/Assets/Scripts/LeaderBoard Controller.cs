using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;
using TMPro;
using System.Collections;

public class LeaderBoardController : MonoBehaviour
{
    public TMP_InputField MemberID, PlayerScore;
    public string leaderboardKey;
    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;

    private void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return FetchTopHighscoresRoutine();
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

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(PlayerScore.text), leaderboardKey, (response) =>
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

    IEnumerator FetchTopHighscoresRoutine()
    {
        Debug.Log("starting getting highscores");

        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, 0, (response) =>
        {
            if (response.success)
            {
                Debug.Log("High scores fetched");
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;
                
                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ".";

                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
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
