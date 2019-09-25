using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {
	[SerializeField] float lightAngle = 65f;
	[SerializeField] float lightIntensity = 5f;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			other.GetComponentInChildren<Flashlight>().RestoreAngle(lightAngle);
			other.GetComponentInChildren<Flashlight>().RestoreIntensity(lightIntensity);
			Destroy(gameObject);
		}
	}
}