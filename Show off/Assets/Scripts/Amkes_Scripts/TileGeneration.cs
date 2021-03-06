//UNUSED SCRIPT
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TerrainType
{
    public string name;
    public float height;
    public Color color;
}

public class TileGeneration : MonoBehaviour
{
    [SerializeField] private NoiseMapGeneration noiseMapGeneration;
    [SerializeField] private MeshRenderer tileRenderer;                 //Shows the height map
    [SerializeField] private MeshFilter meshFilter;                     //Accesses the mesh vertices
    [SerializeField] private MeshCollider meshCollider;                 //Handles collisions with the tile
    [SerializeField] private float mapScale;                            //Scale of the height map
    [SerializeField] private TerrainType[] terrainTypes;                //Available terrain types for level
    [SerializeField] private float heightMultiplier;
    [SerializeField] private AnimationCurve heightCurve;                //Corrects height generation to make sure water is plane level
    [SerializeField] private Wave[] waves;

    private void Start()
    {
        GenerateTile();
    }

    private void GenerateTile()
    {
        //Calculate tile depth and width based on the mesh vertices
        Vector3[] meshVertices = this.meshFilter.mesh.vertices;
        int tileDepth = (int)Mathf.Sqrt(meshVertices.Length);
        int tileWidth = tileDepth;

        //Calculate the offsets based on the tile position
        float offsetX = -this.gameObject.transform.position.x;
        float offsetZ = -this.gameObject.transform.position.z;

        //Generate a heightMap using noise
        float[,] heightMap = this.noiseMapGeneration.GenerateNoiseMap(tileDepth, tileWidth, this.mapScale, offsetX, offsetZ, waves);

        //Build a Texture2D from the height map
        Texture2D tileTexture = BuildTexture(heightMap);
        this.tileRenderer.material.mainTexture = tileTexture;

        //Update the tile mesh vertices according to the height map
        UpdateMeshVertices(heightMap);
    }

    private Texture2D BuildTexture(float[,] heightMap)
    {
        int tileDepth = heightMap.GetLength(0);
        int tileWidth = heightMap.GetLength(1);

        Color[] colorMap = new Color[tileDepth * tileWidth];
        for (int zIndex = 0; zIndex < tileDepth; zIndex++)
        {
            for (int xIndex = 0; xIndex < tileWidth; xIndex++)
            {
                //Transform the 2D map index is an Array index
                int colorIndex = zIndex * tileWidth + xIndex;
                float height = heightMap[zIndex, xIndex];
                //Choose a terrain type according to the height value
                TerrainType terrainType = ChooseTerrainType(height);
                //Assign as color a shade of grey proportional to the height value
                colorMap[colorIndex] = terrainType.color;
            }
        }

        //Create a new texture and set its pixel colors
        Texture2D tileTexture = new Texture2D(tileWidth, tileDepth);
        tileTexture.wrapMode = TextureWrapMode.Clamp;
        tileTexture.SetPixels(colorMap);
        tileTexture.Apply();

        return tileTexture;
    }

    private TerrainType ChooseTerrainType(float height)
    {
        //For each terrain type, check if the noise-height is lower than the one for the terrain type
        //Terrain types in editor need to be ascending order, loop picks first available option
        foreach(TerrainType terrainType in terrainTypes)
        {
            if (height < terrainType.height)
            {
                return terrainType;
            }
        }
        return terrainTypes[terrainTypes.Length - 1];
    }

    private void UpdateMeshVertices(float[,] heightMap)
    {
        int tileDepth = heightMap.GetLength(0);
        int tileWidth = heightMap.GetLength(1);

        Vector3[] meshVertices = this.meshFilter.mesh.vertices;

        //Iterate through all the heightMap coordinates, updating the vertex index
        int vertexIndex = 0;
        for (int zIndex = 0; zIndex < tileDepth; zIndex++)
        {
            for (int xIndex = 0; xIndex < tileWidth; xIndex++)
            {
                float height = heightMap[zIndex, xIndex];

                Vector3 vertex = meshVertices[vertexIndex];
                //Change the vertex Y coordinate, proportional to the height value
                meshVertices[vertexIndex] = new Vector3(vertex.x, this.heightCurve.Evaluate(height) * this.heightMultiplier, vertex.z);

                vertexIndex++;
            }
        }

        //Update the vertices in the mesh and update its properties
        this.meshFilter.mesh.vertices = meshVertices;
        this.meshFilter.mesh.RecalculateBounds();
        this.meshFilter.mesh.RecalculateNormals();
        //Update the mesh collider
        this.meshCollider.sharedMesh = this.meshFilter.mesh;
    }
}
