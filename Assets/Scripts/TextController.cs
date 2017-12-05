using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour {
	public ButtonController bNext;

	public string loadLevel;
	public string question = "This is the first question";
	public string[] answers = new string[3];
	public int correct = 0;
	public TextMesh[] fields; 

	// Use this for initialization
	void Start () {
		// bNext = GameObject.Find ("ButtonNext");
		GetComponent<TextMesh> ().text = question;

		for (int i = 0; i < answers.Length; i++) {
			fields [i].text = answers [i];
			fields [i].gameObject.name = "" + i;
		}
	}

	
	// Update is called once per frame
	void Update () {
		if (bNext.GetButtonPressed ()) {
			SceneManager.LoadScene (loadLevel);
		}
	}

	public void Answer(string name) {
		if (int.Parse (name) == correct) {
			//SceneManager.LoadScene(1);
			bNext.gameObject.SetActive (true);
			Debug.Log ("Oikein!");
		} else {
			Debug.Log ("Väärin!");

		}
	}

	//public void ChangeToScene (string sceneToChangeTo) {
		//SceneManager.LoadScene(sceneToChangeTo);
	//}
	/*void OnTrigger( )
	{
		if(guy.CompareTag ("Player"))
		{
			SceneManager.LoadScene (loadLevel);
		}
	}*/
}
