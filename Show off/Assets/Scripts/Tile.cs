using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public List<GameObject> connectedTiles;

    public GameObject tilePrefab;

    public int localX;
    public int localZ;


    public Tile(GameObject _tilePrefab, int _localX, int _localZ)
    {
        tilePrefab = _tilePrefab;
        localX = _localX;
        localZ = _localZ;
    }

    public Tile(Tile _tile)
    {
        connectedTiles = _tile.connectedTiles;
        tilePrefab = _tile.tilePrefab;

        localX = _tile.localX;
        localZ = _tile.localZ;
    }

    public Tile(GameObject _tilePrefab, List<Tile> _connectedTiles)
    {
        //connectedTiles = _connectedTiles;
    }

    public void UpdateData(Tile _tile)
    {
        connectedTiles = _tile.connectedTiles;
        tilePrefab = _tile.tilePrefab;

        localX = _tile.localX;
        localZ = _tile.localZ;
    }

    public void AddConnectedTile(GameObject _connectedTile)
    {
        connectedTiles.Add(_connectedTile);
    }
}
