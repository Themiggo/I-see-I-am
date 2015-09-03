using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioLord : MonoBehaviour {
	
	public static AudioLord Audio;
	MusicScript music;
	
	void Awake()
	{
		if (Audio == null)
			Audio = this;
		else
			Debug.LogError ("Multiple AudioLords");
	}
	
	public void Play(GameObject audioParent, Vector3 pos, bool loop)
	{
		GameObject aus = Instantiate<GameObject> (audioParent);
		
		AudioScript a = aus.GetComponent<AudioScript> ();
		aus.transform.position = pos;
		a.loop = loop;
		a.Play ();
	}
	
	public void Play(GameObject audioParent, Vector3 pos, bool loop, bool shuffle)
	{
		GameObject aus;
		
		if (audioParent.transform.childCount != 0) {
			if (shuffle)
			{
				int random = Random.Range (0, audioParent.transform.childCount - 1);
				aus = Instantiate<GameObject> (audioParent.transform.GetChild(random).gameObject);
			} else {
				aus = Instantiate<GameObject> (audioParent.transform.GetChild(0).gameObject);
				audioParent.transform.GetChild(0).transform.SetAsLastSibling();
			}	
		}
		else
			aus = Instantiate<GameObject> (audioParent);
		
		AudioScript a = aus.GetComponent<AudioScript> ();
		aus.transform.position = pos;
		a.loop = loop;
		a.Play ();
	}
	
	public void PlayBGM(GameObject audioParent, float fadeTime)
	{
		if (music != null && audioParent.GetComponent<AudioSource>().clip == music.GetComponent<AudioSource>().clip) return;
		
		GameObject aus = Instantiate<GameObject> (audioParent);
		aus.transform.SetParent(GameObject.Find ("MainCamera").transform);
		
		MusicScript m = aus.AddComponent<MusicScript> ();
		
		if (music != null) 
			music.Fade(true, fadeTime);
		
		m.Fade(false, fadeTime);
		music = m;
	}
}