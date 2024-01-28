using UnityEngine;
using System.Collections;

public class Stairs : MonoBehaviour {

	public static Stairs instance = null;
	int countParts;
	int countChange = 0;
	void Awake()
	{
		instance = this;		
	}

	GameObject[] StairsObjects = new GameObject[3];

	void Start () 
	{
		countParts = transform.childCount;
		for (int i = 0; i < countParts; i++)
		{
			StairsObjects [i] = transform.GetChild (i).gameObject;	
		}	
	}

	public void CreateNextStairsPart()
	{
		countChange++;
		StairsObjects [(countChange - 1) % countParts].transform.position = 
			new Vector3 (
				0f,
				countChange * 10f + 7f,
				countChange * 10f + 30f);	
	}
}