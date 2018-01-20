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

	private string[] keys = {
		"H1",
		"H2",
		"V1",
		"V2",
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
		"LT",
		"RT",
		"LB",
		"RB",
		"START",
		"BACK",
		"HOME"
	};

	private string prompt = "Press Any Key";

	private float showTime = 1f;
	private float timeSinceLastInput1 = 0f;
	private float timeSinceLastInput2 = 0f;


	void Update () {
		foreach (string playerTag in playerTags) {
			foreach (string key in keys) {

				// For axis values.
				float val = Input.GetAxis(key + playerTag);
				if (val != 0) {

					// Special case for the left and right triggers.
					if (key == "LT" || key == "RT") {
						if (val < 0) {
							return;
						}
					}

					string output = key + playerTag + ": " + val;
					if (playerTag == "_P1") {
						ctrl1Out.text = output;
						Debug.Log (output);
						timeSinceLastInput1 = showTime;
					} else if (playerTag == "_P2") {
						ctrl2Out.text = output;
						Debug.Log (output);
						timeSinceLastInput2 = showTime;
					}

				}

				// For button values.
				bool buttonInput = Input.GetButtonDown(key + playerTag);
				if (buttonInput) {
					string output = key + playerTag;
					if (playerTag == "_P1") {
						ctrl1Out.text = output;
						Debug.Log (output);
						timeSinceLastInput1 = showTime;
					} else if (playerTag == "_P2") {
						ctrl2Out.text = output;
						Debug.Log (output);
						timeSinceLastInput2 = showTime;
					}
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
}


