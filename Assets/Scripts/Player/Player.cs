using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	[SerializeField] private float SpeedWaveRatio = 1f;

	private PlayerController m_Controller; 
	private WaveMotion m_WaveMotion; 

	// Use this for initialization
	void Start () 
	{
		m_Controller = GetComponent<PlayerController> ();
		m_WaveMotion = GetComponent<WaveMotion> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		m_WaveMotion.Intensity = m_Controller.Speed * SpeedWaveRatio;
	}
}
