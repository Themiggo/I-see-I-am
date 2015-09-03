using UnityEngine;
using System.Collections;

public class LeverFlip : Activateable {

	Quaternion targetRotation;

	void Awake()
	{
		targetRotation = Quaternion.Euler (30.0f, transform.localRotation.y, transform.localRotation.z);
	}

	public override void Activate()
	{
		targetRotation = Quaternion.Euler (150.0f, transform.localRotation.y, transform.localRotation.z);
	}

	void Update()
	{
		if (Mathf.Abs(Quaternion.Angle (transform.localRotation,targetRotation)) > 3*Time.deltaTime)
			transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotation, Time.deltaTime * 3);
		else
			transform.localRotation = targetRotation;
	}
}
