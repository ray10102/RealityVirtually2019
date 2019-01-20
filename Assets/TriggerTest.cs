using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerTest : MonoBehaviour {

	[SerializeField]
	private UnityEvent[] triggers;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			triggers[0].Invoke();
		}
	}
}
