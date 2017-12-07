using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoPanel : MonoBehaviour {
	


	//Loads scene by index
	public void NextScene(int SceneIndex)
	{
		SceneManager.LoadScene (SceneIndex);
	}
}
