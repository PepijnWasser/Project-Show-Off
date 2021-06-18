using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HighScoreTests
{
    [UnityTest]
    public IEnumerator DeleteEntries()
    {
        var gameObject = new GameObject();
        var highScoreTabe = gameObject.AddComponent<HighScoreTable>();
        highScoreTabe.amountOfPositionsDisplayed = 0;
        highScoreTabe.entryPositions = new List<Vector3>();

        highScoreTabe.DelteEntries();

        int i = highScoreTabe.GetEntryAmount();

        Assert.AreEqual(0, i);
        yield return null;
    }


    [UnityTest]
    public IEnumerator AddEntry()
    {
        var gameObject = new GameObject();
        var highScoreTabe = gameObject.AddComponent<HighScoreTable>();
        highScoreTabe.amountOfPositionsDisplayed = 0;
        highScoreTabe.entryPositions = new List<Vector3>();

        highScoreTabe.DelteEntries();
        highScoreTabe.AddHighScoreEntry(1, "tester");

        int i = highScoreTabe.GetEntryAmount();

        Assert.AreEqual(1, i);
        yield return null;
    }
}
