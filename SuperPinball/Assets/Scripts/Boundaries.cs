using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Boundaries : MonoBehaviour
{
    public GameObject ball;

    public LayerMask ballMask;

    private Vector3 startingPosition;

    private GameManager gameManager;
    private BallManager ballManager;

    private AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        startingPosition = ball.transform.position;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ballManager = GameObject.Find("BallManager").GetComponent<BallManager>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnCollisionEnter(Collision collision)
    {
        if (ball.layer == ballMask)
        {
            if (!ballManager.CheckForMultiBalls())
            {
                RespawnBall(ball);
            }
            else
            {
                if (collision.gameObject != ball)
                {
                    GameObject.Destroy(collision.gameObject);
                }
                ballManager.RemoveBallInPlayFromCounter();
            }
        }
    }

    private void RespawnBall(GameObject ball)
    {
        audioSource.Play();

        if (gameManager.Lives > 0)
        {
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.transform.position = startingPosition;
        }

        gameManager.LoseALife();
    }
}
