using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerInfo : MonoBehaviour
{
    private static PlayerInfo instance;

    public int score = 000;
    public int age = 999;
    public string playerName = "TempName";
    public int coralHealth = 0;


    public static PlayerInfo Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlayerInfo>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }

        ScenemanagerGameScene.onChangingScene += GetPlayerStats;
    }

    private void OnDestroy()
    {
        ScenemanagerGameScene.onChangingScene -= GetPlayerStats;
    }

    public void GetPlayerStats()
    {
        string popularity = GameObject.Find("Popularity").gameObject.GetComponentInChildren<Text>().text;
        if (popularity != null)
        {
            score = Int32.Parse(popularity);
        }
        else
        {
            Debug.Log("no popularity found");
        }

        string health = GameObject.Find("CoralHealthText").GetComponent<Text>().text;
        if (health != null)
        {
            coralHealth = Int32.Parse(health);
        }
        else
        {
            Debug.Log("no health found");
        }

    }

    public void ResetVariables()
    {
        score = 0;
        age = 999;
        playerName = "TempName";
        coralHealth = 0;
    }
}
