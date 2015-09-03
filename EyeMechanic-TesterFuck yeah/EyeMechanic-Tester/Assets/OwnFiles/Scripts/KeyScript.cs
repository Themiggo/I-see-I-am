using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyScript : Activateable {

	public List<GameObject> gameObjects = new List<GameObject>();

	void Start()
	{
		foreach (GameObject go in gameObjects) {
			go.GetComponent<DoorScript>().doorMode = DoorScript.Mode.Locked;
		}
	}

	public override void Activate() {
		foreach (GameObject go in gameObjects) {
			DoorScript ds = go.GetComponent<DoorScript>();
			if (ds.doorMode == DoorScript.Mode.Locked)
				ds.doorMode = DoorScript.Mode.Unlockable;
		}
		Destroy (this.gameObject);
	}
}