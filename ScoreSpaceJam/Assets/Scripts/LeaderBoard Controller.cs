using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;
using TMPro;
using System.Collections;

public class LeaderBoardController : MonoBehaviour
{
    public TMP_InputField MemberID, PlayerScore;
    public string leaderboardKey;

    private void Start()
    {
        StartCoroutine(LoginRoutine());
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
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
}
