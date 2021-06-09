using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    public Transform hourHandTransform;
    public Transform minuteHandTransform;

    private float time;

    [Range(0, 24)]
    public int startTime;
    private float startTimeDegrees;

    public float secondsToPlay;

    public float hoursToPlay;
    private float hoursDegreesToPlay;

    public delegate void OnClockCompleted();
    public static event OnClockCompleted onClockCompleted;


    private void Awake()
    {
        hourHandTransform = transform.Find("hourHand");
        minuteHandTransform = transform.Find("minuteHand");
    }

    private void Start()
    {
        float tempT = startTime;
        if(startTime >= 12)
        {
            tempT = startTime - 12;
        }
        int hoursOnHand = 12;
        startTimeDegrees = - (360.0f / (hoursOnHand / tempT));

        hoursDegreesToPlay = -30 * hoursToPlay;
    }

    private void Update()
    {
        time += Time.deltaTime;

        hourHandTransform.eulerAngles = new Vector3(0, 0, startTimeDegrees) + new Vector3(0, 0, (time / secondsToPlay) * hoursDegreesToPlay);

        minuteHandTransform.eulerAngles = new Vector3(0, 0, startTimeDegrees) + new Vector3(0, 0, time / secondsToPlay * hoursDegreesToPlay * 12);

        if (time / secondsToPlay > 1f)
        {
            onClockCompleted?.Invoke();
        }

    }

    public void Reset()
    {
        time = 0;
    }
}
