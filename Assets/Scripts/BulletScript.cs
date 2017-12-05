﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	
	public int damage;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag ("Player")) {
			other.SendMessage ("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
			//removes bullet
			Destroy (gameObject);
		}
	}
}
