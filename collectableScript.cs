using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableScript : MonoBehaviour
{
    private AudioSource source;
	public AudioClip collectSound;
	private bool isCollected = false;
	//private float waitToDestroyTime = 3.0f;
	private Renderer rend;
	public bool hasParticleEffect = false;
	public GameObject particleEffect;
	private GameMaster2 lm;
	
	// Use this for initialization
	void Start () 
	{
		lm = GameObject.Find("LevelManager").GetComponent<GameMaster2>();
		source = GetComponent<AudioSource>();
		rend = GetComponent<Renderer>();
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.CompareTag("Player") && !isCollected)
		{
			source.PlayOneShot(collectSound);
			isCollected = true;
			rend.enabled = false;
			lm.CupCollected();
			if(hasParticleEffect)
			{
				Destroy(particleEffect);
			}
			Destroy(this.gameObject);
        }
	}
	
}
