using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
	{
		private List<GameItem> inventory = new List<GameItem>();

	public  Player ()
		{

		}
		//TODO: AddItem method, GetItems method
		public void AddItem(GameItem item) {
			inventory.Add (item);
		}

	public string GetItems(){
			string temp = "";
			foreach (GameItem gi in inventory) {
				temp += gi.GameItemName () + ", ";
			}
			return temp;
		}
		public void ShowInv(){
			string temp = "";
			foreach (GameItem gi in inventory) {
				temp += gi.GameItemName () + ", ";
			}
			Debug.Log (temp);
		}

	}
