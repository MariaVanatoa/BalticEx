using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextQuestion : MonoBehaviour {

	public TextController controller;

	void OnMouseDown() {
		controller.Answer (gameObject.name);
	}
}
