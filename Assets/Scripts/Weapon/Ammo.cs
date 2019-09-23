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

	public int GetCurrentAmmo(AmmoType ammoType) {
		return GetAmmoSlot(ammoType).ammoAmount;
	}

	public void ReduceCurrentAmmo(AmmoType ammoType) {
		GetAmmoSlot(ammoType).ammoAmount--;
	}

	private AmmoSlot GetAmmoSlot(AmmoType ammoType) {
		foreach(AmmoSlot slot in ammoSlots) {
			if (slot.ammoType == ammoType) {
				return slot;
			}
		}

		return null;
	}
}