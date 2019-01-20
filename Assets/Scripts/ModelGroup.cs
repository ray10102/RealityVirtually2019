using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ModelGroup : MonoBehaviour
{
	public Transform source;
	public Transform target;
	
	// Use this for initialization
	void Start () {
		Debug.Log(source.childCount);
		for (int i = 0; i < source.childCount; i++)
		{
			Transform model = transform.GetChild(i).transform;
			model.parent = target.GetChild(i);
			model.localPosition = Vector3.zero;
			model.LookAt(Vector3.zero);
			Debug.Log(model);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
