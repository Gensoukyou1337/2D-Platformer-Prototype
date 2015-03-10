using UnityEngine;
using System.Collections;

public class DestroyParticleEffect : MonoBehaviour {
	private ParticleSystem thisParticleSystem;

	// Use this for initialization
	void Start ()
	{
		thisParticleSystem = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (thisParticleSystem.isStopped) {
			Destroy (gameObject);
		}
		else
		{
			return;
		}
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
