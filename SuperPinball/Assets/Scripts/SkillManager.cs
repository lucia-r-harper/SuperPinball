using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    //When I am cloned for Multiball, the reference of both ball and multiball changes, please fix
    public GameObject Ball;

    public List<Skill> Skills;

    private MultiBall multiBall;

    public int Skill1CoolDown;
    public int Skill1ChargeRate;

    private GameObject HUD;
    private Slider skill1Slider;
    private Slider skill1LevelSlider;
    private Text skill1LevelText;
    private AudioSource skillReadyAudioSource;

    private WaitForSeconds chargeDelay = new WaitForSeconds(1);

	// Use this for initialization
	void Start ()
    {
        Skills = new List<Skill>();

        Ball = GameObject.Find("Ball");

        multiBall = GameObject.Find("MultiBallSkill").GetComponent<MultiBall>();

        Skills.Add(multiBall);

        skillReadyAudioSource = GetComponent<AudioSource>();

        multiBall.IsSkillUsable = false;

        //FIND A BETTER WAY TO DO THIS
        HUD = GameObject.Find("HUD");
        skill1Slider = GameObject.Find("skill1Slider").GetComponent<Slider>();
        skill1LevelSlider = GameObject.Find("skill1LevelSlider").GetComponent<Slider>();
        skill1LevelText = skill1LevelSlider.GetComponentInChildren<Text>();
        SetUpCoolDown();
        StartCoroutine(RechargeSkill(skill1Slider));
        StartCoroutine(playNotificationSoundOnceCharged(multiBall));
    }

    private void SetUpCoolDown()
    {
        skill1Slider.maxValue = Skill1CoolDown;
    }

    // Update is called once per frame
    void Update ()
    {
        if (multiBall.IsSkillUsable && Input.GetButtonDown("Skill1"))
        {
            multiBall.UseSkill();
            resetSkill(multiBall);
            StartCoroutine(playNotificationSoundOnceCharged(multiBall));
            RechargeSkill(skill1Slider);
        }
        levelUpSkill(multiBall, skill1LevelSlider);
	}

    private void levelUpSkill(Skill skillToLevelUp, Slider skillExperienceBar)
    {
        skillExperienceBar.maxValue = skillToLevelUp.ExperiencePointsToLevelUp;
        skillExperienceBar.value = MultiBall.BaseExperiencePoints;

        if (MultiBall.BaseExperiencePoints >= skillToLevelUp.ExperiencePointsToLevelUp)
        {
            skillToLevelUp.LevelUp();
            MultiBall.Level += 1;
            MultiBall.BaseExperiencePoints = 0;
        }

        skill1LevelText.text = "Level " + MultiBall.Level.ToString();
    }

    private void resetSkill(Skill skillToReset)
    {
        skillToReset.IsSkillUsable = false;
        //REFACTOR ME
        skill1Slider.value = skill1Slider.minValue;
    }

    private IEnumerator RechargeSkill(Slider skillSlider)
    {
        while (true)
        {
            skillSlider.value += Skill1ChargeRate;
            if (skillSlider.value + Skill1ChargeRate > skillSlider.maxValue)
            {
                skillSlider.value = skillSlider.maxValue;
                multiBall.IsSkillUsable = true;
            }
            yield return chargeDelay;
        }
    }

    private IEnumerator playNotificationSoundOnceCharged(Skill skillForNotifying)
    {
        bool hasPlayed = skillForNotifying.IsSkillUsable;
        while (!hasPlayed)
        {
            yield return chargeDelay;
            if (skillForNotifying.IsSkillUsable)
            {
                hasPlayed = true;
            }
        }
        skillReadyAudioSource.Play();
    }

    public void AddExperience(int experienceToAdd)
    {
        
    }
}
