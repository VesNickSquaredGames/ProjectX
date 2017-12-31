using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoTouches : MonoBehaviour {

	// PUBLIC
	public Text leftText;
	public Text rightText;
	public SimpleTouchController leftController;
	public SimpleTouchController rightController;

	// PRIVATE
	void Start()
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	void Update()
	{
		if(leftText)
			leftText.text = "Left Touch:\n" +
				"x: " + leftController.GetTouchPosition.x + "\n" +
				"y: " + leftController.GetTouchPosition.y;
		if(rightText)
			rightText.text = "Left Touch:\n" +
				"x: " + rightController.GetTouchPosition.x + "\n" +
				"y: " + rightController.GetTouchPosition.y;
	}
}
