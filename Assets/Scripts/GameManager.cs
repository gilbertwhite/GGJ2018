using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Transform FishContainer;
	public FishBank FishBank;

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("Let's have some fun!");
		Instantiate (FishBank.FishTypes[0].FishPrefab, FishContainer);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
