using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private int count;
	private int numberOfCollectables;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		numberOfCollectables = 12;
	}
	
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("collectable"))
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}
	void SetCountText () 
	{
		countText.text = "Count: " + count.ToString ();
		//FINISHME
		if (count >= numberOfCollectables) 
		{
			winText.text = "You WIN!";
		}

	}
}
