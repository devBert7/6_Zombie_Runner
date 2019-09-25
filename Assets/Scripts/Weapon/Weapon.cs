using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour {
	[SerializeField] Camera FPCam;
	[SerializeField] float range = 100f;
	[SerializeField] float weaponPower = 20f;
	[SerializeField] ParticleSystem muzzleFlash;
	[SerializeField] GameObject hitImpact;
	[SerializeField] Ammo ammoSlot;
	[SerializeField] AmmoType ammoType;
	[SerializeField] float shootPeriod = 1f;
	[SerializeField] TextMeshProUGUI ammoText;

	bool canShoot = true;

	void OnEnable() {
		if (!canShoot) {
			Invoke("WaitToShoot", shootPeriod);
		}
	}

	void WaitToShoot() {
		canShoot = true;
	}

	void Update() {
		if (Input.GetMouseButtonDown(0) && canShoot) {
			StartCoroutine(Shoot());
		}

		DisplayAmmo();
	}

	void DisplayAmmo() {
		int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
		ammoText.text = currentAmmo.ToString();
	}

	IEnumerator Shoot() {
		canShoot = false;

		if (ammoSlot.GetCurrentAmmo(ammoType) > 0) {
			PlayMuzzleFlash();
			ProcessRaycast();
			ammoSlot.ReduceCurrentAmmo(ammoType);
		}

		yield return new WaitForSeconds(shootPeriod);
		canShoot = true;
	}

	void PlayMuzzleFlash() {
		muzzleFlash.Play();
	}

	void ProcessRaycast() {
		RaycastHit hit;

		// (FromWhere, InWhatDirection, VariableToStoreRaycastHitPassedByReference, DynamicRangeVariable)
		if (Physics.Raycast(FPCam.transform.position, FPCam.transform.forward, out hit, range)) {
			CreateHitImpact(hit);

			EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

			if (target == null) {
				return;
			}
			
			target.TakeDamage(weaponPower);
		} else {
			return;
		}
	}

	void CreateHitImpact(RaycastHit hit) {
		GameObject impact = Instantiate(hitImpact, hit.point, Quaternion.LookRotation(hit.normal));
		Destroy(impact, .1f);
	}
}