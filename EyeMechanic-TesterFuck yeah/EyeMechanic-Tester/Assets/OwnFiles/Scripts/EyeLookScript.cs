using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class EyeLookScript: MonoBehaviour {

	public Transform target;
	public int turningSpeed = 15;
	public float dieTimerMax = 5.0f;
	public bool dieAfterBreak = false;
	public float delayTimerMax;
	float delayTimer;
	bool isStaring = false;
	int blockLayer = 1 << 8 | 1 << 9;
	float dieTimer;
	Transform ml;

	void Start () {
	
	}

	void Update () {
		if (target != null)
		{
			ml = target.GetComponent<RigidbodyFirstPersonController>().EyeStare;
			if (!Physics.Raycast (transform.position, target.position-transform.position, Vector3.Distance(target.position, transform.position), blockLayer)) {
				if (delayTimer > delayTimerMax)
				{
					if (ml == null && !isStaring)
					{
						RigidbodyFirstPersonController fps = target.GetComponent<RigidbodyFirstPersonController>();

						isStaring = true;
						fps.EyeStare = this.transform;
						fps.freezeTimer = fps.freezeTimerMax;
						target.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
						ml = this.transform;
					}
				}
				else
					delayTimer += Time.deltaTime;
			}
			else
			{
				if (ml == this.transform && isStaring)
				{
					isStaring = false;
					target.GetComponent<RigidbodyFirstPersonController>().EyeStare = null;
					ml = null;
					dieTimer = 0;

					if (dieAfterBreak)
						Destroy(this.gameObject);
				}
				
				delayTimer = 0.0f;
			}
		}	

		if (isStaring) {
			transform.LookAt (target.GetChild (0).transform.position);
			dieTimer += 1*Time.deltaTime;

			if (dieTimer > dieTimerMax)
			{
				target.GetChild(0).GetComponent<Camera>().fieldOfView -= 120*Time.deltaTime;

				if (target.GetChild(0).GetComponent<Camera>().fieldOfView < 0)
					Debug.LogError("You ded");
			}
		}
	}
}
