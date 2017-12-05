using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour {

	public int health;

	public void TakeDamage(int damage)
	{
		//when bullet hits zombie 
		//takes off health and check the helth
		//when health is less than 0 
		//game object will be destroyed
		health -= damage;
		if (health <= 0) {
			Destroy (gameObject);
		}
	}
}
