using UnityEngine;
using System.Collections;

public class PinUseScript : MonoBehaviour {

	string currentCode = "";
	public string correctCode = "";
	[HideInInspector]
	public GameObject activator;
	public Activateable toActivate;

	public void InsertPin (string pin)
	{
		currentCode += pin;

		if (currentCode.Length == correctCode.Length) {
			if (currentCode == correctCode)
			{
				toActivate.Activate ();
				ExitPin ();
			}

			currentCode = "";
		}
	}

	void Update() {
		if (Input.GetKey (KeyCode.Escape) || Input.GetMouseButton (1)) {
			ExitPin();
		}
	}

	void ExitPin()
	{
		activator.layer = 10;
		currentCode = "";
		gameObject.SetActive(false);
		Time.timeScale = 1;
	}
}
