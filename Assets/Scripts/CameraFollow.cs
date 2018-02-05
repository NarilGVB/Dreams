using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform player;
    public float smothTime;
    public float smothTimeWall;
    private float velocity;
    public float maxWall;
    public float minWall;
    public float maxMove;
    public float minMove;

    public Transform Firstwall;
    public Transform Lastwall;

    public Transform MinMoveWall;
    public Transform MaxMoveWall;

    bool move = false;

    void Start()
    {

        minWall = Firstwall.position.x;
        maxWall = Lastwall.position.x;

        player = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        minMove = MinMoveWall.position.x;
        maxMove = MaxMoveWall.position.x;

        if (player.position.x < minMove || player.position.x > maxMove)
        {
            move = true;
        }
        else if(player.position.x > transform.position.x - 0.2f && player.position.x < transform.position.x + 0.2f)
        {
            move = false;
        }

        if (player.position.x > minWall && player.position.x < maxWall) {
            if (move)
            {
                float x = Mathf.SmoothDamp(transform.position.x, player.position.x, ref velocity, smothTime);

                GetComponent<Rigidbody2D>().MovePosition(new Vector3(x, transform.position.y, transform.position.z));
            }
        }
        else
        {
            if (player.position.x <= minWall) {
                float x = Mathf.SmoothDamp(transform.position.x, Firstwall.position.x, ref velocity, smothTimeWall);

                GetComponent<Rigidbody2D>().MovePosition(new Vector3(x, transform.position.y, transform.position.z));
            }
            else if (player.position.x >= maxWall)
            {
                float x = Mathf.SmoothDamp(transform.position.x, Lastwall.position.x, ref velocity, smothTimeWall);

                GetComponent<Rigidbody2D>().MovePosition(new Vector3(x, transform.position.y, transform.position.z));
            }
        }
    }
}
