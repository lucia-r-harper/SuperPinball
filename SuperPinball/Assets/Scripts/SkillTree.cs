using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Handles UI for Skills and the "leveling up system
/// </summary>
public class SkillTree : MonoBehaviour
{
    public List<Skill> Skills = new List<Skill>();

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void createHUD()
    {
        foreach (Skill skill in Skills)
        {
            //Instantiate()
        }
    }
}
