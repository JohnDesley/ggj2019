using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3f;

    void FixedUpdate()
    {
        transform.position += ComputeVelocity() * movementSpeed;
    }

    Vector3 ComputeVelocity() {
        Vector2 cartesian = new Vector2(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, -Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        Vector2 isometric = CartesianToIsometric(cartesian);
        return new Vector3(isometric.x, isometric.y, 0.0f);
    }

    Vector2 CartesianToIsometric(Vector2 cartesian) {
        return new Vector2(cartesian.x - cartesian.y, -(cartesian.x + cartesian.y) / 2);
    }
}