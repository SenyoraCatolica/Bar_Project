using UnityEngine;
using System.Collections;

public class MovingManager : MonoBehaviour {

    public GameObject target;
   // public GameObject aim;
    public float max_mov_velocity = 5.0f;
    public float max_rot_velocity = 10.0f; // in degrees / second

    [Header("-------- Read Only --------")]
    public Vector3 movement = Vector3.zero;
    public float rotation = 0.0f; // degrees


    // Methods for behaviours to set / add velocities
    public void SetMovementVelocity(Vector3 velocity)
    {
        movement = velocity;
    }

    public void SetRotationVelocity(float rotation_velocity)
    {
        rotation = rotation_velocity;
    }



    // Update is called once per frame
    void Update()
    {
        // cap velocity
        if (movement.magnitude > max_mov_velocity)
        {
            movement.Normalize();
            movement *= max_mov_velocity;
        }

        // cap rotation
        Mathf.Clamp(rotation, -max_rot_velocity, max_rot_velocity);

        // rotate the arrow
        float angle = Mathf.Atan2(movement.x, movement.z);
       // aim.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);


        // final rotate
        transform.rotation *= Quaternion.AngleAxis(rotation * Time.deltaTime, Vector3.up);

        // finally move
        transform.position += movement * Time.deltaTime;
    }
}
