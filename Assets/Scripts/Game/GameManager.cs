using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	static public bool CanPlay = false;
	public Transform FishContainer;
	public FishBank FishBank;

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("Let's have some fun!");

		for (int i = 0; i < 20; i++) {
			foreach (var fishtype in FishBank.FishTypes) {
				if (fishtype.FishType == "Narwhal" && i > 0)
					continue;
				
				Fish fish = Instantiate(fishtype.FishPrefab, FishContainer).GetComponent<Fish>();
				fish.transform.position = new Vector3 (Random.Range (-1000, 1000), 0, Random.Range (-1000, 1000));
				fish.Data = fishtype;
			}
		}

		StartGame ();
    }

	private void StartGame()
	{
		CanPlay = true;
	}
	
	public static void Win()
	{
		CanPlay = false;
		SceneManager.LoadScene ("Ending", LoadSceneMode.Additive);
	}
}
