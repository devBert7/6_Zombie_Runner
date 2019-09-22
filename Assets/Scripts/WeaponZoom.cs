using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour {
	[SerializeField] float zoomIn = 20f;
	[SerializeField] float zoomOut = 60f;
	[SerializeField] float zoomInSens = .5f;
	[SerializeField] float zoomOutSens = 2f;
	[SerializeField] RigidbodyFirstPersonController fpsController;

	bool isZoomed = false;

	void Update() {
		if (Input.GetMouseButtonDown(1)) {
			HandleZoom();
		}
	}

	void HandleZoom() {
		if (isZoomed) {
			Camera.main.fieldOfView = zoomOut;
			fpsController.mouseLook.XSensitivity = zoomOutSens;
			fpsController.mouseLook.YSensitivity = zoomOutSens;
		} else {
			Camera.main.fieldOfView = zoomIn;
			fpsController.mouseLook.XSensitivity = zoomInSens;
			fpsController.mouseLook.YSensitivity = zoomInSens;
		}

		isZoomed = !isZoomed;
	}
}