using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionObjects : MonoBehaviour {
	//On and off behavors
	public bool inventory; //if true this object can be stored in inventory
	public bool openable;  //if true object can be opened
	public bool locked;    //if this is true then object is locked
	public bool talks;   //if this is true then object can talk to player
	public string itemType;  //this will tell what type of item this object is

	public bool changeScene;
	public string sceneToChange;

	public GameObject itemNeeded;  //item needed in order to interact with this item
	public string message;   //the message this object will give player 
	public Text hintText;
	public Animator anim;


	void Start()
	{
		hintText.text = "Hint: " + message.ToString ();
	}

	//turns game object of when interacted
	public void DoInteraction()
	{
		//Picked up and put in inventory
		gameObject.SetActive(false);
	}

	//open door animator
	public void Open()
	{
		anim.SetBool ("open", true);
	}

	/// <summary>
	/// Talk this instance.
	/// </summary>
	public void Talk()
	{
		Debug.Log (message);
		hintText.text = "Hint: " + message.ToString ();
	}

	//
	public void ChangeSCene()
	{
		SceneManager.LoadScene (sceneToChange);
	}
}

