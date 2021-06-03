using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLatestScore : MonoBehaviour
{
   HighScoreTable highScoreTable;

    private void Start()
    {
        highScoreTable = GetComponent<HighScoreTable>();
        PlayerInfo playerInfo = GameObject.FindObjectOfType<PlayerInfo>();
        if (playerInfo != null)
        {
            highScoreTable.AddHighScoreEntry(playerInfo.score, playerInfo.playerName);
        }
        else
        {
            Debug.LogError("noPlayerInfoFound", this);
        }
        
    }
}
