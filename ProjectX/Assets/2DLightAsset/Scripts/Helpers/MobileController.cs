using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour {

	GameObject cLight;
	GameObject cubeL;

	private Vector2 touchOrigin = -Vector2.one; //Used to store location of screen touch origin for mobile controls.

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int horizontal = 0;     //Used to store the horizontal move direction.
		int vertical = 0;       //Used to store the vertical move direction.
		//Check if Input has registered more than zero touches
		if (Input.touchCount > 0)
		{
			//Store the first touch detected.
			Touch myTouch = Input.touches[0];

			//Check if the phase of that touch equals Began
			if (myTouch.phase == TouchPhase.Began)
			{
				//If so, set touchOrigin to the position of that touch
				touchOrigin = myTouch.position;
				Vector3 pos = cLight.transform.position;
				//horizontal = x > 0 ? 1 : -1;
				//vertical = y > 0 ? 1 : -1;
				pos.x += horizontal * 30f * Time.deltaTime;
				pos.y += vertical * 30f * Time.deltaTime;
			}
		}

	}
}