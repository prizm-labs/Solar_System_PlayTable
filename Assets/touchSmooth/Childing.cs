using UnityEngine;
using System.Collections;

public class Childing : MonoBehaviour {

	public Vector3 myDefaultScale;
	public GameObject ParentObject;
	void Awake(){
		myDefaultScale = transform.localScale;
	}

	public void UnParentMe( ){
		ParentObject = null;
	}

	void Update(){
		if (ParentObject != null) {
			transform.position = ParentObject.transform.position;
		}
	}
}
