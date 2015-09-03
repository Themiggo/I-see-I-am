using UnityEngine;
using System.Collections;

public class DoubleDoorScript : Activateable {

	public bool onlyOnce;

	public override void Activate() {
			foreach (DoorScript inter in GetComponentsInChildren<DoorScript> (false)) {
			inter.Activate ();
			if (inter.doorMode == DoorScript.Mode.Locked) {
				return;
			}
		}

		if (onlyOnce)
			Destroy(GetComponent<BoxCollider>());
	}
}
