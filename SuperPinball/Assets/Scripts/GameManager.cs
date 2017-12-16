using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Lives
    {
        get
        {
            return lives;
        }
    }

    [SerializeField]
    private int lives = 3;
    // Use this for initialization

    private Text livesText;
    private Text scoreText;
    private GameObject afterActionPanel;
    private Text afterActionText;

    private int Score = 0;

	void Start ()
    {
        FindUITextElements();
        UpdateLivesText();
        UpdateScore();

    }

    private void FindUITextElements()
    {
        livesText = GameObject.Find("livesText").GetComponent<Text>();
        scoreText = GameObject.Find("scoreText").GetComponent<Text>();
        afterActionPanel = GameObject.Find("AfterAction");
        afterActionText = afterActionPanel.GetComponentInChildren<Text>();
        afterActionPanel.SetActive(false);
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    // Update is called once per frame
    void Update ()
    {

	}

    public void UpdateScore(int valueToAdd)
    {
        Score += valueToAdd;
        scoreText.text = "Score: " + Score.ToString();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + Score.ToString();
    }

    public void LoseALife()
    {
        lives -= 1;
        UpdateLivesText();
        CheckForGameOver();
    }


    private void CheckForGameOver()
    {
        if (lives < 0)
        {
            lives = 0;
            afterActionPanel.SetActive(true);
            afterActionText.text += Score.ToString();
        }
    }
}
