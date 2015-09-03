using UnityEngine;
using System.Collections;

public class EnablerScript : MonoBehaviour {

	public GameObject enabledEye;

	// Use this for initialization
	void Start () {
		enabledEye.SetActive (false);
	}

	void OnTriggerEnter(Collider c)
	{
		enabledEye.SetActive (true);
		Destroy (this.gameObject);
	}
}
