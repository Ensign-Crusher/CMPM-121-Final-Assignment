using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code taken from assignment 5

public class Character : MonoBehaviour
{
    public Animator anim; //stores animations

    public GameObject followBall;

    //private float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //get the animator
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(followBall.transform.position.x, followBall.transform.position.y - .5f, followBall.transform.position.z - 1);
        if (Input.GetKey(KeyCode.W)) //go forward
        {
            //print("W Pressed");
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            anim.SetInteger("Movement", 1); //change key for animation
        }
        else if (Input.GetKeyUp(KeyCode.W)) //stop animation
        {
            anim.SetInteger("Movement", 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //print("A Pressed");
            //transform.Translate(Vector3.left * Time.deltaTime * speed);
            anim.SetInteger("Movement", 1);
        }
        else if (Input.GetKeyUp(KeyCode.A)) //stop animation
        {
            anim.SetInteger("Movement", 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //print("S Pressed");
            //transform.Translate(Vector3.back * Time.deltaTime * speed);
            anim.SetInteger("Movement", 1);
        }
        else if (Input.GetKeyUp(KeyCode.S)) //stop animation
        {
            anim.SetInteger("Movement", 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //print("D Pressed");
            //transform.Translate(Vector3.right * Time.deltaTime * speed);
            anim.SetInteger("Movement", 1);
        }
        else if (Input.GetKeyUp(KeyCode.D)) //stop animation
        {
            anim.SetInteger("Movement", 0);
        }
    }
}
