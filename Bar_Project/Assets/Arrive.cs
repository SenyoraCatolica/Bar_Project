using UnityEngine;
using System.Collections;

public class Arrive : MonoBehaviour {

    public float min_distance = 0.1f;
    public float time_to_target = 0.25f;

    MovingManager move;

    // Use this for initialization
    void Start()
    {
        move = GetComponent<MovingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = move.target.transform.position - transform.position;

        if (diff.magnitude < min_distance)
            move.SetMovementVelocity(Vector3.zero);

        diff /= time_to_target;

        move.SetMovementVelocity(diff);
    }
}
