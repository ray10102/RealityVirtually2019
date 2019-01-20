using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rise : MonoBehaviour
{

	private Animator anim;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
	}

	public void Raise()
	{
		anim.SetTrigger("rise");
	}
}
