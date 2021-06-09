using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLatestScore : MonoBehaviour
{
   HighScoreTable highScoreTable;

    private void Awake()
    {
        highScoreTable = GetComponent<HighScoreTable>();
        PlayerInfo playerInfo = GameObject.FindObjectOfType<PlayerInfo>();
        if (playerInfo != null)
        {
            Debug.Log("adding highscore");
            highScoreTable.AddHighScoreEntry(playerInfo.score, playerInfo.playerName);
        }
        else
        {
            Debug.LogError("noPlayerInfoFound", this);
        }
        
    }
}
