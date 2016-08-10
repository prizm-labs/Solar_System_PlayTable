using UnityEngine;
using System.Collections;

public class mid_planet : MonoBehaviour {


	public static mid_planet Instance;

	void Awake(){
		Instance = this; 
	}
}
