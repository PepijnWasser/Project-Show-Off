using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    public GameObject entryTemplate;
    List<GameObject> highScoreEntryGameObjectList = new List<GameObject>();
    public List<Vector3> entryPositions = new List<Vector3>();

    private void Awake()
    {

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        
        for (int i = 0; i < highScores.highScoreEntryList.Count; i++)
        {
            for(int j = i + 1; j < highScores.highScoreEntryList.Count; j++)
            {
                if(highScores.highScoreEntryList[j].score > highScores.highScoreEntryList[i].score)
                {
                    HighScoreEntry temp = highScores.highScoreEntryList[i];
                    highScores.highScoreEntryList[i] = highScores.highScoreEntryList[j];
                    highScores.highScoreEntryList[j] = temp;
                }
            }
        }
        highScoreEntryGameObjectList = new List<GameObject>();

        if(highScores.highScoreEntryList.Count != entryPositions.Count)
        {
            Debug.LogError("data mismatch", this);
        }
        else
        {
            foreach (HighScoreEntry highScoreEntry in highScores.highScoreEntryList)
            {
                CreateHighScoreEntryTransform(highScoreEntry, highScoreEntryGameObjectList);
            }
        }

    }
    
    void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, List<GameObject> gameObjectList)
    {
        GameObject entryGameObject = Instantiate(entryTemplate, this.transform);
        entryGameObject.transform.position = entryPositions[gameObjectList.Count];

        
        int rank = gameObjectList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }


        entryGameObject.transform.Find("Info").transform.Find("Name").GetComponent<Text>().text = highScoreEntry.name;
        entryGameObject.transform.Find("Info").transform.Find("Points").GetComponent<Text>().text = highScoreEntry.score.ToString();
        entryGameObject.transform.Find("Position").transform.Find("Position").GetComponent<Text>().text = rankString;

        gameObjectList.Add(entryGameObject);      
    }

    void AddHighScoreEntry(int score, string name)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        highScores.highScoreEntryList.Add(highScoreEntry);

        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();
    }

    class HighScores
    {
        public List<HighScoreEntry> highScoreEntryList;
    }

    [System.Serializable]
    class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
