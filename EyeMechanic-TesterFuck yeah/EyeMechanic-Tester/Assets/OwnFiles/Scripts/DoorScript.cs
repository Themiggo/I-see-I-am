using UnityEngine;
using System.Collections;

public class DoorScript : Activateable {
	public bool open;
	public float openAngle;
	[HideInInspector]
	public float closedAngle;
	public float openSpeed;
	[HideInInspector]
	public bool canMove = true;
	Quaternion doorTarget;
	public enum Mode {Unlocked, Locked, Unlockable};
	public Mode doorMode;

	public override void Activate() {
		if (doorMode != Mode.Locked)
			open = !open;

		if (doorMode == Mode.Unlockable) {
			doorMode = Mode.Unlocked;
		}

		ChangeTarget ();
	}

	void Awake()
	{
		closedAngle = transform.localRotation.eulerAngles.y;

		if (open) {
			transform.localRotation = Quaternion.Euler (transform.localRotation.x, openAngle, transform.localRotation.z);
			doorTarget = Quaternion.Euler (transform.localRotation.x, openAngle, transform.localRotation.z);
		} else {
			transform.localRotation = Quaternion.Euler (transform.localRotation.x, closedAngle, transform.localRotation.z);
			doorTarget = Quaternion.Euler (transform.localRotation.x, closedAngle, transform.localRotation.z);
		}
	}
	
	void ChangeTarget()
	{
		if (open) {
			doorTarget = Quaternion.Euler (transform.localRotation.x, openAngle, transform.localRotation.z);
		} else {
			doorTarget = Quaternion.Euler (transform.localRotation.x, closedAngle, transform.localRotation.z);
		}
	}

	void Update () {
		if (canMove)
			if (Mathf.Abs(Quaternion.Angle (transform.localRotation,doorTarget)) > openSpeed*Time.deltaTime)
				transform.localRotation = Quaternion.Slerp (transform.localRotation, doorTarget, Time.deltaTime * openSpeed);
			else
				transform.localRotation = doorTarget;
	}
}