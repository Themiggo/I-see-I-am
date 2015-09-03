using UnityEngine;
using System.Collections;

public class SecurityCameraScript : MonoBehaviour {

	GameObject player;

	void Start()
	{
		player = GameObject.Find ("MainCamera");
		transform.parent = null;
	}

	void Update () {
		var rotation = Quaternion.LookRotation (player.transform.position - transform.position);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, rotation, 35 * Time.deltaTime);
	}
}
