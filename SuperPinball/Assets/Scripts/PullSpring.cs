using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullSpring : MonoBehaviour
{
    public string inputButtonName = "Pull";
    public float distance = 5;
    public float speed = 1;
    public GameObject ball;
    public float power = 20000;

    private bool ready = false;
    private bool fire = false;
    private float moveCount = 0;

    [SerializeField]
    private LayerMask ballLayer;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        FireTheBall();
	}

    private void FireTheBall()
    {
        if (Input.GetButton(inputButtonName))
        {
            if (moveCount < distance)
            {
                transform.Translate(0, 0, -speed * Time.deltaTime);
                moveCount += speed * Time.deltaTime;
                fire = true;
            }
            else if (moveCount > 0)
            {
                if (fire && ready)
                {
                    ball.transform.TransformDirection(Vector3.forward * 10);
                    ball.GetComponent<Rigidbody>().AddForce(0, 0, moveCount * power);
                    fire = false;
                    ready = false;
                }
                transform.Translate(0, 0, 20 * Time.deltaTime);
                moveCount -= 20 * Time.deltaTime; 
            }
            if (moveCount <= 0)
            {
                fire = false;
                moveCount = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == ballLayer)
        {
            ready = true;
        }
    }
}
