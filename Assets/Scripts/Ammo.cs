using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
	// Shows each piece of information from the AmmoSlot class
	[SerializeField] AmmoSlot[] ammoSlots;

	// Makes class available to the inspector, and sends information to the AmmoSlot[] (array) to show ammoType && ammoAmount
	[System.Serializable]	private class AmmoSlot {
		public AmmoType ammoType;
		public int ammoAmount;
	}

	// public int GetCurrentAmmo() {
	// 	return ammoAmount;
	// }

	// public void ReduceCurrentAmmo() {
	// 	ammoAmount--;
	// }
}