using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

	[HideInInspector]
	public bool loop;
	float dieTimer;
	bool canDie;
	public float pitchUpperRange;

	void Start()
	{
		dieTimer = GetComponent<AudioSource>().clip.length;
	}

	void Update () {
		if (canDie) {
			dieTimer -= Time.deltaTime;

			if (dieTimer <= 0)
				Destroy (this.gameObject);
		}
	}

	public void Play()
	{
		AudioSource a = GetComponent<AudioSource> ();
		if (pitchUpperRange != 0)
			a.pitch = a.pitch + Random.Range (0.0f, pitchUpperRange);
		a.loop = loop;
		a.Play();
		if (!loop)
			canDie = true;
	}
}
