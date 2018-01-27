using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour 
{
	[Header("Camera")]
	[SerializeField]private Vector3 CameraOffset;
	[SerializeField]private Vector3 CameraTargetOffset;

	[Header("SonarFX")]
	[SerializeField]private SonarFx SonarFx;
	public float WaveDuration = 5f;

	[Header("Movement Speed")]
	[SerializeField]private float MaxMovementSpeed = 1f;
	[SerializeField]private float MovementAcceleration = 0.01f;
	[SerializeField]private float DefaultMovementDeceleration = 0.005f;
	[SerializeField]private float ForcedMovementDeceleration = 0.02f;

	[Header("Rotation Speed")]
	[SerializeField]private float MaxRotationSpeed = 1f;
	[SerializeField]private float RotationAcceleration = 0.01f;
	[SerializeField]private float DefaultRotationDeceleration = 0.005f;

	[Header("Rotation Tilting")]
	[SerializeField]private Transform ObjectToTilt;
	[SerializeField]private float TiltSpeed = 1f;
	[SerializeField]private float MaxTilt = 35f;

	// Player Movement
	[HideInInspector]
	public float Speed {get; private set;}
	private Vector3 m_Directions = Vector3.zero;
	private float m_Rotation = 0;

	private SphereCollider m_Collider;

	// Use this for initialization
	private void Start () 
	{
		Speed = 0;
		m_Collider = GetComponentInChildren<SphereCollider>();
	}
	
	// Update is called once per frame
	private void Update ()
	{
		UpdateDirections();
		UpdateSpeed();
		UpdateRotation();
	}

	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		Camera.main.transform.position = transform.TransformPoint(CameraOffset);
		Camera.main.transform.LookAt(transform.position + CameraTargetOffset);
	}

	private void UpdateDirections()
	{
		if (Input.GetKey(KeyCode.UpArrow)) {
			m_Directions.z = 1;
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			m_Directions.z = -1;
		} else {
			m_Directions.z = 0;
		}

		if(Input.GetKey(KeyCode.LeftArrow)) {
			m_Directions.x = -1;
		}
		else if(Input.GetKey(KeyCode.RightArrow)) {
			m_Directions.x = 1;
		} else {
			m_Directions.x = 0;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			ActivateSonar ();
		}
		
	}

	private void ActivateSonar()
	{
		SonarFx.origin = transform.position;
		SonarFx.Launch (WaveDuration);
		m_Collider.radius = 0;
		DOTween.To(()=> m_Collider.radius, x=> m_Collider.radius = x, 3f, WaveDuration);
	}


	private void UpdateSpeed()
	{
		if (m_Directions.z == 0)
			Speed = Mathf.Max(0, Speed - DefaultMovementDeceleration * Time.deltaTime);
		else if (m_Directions.z == 1)
			Speed = Mathf.Min(MaxMovementSpeed, Speed + MovementAcceleration * Time.deltaTime);
		else if (m_Directions.z == -1)
			Speed = Mathf.Max(0, Speed - ForcedMovementDeceleration * Time.deltaTime);

		// Update player position
		transform.position += transform.forward * Speed;
	}
	 
	private void UpdateRotation()
	{
		
		if (m_Directions.x == 0 && m_Rotation != 0) {
			int rotationDirection = m_Rotation > 0 ? 1 : -1;
			m_Rotation = Mathf.Max(0, Mathf.Abs(m_Rotation) - DefaultRotationDeceleration * Time.deltaTime) * rotationDirection;
		}
		else if (m_Directions.x == 1) {
			m_Rotation = Mathf.Min(MaxRotationSpeed, m_Rotation + RotationAcceleration * Time.deltaTime);
		}
		else if (m_Directions.x == -1) {
			m_Rotation = Mathf.Max(-MaxRotationSpeed, m_Rotation - RotationAcceleration * Time.deltaTime);
		}

		// Update Player Rotation
		transform.eulerAngles = new Vector3(
			transform.eulerAngles.x,
			transform.eulerAngles.y + m_Rotation,
			transform.eulerAngles.z
		);

		// Update player Tilting
		ObjectToTilt.localEulerAngles = new Vector3(
			0,
			0,
			-Mathf.Clamp(m_Rotation * TiltSpeed, -MaxTilt, MaxTilt)
		);
	}

}
