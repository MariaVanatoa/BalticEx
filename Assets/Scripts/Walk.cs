using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Walk : MonoBehaviour
{
	public float speed;
	public Animator anim;
	public GameObject bullet;
	public float bulletForce;
	public float health;

	public Text healthText;
	//connection to panel and message text
	public GameObject menuPanel;
	//change the menu panel text
	public Text messageText;



	void Start () {
		//display the health text
		healthText.text = "Health: " + health.ToString ();
		//At start - wait for to player to click the start button for starting the game
		//Time.timeScale = 0;
		//Make the mnu panel visible
		menuPanel.SetActive(false);
		Time.timeScale = 1f;
		//messageText.text ="Press Start to Begin";

	}

	// Use this for initialization

	void Update (){
	
		//horizontal movement (from input manager and find axis and return value)
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		//moving right
		if (horizontal > .01f) {
			// transform.rotation = Quaternion.Euler (0f, 0f, 90f);
		}
		//moving left
		if (horizontal > .01f) {
			// transform.rotation = Quaternion.Euler (0f, 0f, 270f);
		}
		//moving up
		if (vertical > .01f) {
			// transform.rotation = Quaternion.Euler (0f, 0f, 180f);
		}
		//moving down
		if (vertical > .01f) {
			// transform.rotation = Quaternion.Euler (0f, 0f, 0f);
		}

		//moving the transforms position
		transform.Translate (horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, 0f, Space.World);

		//tell the animator witch animation to play
		anim.SetFloat ("speed", Mathf.Abs (horizontal) + Mathf.Abs (vertical));

		if (Input.GetButtonDown ("Fire1")) {
			GameObject newBullet = Instantiate (bullet, transform.position, Quaternion.Euler(0, 0, -90));
			newBullet.GetComponent<Rigidbody2D>().AddRelativeForce (new Vector2(bulletForce,0f));
		}
	}
	/// <summary>
	/// Takes the damage.
	/// </summary>
	/// <param name="damage">Damage.</param>
	public void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0) {
			Debug.Log ("Dead");
			health = 0;
			//turn panel on
			menuPanel.SetActive (true);
			//new message
			messageText.text = "Game Over";
			//turn time off
			Time.timeScale = 0f;
		}
		healthText.text = "Health: " + health.ToString ();
	}

	public void StartButton()
	{
		//menuPanel.SetActive (false);
		//start time
		//Time.timeScale = 1f;

		//restart the game
		SceneManager.LoadScene(SceneManager.GetActiveScene ().name);
	}

	public void QuitButton ()
	{
		//dosent work in editor, only in the real game
		Application.Quit ();
		Debug.Log ("Quit Button has been Pressed");
	}
}
