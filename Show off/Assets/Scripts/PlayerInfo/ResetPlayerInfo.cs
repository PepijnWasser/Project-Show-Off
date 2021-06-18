using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerInfo : MonoBehaviour
{
    public void ResetInfo()
    {
        PlayerInfo playerInfo = GameObject.FindObjectOfType<PlayerInfo>();
        if(playerInfo != null)
        {
            playerInfo.ResetVariables();
        }
        else
        {
            Debug.LogError("noPlayerInfoFound", this);
        }
    }
}
