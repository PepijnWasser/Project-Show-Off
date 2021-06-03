using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCorrectScore : MonoBehaviour
{
    Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        PlayerInfo playerInfo = GameObject.FindObjectOfType<PlayerInfo>();
        if(playerInfo != null)
        {
            text.text = playerInfo.score.ToString();
        }
        else
        {
            Debug.LogError("noPlayerInfoFound", this);
        }
    }
}
