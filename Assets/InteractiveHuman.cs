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

	private static readonly string[] dreams = {
		"I wanted to be a talk show host, like Oprah! --- Najla", 
		"I wanted to be a teacher so I could write on the chalk board anytime I wanted. --- Denise Ray", 
		"I wanted to have my own landscaping business, Get a house in Africa , and have a pet lion --- Tariq",
		"Ballerina, run a school for girls in North Africa, own a coffee shop --- Alicia-Jewell",
		"Wanted to be an engineer to build my own Voltron robots –-- Mohammed ",
		"I really wanted to be a actress on television! --- Jillian ",
		"Meteorologist, teacher and a movie star. ---Iman ",
		"I wanted to be a firefighter, a hero in a dope uniform and save people from burning buildings. --- Bilal",
		"Pineapple farmer. Boat tour guide. Outdoor survivalist. --- Wesley",
		"Astronaut, fire fighter, ballerina --- Latoya",
		"I wanted to coach football or be a WWE superstar. --- Halim",
		"Wanted to work on computers, own a bookstore and be a unicorn --- Sutanah",
		"I always heard the message, seek knowledge even if you have to travel to China. So I would visualize digging my way through the earth's core to China. --- Hannah",
		"Wanted to be like Mary Poppins, a Nanny --- Ruby",
		"I dreamed of traveling the world. I wanted to sky dive. I wanted to go to an orangutan or other large ape conservatory in the jungle and volunteer. --- Diana",
		"An architect, a food scientist and a marine biologist --- Jade",
		"Explorer, marine biologist, cardiologist --- Nashid"
	};

	[SerializeField]
	private float lerpSpeed = .5f;

	private Color lerpTo;

	[SerializeField]
	private Light spotlight;

	private static int index = 0;

	private static bool active;
	
	// Use this for initialization
	void Start ()
	{
		displayText = GameObject.FindGameObjectWithTag("DisplayText").GetComponent<Text>();
		Color textColor = displayText.color;
		textColor.a = 0;
		displayText.color = textColor;
		lerpTo = textColor;
		active = false;
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
		}	
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Controller") && active)
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

	public void Activate()
	{
		active = true;
	}
}
