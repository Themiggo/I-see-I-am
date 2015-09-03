using UnityEngine;
using System.Collections;

public class DoorCanMoveScript : MonoBehaviour {

	DoorScript ds;
	bool openCheck;

	void Start()
	{
		ds = transform.parent.GetComponent<DoorScript> ();
		openCheck = ds.open;

		if ((ds.openAngle > ds.closedAngle) != openCheck) {
			foreach (BoxCollider c in GetComponents<BoxCollider>())
			{
				c.enabled = !c.enabled;
			}
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Player")
			ds.canMove = false;
	}

	void OnTriggerExit(Collider c)
	{
		if (c.gameObject.tag == "Player")
			ds.canMove = true;
	}

	void Update()
	{
		if (ds.open != openCheck) {
			openCheck = ds.open;
			ds.canMove = true;

			foreach (BoxCollider c in GetComponents<BoxCollider>())
			{
				c.enabled = !c.enabled;
			}
		}
	}
}
