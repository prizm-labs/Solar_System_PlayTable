using UnityEngine;
using System.Collections;

public class searchingForPlanet : MonoBehaviour {

	public GameObject myChild;
	void OnTriggerStay(Collider other){
		if (other.tag == "planet") {
			Debug.LogError ("Parenting");
			myChild = other.gameObject;
			other.gameObject.GetComponent<Childing> ().ParentObject = gameObject;
		}
	}
}
