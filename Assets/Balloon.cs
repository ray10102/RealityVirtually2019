using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
	[SerializeField]
	private float lerpSpeed;

	private float releaseTime;

	private bool release;

	public float riseSpeed = 1f;
	
	// Use this for initialization
	void Start ()
	{
		release = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (release && Time.timeSinceLevelLoad > releaseTime + 1.5f)
		{
			transform.position = transform.position + Vector3.up * riseSpeed;
		}
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, lerpSpeed * Time.deltaTime);
	}

	public void ReleaseBalloon()
	{
		release = true;
		releaseTime = Time.timeSinceLevelLoad;
	}
}
