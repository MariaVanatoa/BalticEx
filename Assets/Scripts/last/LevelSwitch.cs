using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour {
	/// <summary>
	/// The load level.
	/// </summary>
	public string loadLevel;

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D guy)
	{
		if(guy.CompareTag ("Player"))
		{
			SceneManager.LoadScene (loadLevel);
		}
	}
}
