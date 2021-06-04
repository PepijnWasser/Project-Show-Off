using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        PopulationCondition condition = GameObject.FindObjectOfType<PopulationCondition>();
        if (condition != null)
        {
            score = (int)condition.displayScore;
        }

    }

    public void Reset()
    {
        score = 0;
        age = 999;
        playerName = "TempName";
    }
}
