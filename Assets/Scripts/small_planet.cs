using UnityEngine;
using System.Collections;

public class small_planet : MonoBehaviour {


	public static small_planet Instance;

	void Awake(){
		Instance = this; 
	}


}
