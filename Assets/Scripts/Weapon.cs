using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	[SerializeField] Camera FPCam;
	[SerializeField] float range = 100f;

	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			Shoot();
		}
	}

	void Shoot() {
		RaycastHit hit;

		// (FromWhere, InWhatDirection, VariableToStoreRaycastHitPassedByReference, Range)
		Physics.Raycast(FPCam.transform.position, FPCam.transform.forward, out hit, range);

		print("We've hit a " + hit.transform.name);
	}
}