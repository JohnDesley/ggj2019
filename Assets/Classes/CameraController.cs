using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
