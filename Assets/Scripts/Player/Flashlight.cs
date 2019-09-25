using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
	[SerializeField] float lightDecay = .1f;
	[SerializeField] float angleDecay = 1f;
	[SerializeField] float minAngle = 40f;
	[SerializeField] float minIntensity = 1.5f;

	Light myLight;

	void Start() {
		myLight = GetComponent<Light>();
	}

	void Update() {
		DecreaseAngle();
		DecreaseIntensity();
	}

	void DecreaseAngle() {
		if (myLight.spotAngle >= minAngle) {
			myLight.spotAngle -= angleDecay * Time.deltaTime;
		}
	}

	void DecreaseIntensity() {
		if (myLight.intensity <= minIntensity) {
			myLight.intensity = 0;
		} else {
			myLight.intensity -= lightDecay * Time.deltaTime;
		}
	}
}