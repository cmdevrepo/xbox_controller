using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class XBoxControllerTester : MonoBehaviour {

	public Text ctrl1Out;
	public Text ctrl2Out;

	private string[] playerTags = {
		"_P1",
		"_P2"
	};

	private string[] axisKeys = {
		"H1",
		"H2",
		"V1",
		"V2",
	};

	private string[] buttonKeys = {
		"X",
		"Y",
		"A",
		"B",
		"PADL",
		"PADR",
		"PADU",
		"PADD",
		"JOY1",
		"JOY2",
		"LB",
		"RB",
		"START",
		"BACK",
		"HOME"
	};

	private string[] triggerKeys = {
		"LT",
		"RT",
	};

	private string prompt = "Press Any Key";
	private float showTime = 0.5f;
	private float timeSinceLastInput1 = 0f;
	private float timeSinceLastInput2 = 0f;


	public void Update () {
		foreach (string playerTag in playerTags) {
			// For axis values.
			foreach (string key in axisKeys) {
				float val = Input.GetAxis (key + playerTag);
				if (val != 0) {
					string output = key + playerTag + ": " + val;
					UpdateText (playerTag, output);
				}
			}

			// For button values.
			foreach (string key in buttonKeys) {
				bool buttonInput = Input.GetButtonDown(key + playerTag);
				if (buttonInput) {
					string output = key + playerTag;
					UpdateText (playerTag, output);
				}
			}

			// For trigger values.
			foreach (string key in triggerKeys) {
				float val = Input.GetAxis (key + playerTag);
				if (val > 0.0f) {
					string output = key + playerTag + ": " + val;
					UpdateText (playerTag, output);
				}
			}
		}
	
		timeSinceLastInput1 -= Time.deltaTime;
		timeSinceLastInput2 -= Time.deltaTime;

		if (timeSinceLastInput1 <= 0) {
			ctrl1Out.text = prompt;
		}

		if (timeSinceLastInput2 <= 0) {
			ctrl2Out.text = prompt;
		}

	}
		
	private void UpdateText(string playerTag, string output) {
		if (playerTag == "_P1") {
			ctrl1Out.text = output;
			timeSinceLastInput1 = showTime;
		} else if (playerTag == "_P2") {
			ctrl2Out.text = output;
			timeSinceLastInput2 = showTime;
		}

		Debug.Log (output);
	}
}
	