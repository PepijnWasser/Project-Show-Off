using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class IslandGenerationTests
{
    [UnityTest]
    public IEnumerator TestSpecialGrassBuilding()
    {
        var gameObject = new GameObject();
        var islandGenerator = gameObject.AddComponent<HexMapGenerator>();

        var tile = new GameObject();
        tile.tag = "Grass";
        tile.AddComponent<Tile>();


        islandGenerator.specialGrassTiles = new List<GameObject> { new GameObject() };
        islandGenerator.specialSandTiles = new List<GameObject>();
        islandGenerator.specialSeaTiles = new List<GameObject>();
        islandGenerator.coralBlobCount = 0;
        islandGenerator.grassTiles = new List<GameObject> { tile };
        islandGenerator.sandTiles = new List<GameObject>();
        islandGenerator.seaTile = new GameObject();
        islandGenerator.mapWidth = 2;
        islandGenerator.mapHeight = 2;
        islandGenerator.borderSize = 3;
        islandGenerator.tileVariation = 0;
        islandGenerator.tileXOffset = 0;
        islandGenerator.tileZOffset = 0;
        islandGenerator.grassRange = new List<float> { 0, 1 };
        islandGenerator.sandRange = new List<float> { 1, 1 };
        islandGenerator.seaRange = new List<float> { 1, 1 };

        bool completed = islandGenerator.completedGeneration;

        Assert.AreEqual(true, completed);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestSpecialSandBuilding()
    {
        var gameObject = new GameObject();
        var islandGenerator = gameObject.AddComponent<HexMapGenerator>();

        var tile = new GameObject();
        tile.tag = "Sand";
        tile.AddComponent<Tile>();


        islandGenerator.specialGrassTiles = new List<GameObject>();
        islandGenerator.specialSandTiles = new List<GameObject> { new GameObject() };
        islandGenerator.specialSeaTiles = new List<GameObject>();
        islandGenerator.coralBlobCount = 0;
        islandGenerator.grassTiles = new List<GameObject>();
        islandGenerator.sandTiles = new List<GameObject> { tile };
        islandGenerator.seaTile = new GameObject();
        islandGenerator.mapWidth = 2;
        islandGenerator.mapHeight = 2;
        islandGenerator.borderSize = 3;
        islandGenerator.tileVariation = 0;
        islandGenerator.tileXOffset = 0;
        islandGenerator.tileZOffset = 0;
        islandGenerator.grassRange = new List<float> { 0, 1 };
        islandGenerator.sandRange = new List<float> { 1, 1 };
        islandGenerator.seaRange = new List<float> { 1, 1 };

        bool completed = islandGenerator.completedGeneration;

        Assert.AreEqual(true, completed);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestSpecialSeaBuilding()
    {
        var gameObject = new GameObject();
        var islandGenerator = gameObject.AddComponent<HexMapGenerator>();

        var tile = new GameObject();
        tile.tag = "Sea";
        tile.AddComponent<Tile>();


        islandGenerator.specialGrassTiles = new List<GameObject>();
        islandGenerator.specialSandTiles = new List<GameObject>();
        islandGenerator.specialSeaTiles = new List<GameObject> { new GameObject()};
        islandGenerator.coralBlobCount = 0;
        islandGenerator.grassTiles = new List<GameObject>();
        islandGenerator.sandTiles = new List<GameObject>();
        islandGenerator.seaTile = tile;
        islandGenerator.mapWidth = 2;
        islandGenerator.mapHeight = 2;
        islandGenerator.borderSize = 3;
        islandGenerator.tileVariation = 0;
        islandGenerator.tileXOffset = 0;
        islandGenerator.tileZOffset = 0;
        islandGenerator.grassRange = new List<float> { 0, 1 };
        islandGenerator.sandRange = new List<float> { 1, 1 };
        islandGenerator.seaRange = new List<float> { 1, 1 };

        bool completed = islandGenerator.completedGeneration;

        Assert.AreEqual(true, completed);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestCoralSpawning()
    {
        var gameObject = new GameObject();
        var islandGenerator = gameObject.AddComponent<HexMapGenerator>();

        var tile = new GameObject();
        tile.tag = "Sea";
        tile.AddComponent<Tile>();


        islandGenerator.specialGrassTiles = new List<GameObject>();
        islandGenerator.specialSandTiles = new List<GameObject>();
        islandGenerator.specialSeaTiles = new List<GameObject>();
        islandGenerator.coralBlobCount = 2;
        islandGenerator.grassTiles = new List<GameObject>();
        islandGenerator.sandTiles = new List<GameObject>();
        islandGenerator.seaTile = tile;
        islandGenerator.coralTile = new GameObject();
        islandGenerator.mapWidth = 2;
        islandGenerator.mapHeight = 2;
        islandGenerator.borderSize = 3;
        islandGenerator.tileVariation = 0;
        islandGenerator.tileXOffset = 0;
        islandGenerator.tileZOffset = 0;
        islandGenerator.grassRange = new List<float> { 0, 1 };
        islandGenerator.sandRange = new List<float> { 1, 1 };
        islandGenerator.seaRange = new List<float> { 1, 1 };

        bool completed = islandGenerator.completedGeneration;

        Assert.AreEqual(true, completed);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestBasicGeneration()
    {
        var gameObject = new GameObject();
        var islandGenerator = gameObject.AddComponent<HexMapGenerator>();
        islandGenerator.specialGrassTiles = new List<GameObject>();
        islandGenerator.specialSandTiles = new List<GameObject>();
        islandGenerator.specialSeaTiles = new List<GameObject>();
        islandGenerator.coralBlobCount = 0;
        islandGenerator.grassTiles = new List<GameObject> { new GameObject()};
        islandGenerator.sandTiles = new List<GameObject>();
        islandGenerator.seaTile = new GameObject();
        islandGenerator.mapWidth = 7;
        islandGenerator.mapHeight = 7;
        islandGenerator.borderSize = 3;
        islandGenerator.tileVariation = 0;
        islandGenerator.tileXOffset = 0;
        islandGenerator.tileZOffset = 0;
        islandGenerator.grassRange = new List<float> { 0, 1 };
        islandGenerator.sandRange = new List<float> { 1, 1 };
        islandGenerator.seaRange = new List<float> { 1, 1 };

        bool completed = islandGenerator.completedGeneration;

        Assert.AreEqual(true, completed);
        yield return null;
    }

}
