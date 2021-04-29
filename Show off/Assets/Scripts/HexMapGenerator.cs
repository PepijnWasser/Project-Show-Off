using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMapGenerator : MonoBehaviour
{
    public int mapWidth;

    public int mapHeight;

    public List<GameObject> tilePrefabs;

    public float tileXOffset;
    public float tileZOffset;

    public float tileVariation;

    void Start()
    {
        CreateTileMap();
    }

    void CreateTileMap()
    {
        for(int x = 0; x < mapWidth; x++)
        {
            for(int z = 0; z < mapHeight; z++)
            {
                GameObject tempObject = Instantiate(tilePrefabs[DecideTile(x, z)]);


                if(z % 2 == 1)
                {
                    tempObject.transform.position = new Vector3(x * tileXOffset + (tileXOffset / 2), 0, z * tileZOffset);

                }
                else
                {
                    tempObject.transform.position = new Vector3(x * tileXOffset, 0, z * tileZOffset);
                }
                SetTileInfo(tempObject, x, z);
            }
        }
    }

    void SetTileInfo(GameObject _gameObject, int _x, int _z)
    {
        _gameObject.transform.parent = transform;
        _gameObject.name = _x.ToString() + ", " + _z.ToString();
    }

    int DecideTile(int x, int z)
    {
        float val = Mathf.PerlinNoise(x / tileVariation , z / tileVariation);
        Debug.Log(val);


        int tileCount = tilePrefabs.Count;
        int tile = 1;

        while (true)
        {
            float compare = (float)(1 * tile) / tileCount;
            if(val < compare)
            {
                return tile - 1;
            }
            else
            {
                tile += 1;
            }
        }
    }
}
