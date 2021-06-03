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
            playerInfo.Reset();
        }
        else
        {
            Debug.LogError("noPlayerInfoFound", this);
        }
    }
}
