﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    public float dampTime = 0.10f;//плавность хода
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(new Vector3(target.position.x, target.position.y + 0.75f, target.position.z));
            Vector3 delta = new Vector3(target.position.x, target.position.y, target.position.z) - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.25f, point.z)); //(new Vector3(0.5, 0.5, point.z)) смешение камеры;
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}