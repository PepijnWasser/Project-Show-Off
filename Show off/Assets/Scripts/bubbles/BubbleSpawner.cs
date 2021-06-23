using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;

    float secondCounter;
    public float spawnrate;
    public Vector2 spawnOffset;

    public Vector2 minMaxBubbleSize;

    private void Update()
    {
        secondCounter += Time.deltaTime;
        if(secondCounter > spawnrate)
        {
            secondCounter = 0;

            Vector3 startPos = this.transform.position + new Vector3(Random.Range(0, spawnOffset.x), Random.Range(0, spawnOffset.y), 0);
            GameObject bubble = Instantiate(bubblePrefab, startPos, Quaternion.identity, this.transform);
            float r = Random.Range(minMaxBubbleSize.x, minMaxBubbleSize.y);
            bubble.transform.localScale = new Vector3(r, r, 1);
        }
    }
}
