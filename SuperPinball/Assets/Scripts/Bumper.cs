using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bumper : MonoBehaviour
{
    [SerializeField]
    private float explosionStrength = 100;
    [SerializeField]
    private float explosionRadius = 5;
    [SerializeField]
    private int scoreValue = 5;

    private GameManager gameManager;
    private SkillManager skillManager;
    private AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
        collision.rigidbody.AddExplosionForce(explosionStrength, this.transform.position, explosionRadius);
        gameManager.UpdateScore(scoreValue);

        foreach (Skill skill in skillManager.Skills)
        {
            if (skill.IsSkillActive)
            {
                skill.AddExperience(scoreValue);
            }
        }
    }
}
