using UnityEngine;
using System.Collections;

public class emitter1 : MonoBehaviour {


	public static emitter1 Instance;

	void Awake(){
		Instance = this; 
	}


}
