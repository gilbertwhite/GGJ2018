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

		for (int i = 0; i < 20; i++) {
			foreach (var fishtype in FishBank.FishTypes) {
				Fish fish = Instantiate(fishtype.FishPrefab, FishContainer).GetComponent<Fish>();
				fish.transform.position = new Vector3 (Random.Range (-1000, 1000), 0, Random.Range (-1000, 1000));
				fish.Data = fishtype;
			}
		}
    }
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
