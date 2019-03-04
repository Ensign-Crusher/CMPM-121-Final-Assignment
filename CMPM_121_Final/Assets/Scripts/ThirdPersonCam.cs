using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code inspired by udemy lesson "How to make a katamari style sticky ball game in unity"
public class ThirdPersonCam : MonoBehaviour
{
    public GameObject ball;
    Vector3 lookAtOffset;

    void Start()
    {
        lookAtOffset = new Vector3(0.0f, 1.0f, 0f);
    }

    void Update()
    {
        //look at ball
        transform.LookAt(ball.transform.position + lookAtOffset);
    }
}
