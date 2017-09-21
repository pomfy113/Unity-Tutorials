using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text countText;
	public Text winText;
	public float speed = 10;
	private int count;
	private Rigidbody2D rb2d;

	void Start(){
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		winText.text = " ";
		setCountText ();
	}

	// Use this for initialization
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			other.gameObject.SetActive (false);
			count += 1;
			setCountText ();
		}
	}

	void setCountText(){
		countText.text = "Points: " + count.ToString();
		if (count >= 8) {
			winText.text = "You win!";
		}
	}
}