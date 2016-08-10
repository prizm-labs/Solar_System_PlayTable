using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Prizm;
using TouchScript;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//would-be-developer's script
public class RFManager: MonoBehaviour {

	public GameObject small;
	public GameObject medium;
	public GameObject large;

	public GameObject emitter_1;
	public GameObject emitter_2;
	public GameObject emitter_3;




	public static RFManager instance;
	public PrizmObject prizmFactory = new PrizmObject();

	void Awake(){
		if (instance) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
			StartCoroutine (prizmFactory.readJson ());
		}
	}

	void OnEnable(){
		prizmFactory.smartTouchStart += smartTouchStartHandler;
		prizmFactory.smartTouchEnd += smartTouchEndHandler;
	}

//	void touchBeganHandler (object sender, TouchEventArgs e){
//		foreach (var point in e.Touches) {
//			TouchManager.Instance.CancelTouch (point.Id, true);
//			TouchManager.Instance.TouchesBegan += touchBeganHandler;
//
//		}
//	}
//	void touchEndHandler( object sender, TouchEventArgs e){
//		TouchManager.Instance.TouchesBegan += touchBeganHandler;
//	
//	}

	void OnDisable(){
		prizmFactory.smartTouchStart -= smartTouchStartHandler;
		prizmFactory.smartTouchEnd -= smartTouchEndHandler;
	}

	private void smartTouchStartHandler(bindedObject rfAttributes){
		Debug.Log ("STS: " + rfAttributes.ID);
		Debug.Log (rfAttributes.TYPE);
		Vector3 puckDownLocation = Camera.main.ScreenToWorldPoint(new Vector3(rfAttributes.LOCATION.x,rfAttributes.LOCATION.y, 30.0f));
//		if (rfAttributes.TYPE == "emitter") {
//			Debug.LogError ("emitter detected at " + rfAttributes.LOCATION);
//		}

		if (rfAttributes.TYPE == "smallPlanet") {
			Debug.LogError ("planet detected at " + puckDownLocation);
			//GameObject small_planet = GameObject.Find ("smallweight");
			small.gameObject.SetActive(true);
			small.transform.position = puckDownLocation;

			
		}
		else if (rfAttributes.TYPE == "midPlanet") {
			Debug.LogError ("planet detected at " + puckDownLocation);
			medium.gameObject.SetActive(true);
			medium.transform.position = puckDownLocation;

			
		}
		else if (rfAttributes.TYPE == "largePlanet") {
			Debug.LogError ("planet detected at " + puckDownLocation);
			large.gameObject.SetActive(true);
			large.transform.position = puckDownLocation;

		}
		else if (rfAttributes.TYPE == "emitter_1") {
			Debug.LogError ("emitter detected at " + puckDownLocation);
			emitter_1.gameObject.SetActive(true);
			emitter_1.transform.position = puckDownLocation;

		}
		else if (rfAttributes.TYPE == "emitter_2") {
			Debug.LogError ("emitter detected at " + puckDownLocation);
			emitter_2.gameObject.SetActive(true);
			emitter_2.transform.position = puckDownLocation;

		}
		else if (rfAttributes.TYPE == "emitter_3") {
			Debug.LogError ("emitter detected at " + puckDownLocation);
			emitter_3.gameObject.SetActive(true);
			emitter_3.transform.position = puckDownLocation;

		}
	}  

	private void smartTouchEndHandler(bindedObject rfAttributes){
		Debug.Log ("STE: "+  rfAttributes.ID);
		Debug.Log (rfAttributes.TYPE);


		if (rfAttributes.TYPE == "smallPlanet") {
			//Debug.LogError ("planet detected at " + puckDownLocation);
			//GameObject small_planet = GameObject.Find ("smallweight");
			small.gameObject.SetActive(false);
			//small.transform.position = puckDownLocation;

		}
		else if (rfAttributes.TYPE == "midPlanet") {
			//Debug.LogError ("planet detected at " + puckDownLocation);
			medium.gameObject.SetActive(false);
			//medium.transform.position = puckDownLocation;


		}
		else if (rfAttributes.TYPE == "largePlanet") {
			//Debug.LogError ("planet detected at " + puckDownLocation);
			large.gameObject.SetActive(false);
			//large.transform.position = puckDownLocation;

		}
		else if (rfAttributes.TYPE == "emitter_1") {
			emitter_1.gameObject.SetActive(false);

		}
		else if (rfAttributes.TYPE == "emitter_2") {
			emitter_2.gameObject.SetActive(false);

		}
		else if (rfAttributes.TYPE == "emitter_3") {
			emitter_3.gameObject.SetActive(false);

		}

	}


}