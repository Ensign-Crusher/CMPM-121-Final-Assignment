using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code inspired by udemy lesson "How to make a katamari style sticky ball game in unity"
public class StickyBall : MonoBehaviour
{
    public float facingAngle = 0.0f;
    float currentX = 0.0f;
    float currentZ = 0.0f;
    Vector2 unitV2;

    float size = 1; //controls size of ball

    public GameObject smallBallSize; //categories for ball/items
    bool smallBall = false;
    public GameObject mediumBallSize;
    bool mediumBall = false;
    public GameObject largeBallSize;
    bool largeBall = false;


    public GameObject cameraReference;
    //public GameObject ball;
    float distanceToCamera = 5;

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

        unlockPickUpCategories();
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
            if (size >= 2.3f)
            {
                largeBall = true;
                for (int i = 0; i < largeBallSize.transform.childCount; i++)
                {
                    largeBallSize.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }
        }
    }

    //Pick up Objects
    private void OnTriggerEnter(Collider col)
    {
        if(col.transform.CompareTag("CanStick"))
        {
            //grow the ball
            transform.localScale += new Vector3(.01f, .01f, .01f);
            size += .1f;
            distanceToCamera += 0.08f;
            col.enabled = false;

            //Set parents so that stuck object follows ball
            col.transform.SetParent(this.transform);
        }
    }
}
