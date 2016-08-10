using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using TouchScript.Behaviors;
using TouchScript.Gestures;

public class ButtonScript : MonoBehaviour {


	public string myButtonName;


	void OnEnable(){
		GetComponent<PressGesture> ().Pressed += SendStateToSimulationManager;
	}

	void OnDisable(){
		GetComponent<PressGesture> ().Pressed -= SendStateToSimulationManager;
	}


	void SendStateToSimulationManager(object sender, EventArgs e){
		GameState myStringToEnum =  (GameState)System.Enum.Parse( typeof( GameState ), myButtonName);
		SimulationManager.Instance.MyGameState = myStringToEnum;

	}
}
