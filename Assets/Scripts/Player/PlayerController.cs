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
	public float SonarSize = 12f;

	[Header("Movement Speed")]
	[SerializeField]private float MaxMovementSpeed = 1f;
	[SerializeField]private float MovementAcceleration = 0.01f;
	[SerializeField]private float DefaultMovementDeceleration = 0.005f;
	[SerializeField]private float ForcedMovementDeceleration = 0.02f;
	[SerializeField]private float BackwardSpeed = 3f;

	[Header("Rotation Speed")]
	[SerializeField]private float MaxRotationSpeed = 1f;
	[SerializeField]private float RotationAcceleration = 0.01f;
	[SerializeField]private float DefaultRotationDeceleration = 0.005f;
	[SerializeField]private float RotationIntensity = 5000f;

	[Header("Rotation Tilting")]
	[SerializeField]private Transform ObjectToTilt;
	[SerializeField]private float TiltSpeed = 1f;
	[SerializeField]private float MaxTilt = 35f;

	// Player Movement
	[HideInInspector]
	public float Speed {get; private set;}
	public Transform Whale;
	private Vector3 m_Directions = Vector3.zero;
	private float m_Rotation = 0;
	private float m_TiltForce;
	private Rigidbody m_Body;
	private SphereCollider m_SonarCollider;
	private Tweener m_SonarTween;

	// Use this for initialization
	private void Start () 
	{
		Speed = 0;
		m_SonarCollider = GetComponentInChildren<SphereCollider>(true);
		m_Body = GetComponent<Rigidbody>();
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
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
			m_Directions.z = 1;
		} else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
			m_Directions.z = -1;
		} else {
			m_Directions.z = 0;
		}

		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			m_Directions.x = -1;
		}
		else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
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
		m_SonarCollider.gameObject.SetActive(true);
		SonarFx.origin = transform.position;
		SonarFx.Launch (WaveDuration);
		m_SonarCollider.radius = 0;
		if (m_SonarTween != null) {
			m_SonarTween.Kill ();
		}

		m_SonarTween = DOTween.To(()=> m_SonarCollider.radius, x=> m_SonarCollider.radius = x, SonarSize, WaveDuration)
			.OnComplete(() => {
				m_SonarCollider.radius = 0;
				m_SonarCollider.gameObject.SetActive(false);
			});
		}


	private void UpdateSpeed()
	{
		if (m_Directions.z == 0)
			Speed = Mathf.Max(BackwardSpeed, Speed - DefaultMovementDeceleration * Time.deltaTime);
		else if (m_Directions.z == 1)
			Speed = Mathf.Min(MaxMovementSpeed, Speed + MovementAcceleration * Time.deltaTime);
		else if (m_Directions.z == -1)
			Speed = Mathf.Max(BackwardSpeed, Speed - ForcedMovementDeceleration * Time.deltaTime);

		// Update player position
		//m_Body.AddForce ();
		m_Body.velocity = Vector3.ClampMagnitude(transform.forward * Speed, MaxMovementSpeed);
	}
	 
	private void UpdateRotation()
	{
		
		if (m_Directions.x == 0 && m_Rotation != 0) {
			int rotationDirection = m_Rotation > 0 ? 1 : -1;
			m_Rotation = Mathf.Max(0, Mathf.Abs(m_Rotation) - RotationIntensity * DefaultRotationDeceleration * Time.deltaTime) * rotationDirection;
		}
		else if (m_Directions.x == 1) {
			m_Rotation = Mathf.Min(MaxRotationSpeed, m_Rotation + RotationAcceleration * Time.deltaTime);
		}
		else if (m_Directions.x == -1) {
			m_Rotation = Mathf.Max(-MaxRotationSpeed, m_Rotation - RotationAcceleration * Time.deltaTime);
		}

		// Update Player Rotation
		m_Body.AddTorque(Vector3.up * m_Rotation * RotationIntensity, ForceMode.Force);
		m_Body.angularVelocity = new Vector3(0, m_Body.angularVelocity.y, 0);
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

		// Update player Tilting
		m_TiltForce = Mathf.LerpAngle(m_TiltForce, m_Body.angularVelocity.y, Time.deltaTime);
		//Debug.Log(m_Body.angularVelocity.y);
		ObjectToTilt.localEulerAngles = new Vector3(
			0,
			0,
			-Mathf.Clamp(m_Body.angularVelocity.y * TiltSpeed, -MaxTilt, MaxTilt)
		);
	}

}
