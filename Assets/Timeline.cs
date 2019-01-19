using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Timeline : MonoBehaviour
{
	public UnityEvent[] actions;

	public float[] timeline;

	private float startTime;

	private int index;
	
	// Use this for initialization
	void Start ()
	{
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		while (timeline.Length > 0 && timeline[index] < Time.timeSinceLevelLoad - startTime)
		{
			actions[index].Invoke();
			index++;
		}
	}

	public void startTimer()
	{
		startTime = Time.timeSinceLevelLoad;
	}
}
