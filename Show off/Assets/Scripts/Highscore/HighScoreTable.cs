using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    public GameObject entryTemplate;
    List<GameObject> highScoreEntryGameObjectList = new List<GameObject>();
    public List<Vector3> entryPositions = new List<Vector3>();
    public int amountOfPositionsDisplayed = 8;

    private void Awake()
    {
        PlayerPrefs.DeleteKey("highScoreTable");
        HighScores highScores = GetHighScores();

        if (highScores == null)
        {
            CreateHighScoreTableInPlayerPrefs();

            highScores = GetHighScores();
        }

        if(highScores.highScoreEntryList.Count == 0)
        {
            Debug.Log("adding scores");
            AddHighScoreEntry(666, "GOD=DOG");
            AddHighScoreEntry(555, "SatanIsReal");
            AddHighScoreEntry(101, "GGStandForGreedyGandalf");
            AddHighScoreEntry(90, "Peppipeps");
            AddHighScoreEntry(50, "QuintessentialQ");
            AddHighScoreEntry(15, "Pontiff");
            AddHighScoreEntry(9, "Reimu");
            AddHighScoreEntry(-1, "The doctor");
            highScores = GetHighScores();

            Debug.Log(highScores.highScoreEntryList.Count);
        }
        
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
        if(entryPositions.Count >= amountOfPositionsDisplayed)
        {
            for(int i = 0; i <highScores.highScoreEntryList.Count && i < amountOfPositionsDisplayed; i++)
            {
                CreateHighScoreEntryTransform(highScores.highScoreEntryList[i], highScoreEntryGameObjectList);
            }
        }
        else
        {
            Debug.LogError(amountOfPositionsDisplayed + " amount to be displayed");
            Debug.LogError(highScores.highScoreEntryList.Count + " entries");
            Debug.LogError(entryPositions + " entryPositions");
            Debug.LogError("data mismatch", this);
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

    void CreateHighScoreTableInPlayerPrefs()
    {
        HighScores highScores = new HighScores();
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();
    }

    HighScores GetHighScores()
    {
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        return highScores;
    }

    class HighScores
    {
        public List<HighScoreEntry> highScoreEntryList = new List<HighScoreEntry>();
    }

    [System.Serializable]
    class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
