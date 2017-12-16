using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private int extraBallsInPlay = 0;

    /// <summary>
    /// For use when a multiball or any extra ball is spawned, to avoid extra life loss
    /// </summary>
    public void AddBallInPlayToCounter()
    {
        extraBallsInPlay += 1;
    }

    /// <summary>
    /// Used for when multiballs are on board, and one is removed from play
    /// </summary>
    public void RemoveBallInPlayFromCounter()
    {
        extraBallsInPlay -= 1;
    }

    /// <summary>
    /// Checks for multiballs
    /// </summary>
    /// <returns>returns true if there are any</returns>
    public bool CheckForMultiBalls()
    {
        bool cfmb;
        if (extraBallsInPlay > 0)
        {
            cfmb = true;
        }
        else
        {
            cfmb = false;
        }
        return cfmb;
    }

	// Use this for initialization
	void Start ()
    {
		
	}
}
