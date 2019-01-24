using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGroup : MonoBehaviour
{

	private Balloon[] balloons;

	public Animator wreckingBall;

	private Animator anim;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
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

	public void Raise()
	{
		anim.SetTrigger("rise");
	}
}
