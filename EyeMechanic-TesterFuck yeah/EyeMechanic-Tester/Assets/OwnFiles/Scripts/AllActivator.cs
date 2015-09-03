using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllActivator : Activateable {

	public List<Activateable> aList = new List<Activateable>();
	public bool onlyOnce;

	public override void Activate()
	{
		ActivateAll ();
	}

	public void ActivateAll()
	{
		foreach(Activateable a in aList)
			a.Activate();
		
		if (onlyOnce) {
			Destroy(this);
			Destroy (GetComponent<BoxCollider>());
		}
	}
}
