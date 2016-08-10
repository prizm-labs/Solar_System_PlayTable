using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TouchScript;
using System;
using TouchScript.Behaviors;
using TouchScript.Gestures;

public class Cube_Into_Center : MonoBehaviour {


	public GameObject SaveBtn;
	public bool onScreen;

	void OnEnable(){
		GetComponent<PressGesture> ().Pressed += MoveToCenter;
	}

	void OnDisable(){
		GetComponent<PressGesture> ().Pressed -= MoveToCenter;

	}


	public void MoveToCenter(object Sender, EventArgs e ){
		Debug.Log ("YO!");
		if (!onScreen) {
			onScreen = true;
			SaveBtn.GetComponent<Animator> ().SetBool("ComeIn", true);
			SaveBtn.GetComponent<Animator> ().SetBool("Go_Off", false);

		} else {
			onScreen = false;
			SaveBtn.GetComponent<Animator> ().SetBool ("Go_Off", true);
			SaveBtn.GetComponent<Animator> ().SetBool("ComeIn", false);


		}
	}


}
