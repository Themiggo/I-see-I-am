using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

	float vol = 1.0f;
	bool fadingOut;
	float fadeMax = -1.0f;
	float fade = 0.0f;
	AudioSource a;

	void Start()
	{
		
		a = GetComponent<AudioSource> ();
		vol = a.volume;
		a.volume = 0.0f;
		a.Play ();
	}
	
	void Update()
	{
		if (fadeMax >= 0) {
			if (fadingOut){
				fade = Mathf.Max(fade-Time.deltaTime,0.0f);

				if (fade == 0)
					Destroy (this.gameObject);
			}else{
				fade = Mathf.Min(fade+Time.deltaTime,fadeMax);
			}
		}
		a.volume = vol * fade/fadeMax;
	}

	public void Fade(bool fadeOut, float fadeTimer)
	{
		fadingOut = fadeOut;
		fadeMax = fadeTimer;
	}
}
