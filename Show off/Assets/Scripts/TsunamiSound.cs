using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsunamiSound : MonoBehaviour
{
    GameObject dayObject;
    public AudioSource stage1;
    public AudioSource stage2;
    public AudioSource stage3;
    public AudioSource stage4;
    int Day= 0;
    bool stage1bool = false;
    bool stage2bool = false;
    bool stage3bool = false;
    bool stage4bool = false;
    void Start()
    {
        GameObject dayObject = GameObject.Find("TimeText");
        TimeScript timeScript = dayObject.GetComponent<TimeScript>();
        Day = timeScript.dayNumber;
    }
    void Update()
    {
        if (stage1bool == false)
        {
            Stage1();
            stage1bool = true;
        }

        Debug.Log(Day);
        
        if (Day >= 3)
        {
            if(stage2bool == false)
            {
                stage2bool = true;
                Stage2();
                stage1.Stop();
            }  
        }
        if (Day >= 5)
        {
            if (stage3bool == false)
            {
                stage3bool = true;
                Stage3();
                stage2.Stop();
            }
        }
        if (Day >= 7)
        {
            if (stage4bool == false)
            {
                stage4bool = true;
                Stage4();
                stage3.Stop();
            }
        }
    }
    void Stage1()
    {
        stage1.Play();
    }
    void Stage2()
    {
        stage2.Play();
    }
    void Stage3()
    {
        stage3.Play();
    }
    void Stage4()
    {
        stage4.Play();
    }
}
