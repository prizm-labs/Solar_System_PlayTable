using UnityEngine;
using System.Collections;

public class large_planet : MonoBehaviour {


	public static large_planet Instance;

	void Awake(){
		Instance = this; 
	}
}
