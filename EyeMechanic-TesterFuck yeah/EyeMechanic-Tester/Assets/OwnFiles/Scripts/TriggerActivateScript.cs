using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TriggerActivateScript : MonoBehaviour {
	
	public bool onlyOnce;
	public bool isEnter;

	void OnTriggerExit(Collider c)
	{
		if (!isEnter) {
			ActivateAll();
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if (isEnter) {
			ActivateAll();
		}
	}

	void ActivateAll()
	{
		foreach(Activateable a in GetComponents<Activateable> ())
			a.Activate();
		
		if (onlyOnce) {
			Destroy(this);
			Destroy (GetComponent<BoxCollider>());
		}
	}
}
