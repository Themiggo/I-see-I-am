using UnityEngine;
using System.Collections;

public class MusicTrigger : MonoBehaviour {

	public GameObject music;
	public float fadeAmount;


	void OnTriggerEnter(Collider c)
	{
		AudioLord.Audio.PlayBGM (music, fadeAmount);
	}
}
