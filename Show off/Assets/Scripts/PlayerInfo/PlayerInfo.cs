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
            Debug.Log("creating instance");
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }

        ScenemanagerGameScene.onChangingScene += GetPlayerScore;
    }

    private void OnDestroy()
    {
        ScenemanagerGameScene.onChangingScene -= GetPlayerScore;
    }

    void GetPlayerScore()
    {
        string popularity = GameObject.Find("Popularity").gameObject.GetComponentInChildren<Text>().text;
        if (popularity != null)
        {
            score = Int32.Parse(popularity);
        }

    }

    public void Reset()
    {
        score = 0;
        age = 999;
        playerName = "TempName";
    }
}
