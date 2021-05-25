using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightGenerator : MonoBehaviour
{
    public int randomSeed;
    
    private List<Transform> children = new List<Transform>();
    private bool createdMap;

    private void Start()
    {
        createdMap = false;
        Random.InitState(randomSeed);
    }

    private void Update()
    {
        if (createdMap == false)
        {
            CreateTileList();
            SetSeaHeight();
            SetSandHeight();
            SetGrassHeight();

            createdMap = true;
        }
    }

    private void CreateTileList()
    {
        //Get all TileMapGenerator's children (all created tiles)
        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i));
        }
    }

    private void SetSeaHeight()
    {
        //Set standard sea-height
        for (int i = 0; i < children.Count; i++)
        {
            if (children[i].tag == "Sea")
            {
                children[i].transform.Translate(0, -2, 0);
            }
        }
    }

    private void SetSandHeight()
    {
        //Set standard sand-height
        for (int i = 0; i < children.Count; i++)
        {
            if (children[i].tag == "Sand")
            {
                children[i].transform.Translate(0, 0, 0);
            }
        }
    }

    private void SetGrassHeight()
    {
        //Procedurally generate different grass-heights
        for (int i = 0; i < children.Count; i++)
        {
            if (children[i].tag == "Grass")
            {
                children[i].transform.Translate(0, Random.Range(0,3), 0);
            }
        }
    }
}
