using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public static int BaseExperiencePoints = 0;
    public static int Level = 1;
    public int ExperiencePointsToLevelUp = 75;

    /// <summary>
    /// Is the skill in use?
    /// </summary>
    public bool IsSkillActive = false;

    /// <summary>
    /// Can the skill be used?
    /// </summary>
    public bool IsSkillUsable = false;

    private float levelScaleRate = 1.5f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public virtual void UseSkill()
    {
        IsSkillActive = true;
    }

    public virtual void LevelUp()
    {
        //changes required experience to level Up
        ExperiencePointsToLevelUp = Mathf.RoundToInt(ExperiencePointsToLevelUp * levelScaleRate);
    }

    public virtual void AddExperience(int experienceToAdd)
    {
        BaseExperiencePoints += experienceToAdd;
    }
}
