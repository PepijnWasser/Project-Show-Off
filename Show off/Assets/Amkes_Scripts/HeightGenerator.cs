using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightGenerator : MonoBehaviour
{
    public int randomSeed;
    
    private List<Transform> children = new List<Transform>();
    private bool createdMap;
    private Vector3 centerPos = new Vector3(0, 0, 0);

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
            //SetGrassHeight1();
            SetGrassHeight2();

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

    private void SetGrassHeight1()
    {
        //Procedurally generate different grass-heights
        for (int i = 0; i < children.Count; i++)
        {
            if (children[i].tag == "Grass")
            {
                Vector3 childPos = new Vector3(children[i].position.x, children[i].position.y, children[i].position.z);
                Vector3 dVec = childPos - centerPos;
                float distance = dVec.magnitude;

                if (distance >= 0 && distance <= 10)
                {
                    children[i].transform.Translate(0, Random.Range(6.0f, 8.0f), 0);
                }
                else if (distance > 10 && distance <= 30)
                {
                    children[i].transform.Translate(0, Random.Range(4.0f, 6.0f), 0);
                }
                else if (distance > 30 && distance <= 60)
                {
                    children[i].transform.Translate(0, Random.Range(2.0f, 4.0f), 0);
                }
                else if (distance > 60 && distance <= 100)
                {
                    children[i].transform.Translate(0, Random.Range(0.0f, 2.0f), 0);
                }
            }
        }
    }

    private void SetGrassHeight2()
    {
        //Procedurally generate different grass-heights
        for (int i = 0; i < children.Count; i++)
        {
            if (children[i].tag == "Grass")
            {
                Vector3 childPos = new Vector3(children[i].position.x, children[i].position.y, children[i].position.z);
                Vector3 dVec = childPos - centerPos;
                float distance = dVec.magnitude;

                if (distance >= 0 && distance <= 30)
                {
                    children[i].transform.Translate(0, Random.Range(2.5f, 4.5f), 0);
                }
                else if (distance > 30 && distance <= 60)
                {
                    children[i].transform.Translate(0, Random.Range(1.0f, 3.0f), 0);
                }
                else if (distance > 60 && distance <= 100)
                {
                    children[i].transform.Translate(0, Random.Range(0.0f, 1.0f), 0);
                }
            }
        }
    }
}
