using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

//Code inspired by udemy lesson "How to make a katamari style sticky ball game in unity"
public class StickyBall : MonoBehaviour
{
    public float facingAngle = 0.0f;
    float currentX = 0.0f;
    float currentZ = 0.0f;
    Vector2 unitV2;

    public float size = 1; //controls size of ball
    public float sizeNew = 1; //helps with sound, see Update

    public GameObject smallBallSize; //categories for ball/items
    bool smallBall = false;
    public GameObject mediumBallSize;
    bool mediumBall = false;
    public GameObject largeBallSize;
    bool largeBall = false;
    public GameObject hugeBallSize;
    bool hugeBall = false;
    public GameObject extraBallSize;
    bool extraBall = false;
    public GameObject finalBallSize;
    bool finalBall = false;

    public GameObject sizeUI;


    public GameObject cameraReference;
    //public GameObject ball;
    float distanceToCamera = 5;

    void Start()
    {
        //Audio
        FindObjectOfType<Music>().Play("Theme");
    }

    // Update is called once per frame
    void Update()
    {
        //Controls
        currentX = Input.GetAxis("Horizontal") * Time.deltaTime * -100;
        currentZ = Input.GetAxis("Vertical") * Time.deltaTime * 300;

        //Facing Angle
        facingAngle += currentX;
        unitV2 = new Vector2(Mathf.Cos(facingAngle * Mathf.Deg2Rad), Mathf.Sin(facingAngle * Mathf.Deg2Rad));

        //Apply force to ball
        this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(unitV2.x, 0, unitV2.y) * currentZ * 3);

        //Set cam pos
        cameraReference.transform.position = new Vector3(-unitV2.x * distanceToCamera, distanceToCamera, -unitV2.y * distanceToCamera) + this.transform.position;

        unlockPickUpCategories(); //do the function!

        //Audio
        if(size > sizeNew)
        {
            FindObjectOfType<Music>().Play("Pop");
        }
        sizeNew = size;
    }

    void unlockPickUpCategories()
    {
        if(smallBall == false)
        {
            if (size >= 1.0f)
            {
                smallBall = true;
                for (int i = 0; i < smallBallSize.transform.childCount; i++)
                {
                    smallBallSize.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }
        }
        else if (mediumBall == false)
        {
            if (size >= 2.0f)
            {
                mediumBall = true;
                for (int i = 0; i < mediumBallSize.transform.childCount; i++)
                {
                    mediumBallSize.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }
        }
        else if (largeBall == false)
        {
            if (size >= 3.0f)
            {
                largeBall = true;
                for (int i = 0; i < largeBallSize.transform.childCount; i++)
                {
                    largeBallSize.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }
        }
        else if (hugeBall == false)
        {
            if (size >= 4.0f)
            {
                hugeBall = true;
                for (int i = 0; i < hugeBallSize.transform.childCount; i++)
                {
                    hugeBallSize.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }
        }
        else if (extraBall == false)
        {
            if (size >= 5.0f)
            {
                extraBall = true;
                for (int i = 0; i < extraBallSize.transform.childCount; i++)
                {
                    extraBallSize.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }
        }
        else if (finalBall == false)
        {
            if (size >= 10.0f)
            {
                finalBall = true;
                for (int i = 0; i < finalBallSize.transform.childCount; i++)
                {
                    finalBallSize.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }
        }
    }

    //Pick up Objects
    private void OnTriggerEnter(Collider col)
    {
        if(col.transform.CompareTag("CanStick"))
        {
            if(0<size)
            {
                //grow the ball
                transform.localScale += new Vector3(.01f, .01f, .01f);
                size += .1f;
                distanceToCamera += 0.1f;
                col.enabled = false;

                //Set parents so that stuck object follows ball
                col.transform.SetParent(this.transform);

                sizeUI.GetComponent<Text>().text = "Mass: " + Math.Round(size, 2);
            }
        }
        if (col.transform.CompareTag("CanStick2"))
        {
            if (0 < size)
            {
                //grow the ball
                transform.localScale += new Vector3(.01f, .01f, .01f);
                size += .2f;
                distanceToCamera += 2.0f;
                col.enabled = false;

                //Set parents so that stuck object follows ball
                col.transform.SetParent(this.transform);

                sizeUI.GetComponent<Text>().text = "Mass: " + Math.Round(size, 2);

                //Audio
                FindObjectOfType<Music>().Play("Pop");
            }
        }
        if (col.transform.CompareTag("CanStick3"))
        {
            if (0 < size)
            {
                //grow the ball
                transform.localScale += new Vector3(.01f, .01f, .01f);
                size += .5f;
                distanceToCamera += 10f;
                col.enabled = false;

                //Set parents so that stuck object follows ball
                col.transform.SetParent(this.transform);

                sizeUI.GetComponent<Text>().text = "Mass: " + Math.Round(size, 2);
            }
        }
    }
}
