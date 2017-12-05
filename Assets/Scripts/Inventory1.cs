using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory1 : MonoBehaviour {
	//built in unity array
	public GameObject[] inventory = new GameObject[6];
	public Button [] InventoryButtons = new Button[6];


	//Adds the item to inventory
	public void AddItem(GameObject item)
	{
		//item is not added jet
		bool itemAdded = false;

		//find the first open slot in the inventory (looping trough the array and check if
		//slot is empty)
		for (int i = 0; i < inventory.Length; i++) {
			if (inventory [i] == null) {
				inventory [i] = item;
				//Update UI
				InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
				Debug.Log (item.name + " was added");
				//item is added
				itemAdded = true;
				//Do something with an object
				item.SendMessage("DoInteraction");
				break;
			}
		}

		//Inventory full when looped trough the array.
		if (!itemAdded) {
			Debug.Log ("Inventory Full - Item Not Added");
		}
	}
	/// <summary>
	/// Finds the item.
	/// </summary>
	/// <returns><c>true</c>, if item was found, <c>false</c> otherwise.</returns>
	/// <param name="item">Item.</param>
	public bool FindItem(GameObject item)
	{
		for(int i = 0; i < inventory.Length; i++) {
			if (inventory [i] == item) {
				//we found the item
				return true;
			}
		}
		//if not found
		return false;
	}

	public GameObject FindItemByType(string itemType)
	{
		for (int i = 0; i < inventory.Length; i++) {
			if (inventory[i] != null){
				if(inventory[i].GetComponent <InteractionObjects>().itemType == itemType) {
					//we found item of the type we were looking for
					return inventory[i];
				}
			}
		}
		//item of type not found
		return null;
	}

	public void RemoveItem(GameObject item)
	{
		for (int i = 0; i < inventory.Length; i++) {
			if (inventory [i] == item) {
				//we found item -remove it
				inventory[i] = null;
				Debug.Log (item.name + " was removed from inventory");
				//Update UI
				InventoryButtons[i].image.overrideSprite = null;
				break;
			}
		}
	}
}
