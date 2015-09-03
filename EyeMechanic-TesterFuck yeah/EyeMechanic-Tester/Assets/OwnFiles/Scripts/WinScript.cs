using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {

	void OnTriggerEnter(Collider c)
	{
		Debug.LogError ("You Winnered!");
	}
}
