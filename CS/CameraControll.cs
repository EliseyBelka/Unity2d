using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public Transform ObjTarget;
    int distance = -10;
    float lift = 1.5f;

    void Update()
    {
        transform.position = new Vector3(0, lift, distance) + ObjTarget.position;
        transform.LookAt(ObjTarget);
    }

}
