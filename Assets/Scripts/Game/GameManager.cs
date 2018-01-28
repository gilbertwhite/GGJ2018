using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
	
	static public bool CanPlay = false;
	static public AudioSource MainMusic;
	public PlayerController Player;
	public Transform FishContainer;
	public FishBank FishBank;
	public List<Transform> CameraTargets;

	private bool m_ReadyForCamera = true;
	private int m_currentTarget = 0;

	// Use this for initialization
	void Start ()
	{
		GameManager.MainMusic = GetComponentInChildren<AudioSource>();

		Debug.Log ("Let's have some fun!");

		for (int i = 0; i < 20; i++) {
			foreach (var fishtype in FishBank.FishTypes) {
				if (fishtype.FishType == "Narwhal" && i > 0)
					continue;
				
				Fish fish = Instantiate (fishtype.FishPrefab, FishContainer).GetComponent<Fish> ();
				fish.transform.position = new Vector3 (Random.Range (-1000, 1000), 0, Random.Range (-1000, 1000));
				fish.Data = fishtype;
			}
		}
		IntroCameraMove ();
	}

	private void WaitForNextAction()
	{
		m_ReadyForCamera = true;
	}

	private void Update()
	{
		if (CanPlay)
			return;

		if (m_ReadyForCamera && Input.anyKeyDown)
			IntroCameraMove ();
	}

	private void IntroCameraMove()
	{
		if (m_currentTarget >= CameraTargets.Count) {
			Camera.main.transform.DOMove (Player.transform.TransformPoint(Player.CameraOffset), 5f).OnComplete (StartGame);
			Camera.main.transform.DOLookAt (Player.transform.position + Player.CameraTargetOffset, 5f);
			return;
		}

		m_ReadyForCamera = false;
		Camera.main.transform.DOMove (CameraTargets [m_currentTarget].transform.position, 5f).OnComplete (WaitForNextAction);
		Camera.main.transform.DORotate(CameraTargets [m_currentTarget].transform.eulerAngles, 5f);
		m_currentTarget++;
    }

	private void StartGame()
	{
		CanPlay = true;
	}
	
	public static void Win()
	{
		CanPlay = false;
		MainMusic.DOFade(0, 1f);
		SceneManager.LoadScene ("Ending", LoadSceneMode.Additive);
	}
}
