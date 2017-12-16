using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    [SerializeField]
    private string paddleInputButton;

    private Animator animator;

    #region experimental
    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float flipperStrength = 10f;
    public float flipperDamper = 1f;

    private HingeJoint hinge;
    private JointSpring spring;
    #endregion

    // Use this for initialization
    void Start ()
    {
        animator = GetComponentInParent<Animator>();
        hinge = GetComponent<HingeJoint>();
        spring = new JointSpring();
        hinge.useSpring = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        FlipperHandler();
        FlipperAnimation();
	}

    private void FlipperAnimation()
    {
        if (Input.GetButton(paddleInputButton))
        {
            animator.SetBool("paddlePressed", true);
        }
        else
        {
            animator.SetBool("paddlePressed", false);
        }
    }

    private void FlipperHandler()
    {

        spring.spring = flipperStrength;
        spring.damper = flipperDamper;

        if (Input.GetButton(paddleInputButton))
        {
            spring.targetPosition = pressedPosition;
            
        }
        else
        {
            spring.targetPosition = restPosition;
        }

        hinge.spring = spring;
        hinge.useLimits = true;
        //hinge.limits.min = restPosition;
        //hinge.limits.max = pressedPosition;

    }
}
