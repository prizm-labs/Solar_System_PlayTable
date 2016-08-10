using UnityEngine;
using System.Collections;
using System;
using TouchScript.Behaviors;
using TouchScript.Gestures;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {

	void OnEnable(){
		GetComponent<PressGesture> ().Pressed += ResetLevel;
	}

	void OnDisable(){
		GetComponent<PressGesture> ().Pressed -= ResetLevel;
	}

	void ResetLevel(object sender, EventArgs e){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}
