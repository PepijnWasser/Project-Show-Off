using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HexMapGenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;

    public List<GameObject> grassTiles;
    public List<GameObject> sandTiles;
    public GameObject seaTile;
    public GameObject coralTile;

    public List<GameObject> specialGrassTiles;
    public List<GameObject> specialSandTiles;
    public List<GameObject> specialSeaTiles;

    public List<float> grassRange;
    public List<float> sandRange;
    public List<float> seaRange;

    [Tooltip("bordersize needs to be odd")]
    public int borderSize;

    public float tileXOffset;
    public float tileZOffset;

    public float tileVariation;
    public int coralBlobCount;

    int randX;
    int randY;

    Tile[,] placedTiles;
    GameObject[,] placedObjects;

    int specialTilesPlaced = 0;
    int generationAttempts = 0;

    [HideInInspector]
    public bool completedGeneration = true;

    void Start()
    {
        GenerateNewMap();
    }

    void SetupNewGeneration()
    {
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);

        randX = UnityEngine.Random.Range(0, 200);
        randY = UnityEngine.Random.Range(0, 200);

        specialTilesPlaced = 0;
    }

    void GenerateNewMap()
    {
        SetupNewGeneration();
        CreateInitialTileMap();

        ConnectTiles();
        
        CreateSandAtBorder();
        PlaceSpecialGrassTiles();
        PlaceSpecialSandTiles();
        PlaceSpecialSeaTiles();
        PlaceCoralTiles();

        CheckCorrectGeneration();
    }

    //create map based on perlin noise
    void CreateInitialTileMap()
    {
        //create array
        placedTiles = new Tile[mapWidth + 2 * borderSize, mapHeight + 2 * borderSize];
        placedObjects = new GameObject[mapWidth + 2 * borderSize, mapHeight + 2 * borderSize];
        float[] centerMapOffset = { mapWidth / 2 * tileXOffset, mapHeight / 2 * tileZOffset };

        for (int x = 0 - borderSize; x < mapWidth + borderSize; x++)
        {
            for (int z = 0 - borderSize; z < mapHeight + borderSize; z++)
            {
                //check if within map
                GameObject tempObject;
                if (x > 0 && x < mapWidth && z > 0 && z < mapHeight)
                {
                    tempObject = Instantiate(DecideTile(x, z));
                }
                else
                {
                    tempObject = Instantiate(seaTile);
                }
                tempObject.AddComponent<Tile>();
                tempObject.GetComponent<Tile>().UpdateData(tempObject, x, z);

                placedTiles[x + borderSize, z + borderSize] = tempObject.GetComponent<Tile>();
                placedObjects[x + borderSize, z + borderSize] = tempObject;

                //position objects
                if (z % 2 == 0)
                {
                    tempObject.transform.position = new Vector3(x * tileXOffset + (tileXOffset / 2) - centerMapOffset[0], 0, z * tileZOffset - centerMapOffset[1]);

                }
                else
                {
                    tempObject.transform.position = new Vector3(x * tileXOffset - centerMapOffset[0], 0, z * tileZOffset - centerMapOffset[1]);
                }
                SetTileInfo(tempObject, x, z);
            }
        }
    }

    //create sand if grass touches water
    void CreateSandAtBorder()
    {
        foreach(Tile tile in placedTiles)
        {
            if (tile.tilePrefab.tag == "Grass")
            {
                foreach(GameObject connectedTile in tile.connectedTiles)
                {
                    if(connectedTile.tag == "Sea")
                    {
                        ReplaceTileWithPrefab(tile, sandTiles[UnityEngine.Random.Range(0, sandTiles.Count)]);          
                    }
                }
            }
        }
    }

    void PlaceSpecialGrassTiles()
    {
        for(int i = 0; i < specialGrassTiles.Count; i++)
        {
            
            bool tilePlaced = false;
            int j = 0;
            
            while(tilePlaced == false && j < 20)
            {              
                j = j + 1;
                Tile tile = placedTiles[UnityEngine.Random.Range(0, mapWidth), UnityEngine.Random.Range(0, mapHeight)];
                if(tile.tilePrefab.tag == "Grass")
                {
                    ReplaceTileWithPrefab(tile, specialGrassTiles[i]);
                    tilePlaced = true;
                    specialTilesPlaced += 1;
                }      
            }  
        }
    }

    void PlaceSpecialSandTiles()
    {
        for (int i = 0; i < specialSandTiles.Count; i++)
        {
            bool tilePlaced = false;
            int j = 0;
            while (tilePlaced == false && j < 100)
            {
                j += 1;
                Tile tile = placedTiles[UnityEngine.Random.Range(0, mapWidth), UnityEngine.Random.Range(0, mapHeight)];
                if (tile.tilePrefab.tag == "Sand")
                {
                    ReplaceTileWithPrefab(tile, specialSandTiles[i]);

                    tilePlaced = true;
                    specialTilesPlaced += 1;
                }
            }
        }
    }

    void PlaceSpecialSeaTiles()
    {
        for (int i = 0; i < specialSeaTiles.Count; i++)
        {
            bool tilePlaced = false;
            int j = 0;
            while (tilePlaced == false && j < 100)
            {
                j += 1;
                Tile tile = placedTiles[UnityEngine.Random.Range(0, mapWidth), UnityEngine.Random.Range(0, mapHeight)];
                if (tile.tilePrefab.tag == "Sea")
                {
                    ReplaceTileWithPrefab(tile, specialSeaTiles[i]);

                    tilePlaced = true;
                    specialTilesPlaced += 1;
                }
            }
        }
    }

    void PlaceCoralTiles()
    {
        int patchesPlaced = 0;
        int j = 0;

        while (patchesPlaced < coralBlobCount && j < 100)
        {
            j++;
            Tile tile = placedTiles[UnityEngine.Random.Range(0, mapWidth), UnityEngine.Random.Range(0, mapHeight)];
            if (tile.tilePrefab.tag == "Sea")
            {
                ReplaceTileWithPrefab(tile, coralTile);

                patchesPlaced++;
                specialTilesPlaced += 1;

                foreach (GameObject connectedTile in tile.connectedTiles)
                {
                    if (connectedTile.tag == "Sea")
                    {
                        ReplaceTileWithPrefab(connectedTile.GetComponent<Tile>(), coralTile);
                    }
                }
            }
        }
    }

    // makes sure all the special tiles are placed
    void CheckCorrectGeneration()
    {
        if (specialTilesPlaced == (specialSeaTiles.Count + specialSandTiles.Count + specialGrassTiles.Count + coralBlobCount))
        {
            Debug.Log("succesfull generation after " + generationAttempts);
            completedGeneration = true;
        }
        else
        {
            DeleteMap();
            generationAttempts += 1;

            if(generationAttempts < 20)
            {
                GenerateNewMap();
            }
            else
            {
                completedGeneration = false;
                Debug.Log("too many attempts");
            }
        }
    }

    GameObject DecideTile(int x, int z)
    {
        float val = Mathf.PerlinNoise(x / tileVariation + randX, z / tileVariation + randY);
        Mathf.Clamp(val, 0, 1);

        if (val >= grassRange[0] && val < grassRange[1])
        {
            return grassTiles[UnityEngine.Random.Range(0, grassTiles.Count)];
        }
        else if (val >= sandRange[0] && val < sandRange[1])
        {
            return sandTiles[UnityEngine.Random.Range(0, sandTiles.Count)];
        }
        else if (val >= seaRange[0] && val <= seaRange[1])
        {
            return seaTile;
        }
        else
        {
            return seaTile;
        }
    }

    void SetTileInfo(GameObject _gameObject, int _x, int _z)
    {
        _gameObject.transform.parent = transform;
        _gameObject.name = _x.ToString() + ", " + _z.ToString();
    }

    void ReplaceTileWithPrefab(Tile original, GameObject replacement)
    {
        GameObject oldTile = original.tilePrefab;
        GameObject tempObject = Instantiate(replacement);

        tempObject.transform.position = oldTile.transform.position;

        tempObject.AddComponent<Tile>();
        tempObject.GetComponent<Tile>().UpdateData(original);
        SetTileInfo(tempObject, oldTile.GetComponent<Tile>().localX, oldTile.GetComponent<Tile>().localZ);
        tempObject.name = tempObject.name + replacement.name;

        original.tilePrefab = tempObject;

        Destroy(oldTile);
    }

    void ConnectTiles()
    {
        foreach (Tile tile in placedTiles)
        {
            int tileX = tile.localX + borderSize;
            int tileZ = tile.localZ + borderSize;

            List<Tile> connectedTiles = new List<Tile>();
            List<GameObject> connectedObjects = new List<GameObject>();

            //even
            if (tileZ % 2 == 1)
            {

                //left side
                if (CheckIfTileExists(tileX - 1, tileZ))
                {
                    Tile newTile = placedTiles[tileX - 1, tileZ];
                    GameObject newObject = placedObjects[tileX - 1, tileZ];
                    connectedTiles.Add(newTile);
                    connectedObjects.Add(newObject);
                }
                //left up
                if (CheckIfTileExists(tileX, tileZ + 1))
                {
                    Tile newTile = placedTiles[tileX, tileZ + 1];
                    GameObject newObject = placedObjects[tileX, tileZ + 1];
                    connectedTiles.Add(newTile);
                    connectedObjects.Add(newObject);
                }
                //left bottom
                if (CheckIfTileExists(tileX, tileZ - 1))
                {
                    Tile newTile = placedTiles[tileX, tileZ - 1];
                    GameObject newObject = placedObjects[tileX, tileZ - 1];
                    connectedTiles.Add(newTile);
                    connectedObjects.Add(newObject);
                }
                //right
                if (CheckIfTileExists(tileX + 1, tileZ))
                {
                    Tile newTile = placedTiles[tileX + 1, tileZ];
                    GameObject newObject = placedObjects[tileX + 1, tileZ];
                    connectedTiles.Add(newTile);
                    connectedObjects.Add(newObject);
                }
                //right up
                if (CheckIfTileExists(tileX + 1, tileZ + 1))
                {
                    Tile newTile = placedTiles[tileX + 1, tileZ + 1];
                    GameObject newObject = placedObjects[tileX + 1, tileZ + 1];
                    connectedTiles.Add(newTile);
                    connectedObjects.Add(newObject);
                }
                //right bottom
                if (CheckIfTileExists(tileX + 1, tileZ - 1))
                {
                    Tile newTile = placedTiles[tileX + 1, tileZ - 1];
                    GameObject newObject = placedObjects[tileX + 1, tileZ - 1];
                    connectedTiles.Add(newTile);
                    connectedObjects.Add(newObject);
                }
            }
            else
            {
                //left side
                if (CheckIfTileExists(tileX - 1, tileZ))
                {
                    Tile newTile = placedTiles[tileX - 1, tileZ];
                    GameObject newObject = placedObjects[tileX - 1, tileZ];
                    connectedTiles.Add(newTile);
                    connectedObjects.Add(newObject);
                }
                //left up
                if (CheckIfTileExists(tileX - 1, tileZ + 1))
                {
                    Tile newTile = placedTiles[tileX - 1, tileZ + 1];
                    GameObject newObject = placedObjects[tileX - 1, tileZ + 1];
                    connectedTiles.Add(newTile);
                    connectedObjects.Add(newObject);
                }
                //left bottom
                if (CheckIfTileExists(tileX - 1, tileZ - 1))
                {
                    Tile newTile = placedTiles[tileX - 1, tileZ - 1];
                    GameObject newObject = placedObjects[tileX - 1, tileZ - 1];
                    connectedTiles.Add(newTile);
                    connectedObjects.Add(newObject);
                }
                //right side
                if (CheckIfTileExists(tileX + 1, tileZ))
                {
                    Tile newTile = placedTiles[tileX + 1, tileZ];
                    GameObject newObject = placedObjects[tileX + 1, tileZ];
                    connectedTiles.Add(newTile);
                    connectedObjects.Add(newObject);
                }
                //right up
                if (CheckIfTileExists(tileX, tileZ + 1))
                {
                    Tile newTile = placedTiles[tileX, tileZ + 1];
                    GameObject newObject = placedObjects[tileX, tileZ + 1];
                    connectedTiles.Add(newTile);
                    connectedObjects.Add(newObject);
                }
                //right bottom
                if (CheckIfTileExists(tileX, tileZ - 1))
                {
                    Tile newTile = placedTiles[tileX, tileZ - 1];
                    GameObject newObject = placedObjects[tileX, tileZ - 1];
                    connectedTiles.Add(newTile);
                    connectedObjects.Add(newObject);
                }
            }

            // tile.connectedTiles = connectedTiles;
            tile.connectedTiles = connectedObjects;
            tile.tilePrefab.GetComponent<Tile>().UpdateData(tile);
        }
    }

    void DeleteMap()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    bool CheckIfTileExists(int tileX, int tileZ)
    {
        if(tileX >= 0 && tileX <= placedTiles.GetLength(0) - 1 && tileZ >= 0 && tileZ <= placedTiles.GetLength(1) - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
