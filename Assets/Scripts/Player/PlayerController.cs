using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	[Header("Camera")]
	public Vector3 CameraOffset;

	[Header("Movement Speed")]
	public float MaxMovementSpeed = 1f;
	public float MovementAcceleration = 0.01f;
	public float DefaultMovementDeceleration = 0.005f;
	public float ForcedMovementDeceleration = 0.02f;

	[Header("Rotation Speed")]
	public float MaxRotationSpeed = 1f;
	public float RotationAcceleration = 0.01f;
	public float DefaultRotationDeceleration = 0.005f;

	[Header("Rotation Tilting")]
	public Transform ObjectToTilt;
	public float TiltSpeed = 1f;
	public float MaxTilt = 35f;

	// Player Movement
	private Vector3 m_Directions = Vector3.zero;
	private float m_Speed = 0;
	private float m_Rotation = 0;

	// Use this for initialization
	private void Start () 
	{
		
	}
	
	// Update is called once per frame
	private void Update ()
	{
		UpdateDirections();
		UpdateSpeed();
		UpdateRotation();

		transform.position += transform.forward * m_Speed;
		transform.eulerAngles = new Vector3(
			transform.eulerAngles.x,
			transform.eulerAngles.y + m_Rotation,
			transform.eulerAngles.z
		);

		ObjectToTilt.localEulerAngles = new Vector3(
			0,
			0,
			-Mathf.Clamp(m_Rotation * TiltSpeed, -MaxTilt, MaxTilt)
		);
	}

	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		Camera.main.transform.position = transform.TransformPoint(CameraOffset);
		Camera.main.transform.LookAt(transform);
	}

	private void UpdateDirections()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			m_Directions.z = 1;
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			m_Directions.z = -1;
		}

		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			m_Directions.x = -1;
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			m_Directions.x = 1;
		}
	}


	private void UpdateSpeed()
	{
		if (m_Directions.z == 0)
			m_Speed = Mathf.Max(0, m_Speed - DefaultMovementDeceleration * Time.deltaTime);
		else if (m_Directions.z == 1)
			m_Speed = Mathf.Min(MaxMovementSpeed, m_Speed + MovementAcceleration * Time.deltaTime);
		else if (m_Directions.z == -1)
			m_Speed = Mathf.Max(0, m_Speed - ForcedMovementDeceleration * Time.deltaTime);
	}
	 
	private void UpdateRotation()
	{
		
		if (m_Directions.x == 0 && m_Rotation != 0) {
			// DO NOTHING
		}
		else if (m_Directions.x == 1) {
			m_Rotation = Mathf.Min(MaxRotationSpeed, m_Rotation + RotationAcceleration * Time.deltaTime);
		}
		else if (m_Directions.x == -1) {
			m_Rotation = Mathf.Max(-MaxRotationSpeed, m_Rotation - RotationAcceleration * Time.deltaTime);
		}

	}

}
