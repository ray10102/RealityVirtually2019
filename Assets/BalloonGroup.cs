using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGroup : MonoBehaviour
{

	private Balloon[] balloons;

	public Animator wreckingBall;

	// Use this for initialization
	void Start ()
	{
		balloons = GetComponentsInChildren<Balloon>();
	}

	public void Release()
	{
		wreckingBall.SetTrigger("release");
		foreach (Balloon balloon in balloons)
		{
			balloon.ReleaseBalloon();
		}
	}
}
