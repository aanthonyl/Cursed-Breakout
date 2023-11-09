/*
    Script Added by Aurora Russell
	10/01/2023
	// TYPEWRITER EFFECT FOR UI TEXT //
*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Typewriter : MonoBehaviour
{

	// SCRIPT TO BE PLACED ON A TEXT OBJECT //

	Text _text;
	string writer;

	[SerializeField] float delayBeforeStart = 0f;
	[SerializeField] float timeBtwChars = 0.1f;
	[SerializeField] string leadingChar = "";
	[SerializeField] bool leadingCharBeforeDelay = false;

	private bool cancelTyping = false;

	void Start()
	{
		_text = GetComponent<Text>()!;

		if (_text != null)
		{
			writer = _text.text;
			_text.text = "";

			StartCoroutine("TypeWriterText");
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			_text = GetComponent<Text>()!;

			if (_text != null)
			{
				writer = _text.text;
				_text.text = "";

				StartCoroutine("TypeWriterText");
			}
		}
	}

	IEnumerator TypeWriterText()
	{
		_text.text = leadingCharBeforeDelay ? leadingChar : "";

		yield return new WaitForSeconds(delayBeforeStart);


		foreach (char c in writer)
		{
			if (_text.text.Length > 0)
			{
				_text.text = _text.text.Substring(0, _text.text.Length - leadingChar.Length);
			}
			_text.text += c;
			_text.text += leadingChar;
			yield return new WaitForSeconds(timeBtwChars);
		}

		if (leadingChar != "")
		{
			_text.text = _text.text.Substring(0, _text.text.Length - leadingChar.Length);
		}
	}
}