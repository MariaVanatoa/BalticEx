using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	public GameObject quest;
	public GameObject canvas;

		//Use this for initialization
		void Start ()
		{
		

		}

		void OnTriggerEnter2D(Collider2D guy)
		{
			if (guy.CompareTag("Player")) {
				quest.SetActive (true);
				canvas.SetActive (true);
			}
		}
	}