using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMoveController : MonoBehaviour {

	// PUBLIC
	public SimpleTouchController leftController;
	public SimpleTouchController rightController;
	public float speedMovements = 1000f;
	public float speedContinuousLook = 100f;
	public float speedProgressiveLook = 3000f;
	public bool continuousRightController = true;

	// PRIVATE
	private Rigidbody _rigidbody;
	private Vector3 localEulRot;
	private Vector2 prevRightTouchPos;

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		rightController.TouchEvent += RightController_TouchEvent;
		rightController.TouchStateEvent += RightController_TouchStateEvent;
	}

	public bool ContinuousRightController
	{
		set{continuousRightController = value;}
	}

	void RightController_TouchStateEvent (bool touchPresent)
	{
		if(!continuousRightController)
		{
			prevRightTouchPos = Vector2.zero;
		}
	}

	void RightController_TouchEvent (Vector2 value)
	{
		if(!continuousRightController)
		{
			Vector2 deltaValues = value - prevRightTouchPos;
			prevRightTouchPos = value;

			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x - deltaValues.y * Time.deltaTime * speedProgressiveLook,
				transform.localEulerAngles.y + deltaValues.x * Time.deltaTime * speedProgressiveLook,
				0f);
		}
	}

	void Update()
	{
		Vector3 pos = transform.position;
		//Quaternion rot = transform.rotation;
		pos.x = pos.x + leftController.GetTouchPosition.x * Time.deltaTime * speedMovements;
		pos.y = pos.y + leftController.GetTouchPosition.y * Time.deltaTime * speedMovements;

		///rot.z = rot.z + rightController.GetTouchPosition.x * Time.deltaTime * speedMovements;
		///rot.z = rot.z + rightController.GetTouchPosition.y * Time.deltaTime * speedMovements;
		transform.position = pos;
		//ransform.rotation = rot;


	}

	void OnDestroy()
	{
		rightController.TouchEvent -= RightController_TouchEvent;
		rightController.TouchStateEvent -= RightController_TouchStateEvent;
	}

}
