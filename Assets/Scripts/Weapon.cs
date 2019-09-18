﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	[SerializeField] Camera FPCam;
	[SerializeField] float range = 100f;
	[SerializeField] float weaponPower = 20f;
	[SerializeField] ParticleSystem MuzzleFlash;

	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			Shoot();
		}
	}

	void Shoot() {
		PlayMuzzleFlash();
		ProcessRaycast();
	}

	void PlayMuzzleFlash() {
		MuzzleFlash.Play();
	}

	void ProcessRaycast() {
		RaycastHit hit;

		// (FromWhere, InWhatDirection, VariableToStoreRaycastHitPassedByReference, DynamicRangeVariable)
		if (Physics.Raycast(FPCam.transform.position, FPCam.transform.forward, out hit, range)) {
			print("We've hit a " + hit.transform.name);

			// todo: add visual fx to hit

			EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
			if (target == null) {
				return;
			}
			target.TakeDamage(weaponPower);
		} else {
			return;
		}
	}
}