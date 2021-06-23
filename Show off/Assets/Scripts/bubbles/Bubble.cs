using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    float secondCOunter = 0;
    Vector3 startPos;

    public int widthVariation;
    public int ascendSpeed;


    private void Start()
    {
        startPos = this.transform.position;
    }

    private void Update()
    {
        secondCOunter += Time.deltaTime;

        float xVariation = Mathf.Sin(secondCOunter * widthVariation);
        this.transform.position = startPos + new Vector3(xVariation, secondCOunter * ascendSpeed , 0);

        if(startPos.y + secondCOunter * ascendSpeed > Screen.height + 10)
        {
            Destroy(this.gameObject);
        }
    }
}
