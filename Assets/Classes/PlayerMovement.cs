using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3f;
    public Animator animator;

    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        animator.SetBool("HorizontalEnabled", horizontal > 0 || horizontal < 0);
        animator.SetBool("VerticalEnabled", vertical > 0 || vertical < 0);
        animator.SetFloat("HorizontalValue", horizontal);
        animator.SetFloat("VerticalValue", vertical);

        if (vertical > 0 || vertical < 0 || horizontal > 0 || horizontal < 0)
        {
            int lastDirection = 0;

            if (vertical < 0)
            {
                lastDirection = 1;
            }
            else if (horizontal > 0)
            {
                lastDirection = 2;
            }
            else if (horizontal < 0)
            {
                lastDirection = 3;
            }

            animator.SetInteger("LastDirection", lastDirection);
        }

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