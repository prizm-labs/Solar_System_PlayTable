using UnityEngine;
using System.Collections;

public class PlatformManagerScript : MonoBehaviour {

	public GameObject SocketIOObject;
	public GameObject AndroidObject;

	void Awake(){
		if (SocketToJSON.instance) {
			Destroy (gameObject);
		} 
	}
	// Use this for initialization
	void Start () {
		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer) {
			Instantiate(SocketIOObject);
		}
		
		//android 
		else if (Application.platform == RuntimePlatform.Android) {
			Instantiate(AndroidObject);
		}

	}

}
