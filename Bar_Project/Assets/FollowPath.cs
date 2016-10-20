using UnityEngine;
using System.Collections;
using BansheeGz.BGSpline.Components;


public class FollowPath : MonoBehaviour
{

    public BGCcMath path;
    private MovingManager moving_manager;
    private Arrive arrive;
    private TimeCalculator timer;

    private Vector3 pos;
    private float radius;
    private float ratio;

    // Use this for initialization
    void Start()
    {

       // moving_manager = GetComponent<MovingManager>();
        timer = GetComponent<TimeCalculator>();
        arrive = GetComponent<Arrive>();
        radius = 0.1f;

        pos = path.CalcPositionByClosestPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        CalcPosition();
        // arrive.arrive(pos);

    }

    void CalcPosition()
    {
        if (Vector3.Distance(transform.position, path.CalcPositionByDistanceRatio(ratio)) <= 0.1f)
        {

           /* if (timer.GetActive() != true)
                timer.StartTimer();*/

           // if (timer.GetSeconds() > 5)
            {
                timer.ResetTimer();
                pos = path.CalcPositionByDistanceRatio(ratio);
                ratio += 0.1f;
            }

        }

        else
            pos = path.CalcPositionByDistanceRatio(ratio);
    }
}
