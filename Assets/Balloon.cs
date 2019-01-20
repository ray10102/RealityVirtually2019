using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
	[SerializeField]
	private float lerpSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, lerpSpeed * Time.deltaTime);
	}
}
