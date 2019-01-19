using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.Collections;
using UnityEngine;

public class SectionManager : MonoBehaviour {
	
	[SerializeField]
	private ObjectCollection[] collections;

	private float percentage;

	[SerializeField]
	private int rows;

	
	
	// Use this for initialization
	void Start ()
	{
		collections = GetComponentsInChildren<ObjectCollection>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateChildren()
	{
		
	}
}
