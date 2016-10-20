using UnityEngine;
using System.Collections;

public class TimeCalculator : MonoBehaviour {


    private float StartTime;
    private float minutes;
    private float seconds;
    private bool start;

    void Start()
    {
        StartTime = Time.time;
        minutes = seconds = 0.0f;
        start = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (start == true)
        {
            float t = Time.time - StartTime;

            minutes = t / 60;
            seconds = t % 60;

            //  string minutes_string = ((int)t / 60).ToString();
            //  string seconds_string = (t % 60).ToString();
        }


    }

    public void StartTimer()
    {
        start = true;
    }

   public  void ResetTimer()
    {
        start = false;
        StartTime = Time.time;
        minutes = seconds = 0.0f;
    }

    public float GetSeconds()
    {
        return seconds;
    }

    public float GetMinutes()
    {
        return minutes;
    }

    public bool GetActive()
    {
        return start;
    }



}


