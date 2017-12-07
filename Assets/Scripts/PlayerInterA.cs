using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterA : MonoBehaviour {

	public GameObject currentInterObj = null;
	public InteractionObjects currentInterObjScript = null;
	public Inventory1 inventory;

	BoxCollider2D m_ObjectCollider;

	void Start()
	{
		m_ObjectCollider = GetComponent<BoxCollider2D> ();
	}

	//when item in range and e button pressed
	void Update()
	{
		if(Input.GetButtonDown("Interact") && currentInterObj) {
			
			//Check to see if this item is to be added in inventory
			if (currentInterObjScript.inventory) {
				//sends it to inventory script and add to inventory
				inventory.AddItem (currentInterObj);
			}

			//check to see if this object can be opened
			if (currentInterObjScript.openable) {
				

				//check to see if object is locked
				if (currentInterObjScript.locked) {

					//check to see if we have object needed to unlock
					//search inventory for the item needed. if found unlock object
					if (inventory.FindItem (currentInterObjScript.itemNeeded)) {
						//we found the item needed
						currentInterObjScript.locked = false;

						currentInterObjScript.changeScene = true;
						Debug.Log (currentInterObj.name + "Was unlocked");
						currentInterObjScript.ChangeSCene();
						m_ObjectCollider.isTrigger = true;
					} else {
						Debug.Log (currentInterObj.name + "was not unlocked");
					}	
				} else {
					//object is not locked- open the object
					Debug.Log (currentInterObj.name + "is unlocked");
					//this.GetComponent<BoxCollider2D>().enabled = false; 
					//call open door animator method
					//currentInterObjScript.Open ();




				}
			}

			//chek to see if this object talks and has a message
			if (currentInterObjScript.talks) {
				//tell the object to give its message
				currentInterObjScript.Talk();
			}
		}
		//use a Potion
		if(Input.GetButtonDown ("Use Potion")) {
			//Check the inventory for a potion
			GameObject potion = inventory.FindItemByType ("Health Potion");
			if(potion != null){
				//use the potion- apply effect
				//remove the potion from inventory
				inventory.RemoveItem(potion);

			}
		}
	}

	//store info object that Player collides
	//reach into current item and store the script (saves time)
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("InteractiveObj")) {
			Debug.Log(other.name);
			currentInterObj = other.gameObject;
			currentInterObjScript = currentInterObj.GetComponent <InteractionObjects> ();
		}
	}

	//When you walk out of range of object . current = null
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag ("InteractiveObj")) {
			if (other.gameObject == currentInterObj) {
				currentInterObj = null;
			}
		}
	}
}
