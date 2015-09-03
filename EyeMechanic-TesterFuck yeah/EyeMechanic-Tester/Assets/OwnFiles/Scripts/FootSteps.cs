using UnityEngine;
using System.Collections;

public class FootSteps : MonoBehaviour {

	public GameObject audioParent;
	public float playDistance;
	float distance;
	Vector3 prevPos;

	void Start()
	{
		distance = 0;
		prevPos = transform.position;
	}

	void Update()
	{
		if (prevPos != transform.position)
			distance += Vector3.Distance (transform.position-new Vector3(0,transform.position.y,0), prevPos-new Vector3(0,prevPos.y,0));
		prevPos = transform.position;

		if (distance > playDistance) {
			AudioLord.Audio.Play (audioParent,transform.position,false,false);
			distance -= playDistance;
		}
	}
}
