using UnityEngine;
using System.Collections;

public class OscillatingSpiralSize : MonoBehaviour {

	int counter;
	SprialField spf;


	// Use this for initialization
	void Start () {
		spf = GetComponent<SprialField> ();
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter % 100 == 0) {
			spf.size = Mathf.PingPong (Time.time, 3.0f) -1 ;
		}
	
	}
}
