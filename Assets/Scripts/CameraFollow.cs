using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform player;
    public float smothTime;
    private float velocity;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        float x = Mathf.SmoothDamp(transform.position.x, player.position.x, ref velocity, smothTime);

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
