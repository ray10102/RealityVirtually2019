using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerTest : MonoBehaviour {

	[SerializeField]
	private UnityEvent[] triggers;

	private int index;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			triggers[index].Invoke();
			index++;
		}
	}
}
