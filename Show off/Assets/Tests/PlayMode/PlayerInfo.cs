using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class PlayerInfoTests : MonoBehaviour
{
    [UnityTest]
    public IEnumerator TestResetting()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<PlayerInfo>();
        gameObject.GetComponent<PlayerInfo>().name = "Tester";
        gameObject.GetComponent<PlayerInfo>().age = 19;
        gameObject.GetComponent<PlayerInfo>().score = 77;

        gameObject.GetComponent<PlayerInfo>().ResetVariables();

        Assert.AreEqual(0, gameObject.GetComponent<PlayerInfo>().score);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestGetScore()
    {
        var playerInfo = new GameObject();
        playerInfo.AddComponent<PlayerInfo>();

        GameObject parent = new GameObject();
        parent.name = "Popularity";

        var child = new GameObject();
        child.AddComponent<Text>();
        child.GetComponent<Text>().text = "2";
        child.transform.SetParent(parent.transform);

        playerInfo.GetComponent<PlayerInfo>().GetPlayerStats();

        int i = playerInfo.GetComponent<PlayerInfo>().score;

        Assert.AreEqual(2, i);
        yield return null;
    }
}
