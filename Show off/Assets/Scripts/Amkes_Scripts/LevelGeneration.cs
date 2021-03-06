//UNUSED SCRIPT
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private int mapWidthInTiles;
    [SerializeField] private int mapDepthInTiles;
    [SerializeField] private GameObject tilePrefab;

    private void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        //Get the tile dimensions from the tile prefab
        Vector3 tileSize = tilePrefab.GetComponent<MeshRenderer>().bounds.size;
        int tileWidth = (int)tileSize.x;
        int tileDepth = (int)tileSize.z;

        //For each tile, instantiate a tile in the correct position
        for (int xTileIndex = 0; xTileIndex < mapWidthInTiles; xTileIndex++)
        {
            for (int zTileIndex = 0; zTileIndex < mapDepthInTiles; zTileIndex++)
            {
                //Calculate the tile position based on the X and Z indices
                Vector3 tilePosition = new Vector3(this.gameObject.transform.position.x + xTileIndex * tileWidth, this.gameObject.transform.position.y, this.gameObject.transform.position.z + zTileIndex * tileDepth);
                //Instantiate a new tile
                GameObject tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity) as GameObject;
            }
        }
    }
}
