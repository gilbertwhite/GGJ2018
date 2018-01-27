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

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }

        foreach (var fishtype in FishBank.FishTypes)
        {
            GameObject fish = Instantiate(fishtype.FishPrefab, FishContainer);
            fish.transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        }


        /*
        Instantiate(FishBank.FishTypes[1].FishPrefab, FishContainer);
        Instantiate(FishBank.FishTypes[2].FishPrefab, FishContainer);
        Instantiate(FishBank.FishTypes[3].FishPrefab, FishContainer);
        Instantiate(FishBank.FishTypes[4].FishPrefab, FishContainer);
        Instantiate(FishBank.FishTypes[5].FishPrefab, FishContainer);
        Instantiate(FishBank.FishTypes[6].FishPrefab, FishContainer);
        Instantiate(FishBank.FishTypes[7].FishPrefab, FishContainer);
        */
    }
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
