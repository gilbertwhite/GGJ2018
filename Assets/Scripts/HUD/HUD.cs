using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour 
{

	public GameObject Blocker;

	// Use this for initialization
	void Start ()
	{
		Blocker.SetActive (false);
	}
}
