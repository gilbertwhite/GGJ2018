using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {

	public Animator Animator;
	// Use this for initialization
	private void Start () 
	{
		Animator.SetTrigger ("Start");
		Animator.Play("Start");
	}
}
