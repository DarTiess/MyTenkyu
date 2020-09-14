﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public float damping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool isTurnLeft;
    private Transform player;
    private int lastX;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isTurnLeft);
    }

    void FindPlayer(bool isTurnLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (isTurnLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x,
                player.position.y + offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x,
                player.position.y + offset.y, transform.position.z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            int curX = Mathf.RoundToInt(player.position.x);
            if (curX > lastX)
            {
                isTurnLeft = false;
            }
            else if (curX < lastX)
            {
                isTurnLeft = true;
            }
            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;

            if (isTurnLeft)
            {
                target = new Vector3(player.position.x - offset.x,
                    player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset.x,
                    player.position.y + offset.y, transform.position.z);
            }


            Vector3 currentPosition = Vector3.Lerp(transform.position,
                target, damping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}