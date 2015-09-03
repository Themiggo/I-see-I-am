using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class InteractionScript : MonoBehaviour {

	public Camera cam;
	public GameObject interactUI;
	int layerInteract = 1 << 9 | 1 << 10;
	public float interactRange;
	int layerWall = 1 << 8;

	void Update () {
		
		RaycastHit hitInfo;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hitInfo, interactRange, layerInteract)) {
			if (!Physics.Raycast (cam.transform.position, cam.transform.forward, hitInfo.distance, layerWall)) {
				Activateable act = hitInfo.collider.gameObject.GetComponent<Activateable>();
				if (act.canInteract)
				{	
					interactUI.SetActive(true);

					if (Input.GetMouseButtonDown(0))
					{
						act.Activate();
					}
				}
			} else {
				interactUI.SetActive(false);
			}
		} else {
			interactUI.SetActive(false);
		}
	}
}
