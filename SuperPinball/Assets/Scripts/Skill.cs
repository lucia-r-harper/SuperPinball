using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public static int BaseExperiencePoints = 0;
    public static int Level = 1;
    public int ExperiencePointsToLevelUp = 75;

    private WaitForSeconds skillRechargeDelay = new WaitForSeconds(1);

    /// <summary>
    /// Is the skill in use?
    /// </summary>
    public bool IsSkillActive = false;

    /// <summary>
    /// Can the skill be used?
    /// </summary>
    public bool IsSkillUsable = false;

    private float levelScaleRate = 1.5f;

    public int chargeToUseSkill = 50;
    public int rechargerate = 10;
    public int currentCharge = 0;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Recharge());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private IEnumerator Recharge()
    {
        while (true)
        {
            currentCharge += rechargerate;
            if (currentCharge + rechargerate > chargeToUseSkill)
            {
                currentCharge = chargeToUseSkill;
                IsSkillUsable = true;
            }
            yield return skillRechargeDelay;
        }
    }

    public virtual void UseSkill()
    {
        IsSkillActive = true;
    }

    public virtual void LevelUp()
    {
        //changes required experience to level Up
        ExperiencePointsToLevelUp = Mathf.RoundToInt(ExperiencePointsToLevelUp * levelScaleRate);

        //open dialogue here
    }

    public virtual void AddExperience(int experienceToAdd)
    {
        BaseExperiencePoints += experienceToAdd;
    }
}
