using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBall : Skill
{
    private BallManager ballManager;
    private int ballsToAdd = 1;

    private GameObject ball;

    // Use this for initialization
    void Start ()
    {
        ballManager = GameObject.Find("BallManager").GetComponent<BallManager>();
        ball = GameObject.Find("Ball");
    }
	
	// Update is called once per frame
	void Update ()
    {
        TurnOffIsSkillActive();
    }

    private void TurnOffIsSkillActive()
    {
        //if the ballmanager checks that there are no multiballs, the state of the skill turns off
        if (!ballManager.CheckForMultiBalls())
        {
            IsSkillActive = false;
        }
    }

    public override void UseSkill()
    {
        base.UseSkill();

        for (int i = 0; i < ballsToAdd; i++)
        {
            GameObject.Instantiate(ball,ball.transform.position,ball.transform.rotation);
            ballManager.AddBallInPlayToCounter();
        }
    }

    public override void LevelUp()
    {
        base.LevelUp();
        ballsToAdd += 1;
    }
}
