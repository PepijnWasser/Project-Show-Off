using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAverageScores : MonoBehaviour
{
    public HighScoreTable highScoreTable;

    private void Start()
    {
        GetComponent<Text>().text = "Average: " + highScoreTable.GetAverageScores().ToString();
    }
}
