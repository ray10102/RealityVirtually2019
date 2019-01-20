using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using MagicLeap;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class InteractiveHuman : MonoBehaviour
{

	[SerializeField]
	private Text displayText;

	[SerializeField]
	private string[] dreams;

	[SerializeField]
	private float lerpSpeed = .5f;

	private Color lerpTo;

	[SerializeField]
	private Light spotlight;

	private int index = 0;
	
	// Use this for initialization
	void Start ()
	{
		displayText = GameObject.FindGameObjectWithTag("DisplayText").GetComponent<Text>();
		Color textColor = displayText.color;
		textColor.a = 0;
		displayText.color = textColor;
		lerpTo = textColor;
	}
	
	// Update is called once per frame
	void Update ()
	{
		LerpTextColor();
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("trigger");

		if (other.CompareTag("Controller"))
		{
			Debug.Log("trigger controller");
			SetText();
			FadeText(1f);
			//HighlightModel(true);
		}	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Controller"))
		{
			FadeText(0f);
			//HighlightModel(true);
		}	}

	private void FadeText(float alpha)
	{
		Color textColor = displayText.color;
		textColor.a = alpha;
		lerpTo = textColor;
	}

	private void SetText()
	{
		displayText.text = dreams[index % dreams.Length];
		index++;
	}
	
	private void LerpTextColor()
	{
		displayText.color = Color.Lerp(displayText.color, lerpTo, lerpSpeed * Time.deltaTime);
	}

	private void HighlightModel(bool on)
	{
		spotlight.gameObject.SetActive(on);
	}
}
