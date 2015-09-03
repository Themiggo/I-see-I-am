using UnityEngine;
using System.Collections;

public class PinActivatorScript : Activateable {

	public GameObject pinCode;

	public override void Activate() {
		Time.timeScale = 0.0f;
		pinCode.SetActive(true);
		Cursor.visible = true;
		GameObject.Find("InteractImage").SetActive(false);
		gameObject.layer = 0;
		pinCode.GetComponent<PinUseScript>().activator = this.gameObject;
	}
}
