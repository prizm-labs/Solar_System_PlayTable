using TouchScript;
using UnityEngine;
using TouchScript.Gestures;
using System.Collections.Generic;
using System.Collections;

public class TouchThing : MonoBehaviour
{
	public static Dictionary<int,GameObject> spawnedTouches = new Dictionary<int, GameObject> ();
    public GameObject physicalTouch;
	private GameObject tryOUT;

    public void OnEnable(){
			TouchManager.Instance.TouchesBegan += touchBeganHandler;
			TouchManager.Instance.TouchesMoved += touchMovedHandler;
			TouchManager.Instance.TouchesEnded += touchEndHandler;
		
    }

    public void OnDisable(){
			TouchManager.Instance.TouchesBegan -= touchBeganHandler;
			TouchManager.Instance.TouchesMoved -= touchMovedHandler;
			TouchManager.Instance.TouchesEnded -= touchEndHandler;

    }

    private GameObject spawnPrefabAt(Vector3 position)
    {
		GameObject newObject = Instantiate (physicalTouch,position,Quaternion.identity)as GameObject;
		return newObject;
	}
	
	private void touchBeganHandler(object sender, TouchEventArgs e){
		foreach (var point in e.Touches) {
			Debug.Log (point.Position);
			Vector3 spawnLocation = Camera.main.ScreenToWorldPoint (new Vector3 (point.Position.x, point.Position.y, 30));
			spawnedTouches.Add (point.Id, spawnPrefabAt (spawnLocation));				
		}
		
	}

	private void touchMovedHandler(object sender, TouchEventArgs e){
		foreach (var point in e.Touches){
			if(spawnedTouches.TryGetValue(point.Id, out tryOUT) != false){
				Vector3 moveLocation = Camera.main.ScreenToWorldPoint (new Vector3 (point.Position.x, point.Position.y, 30));				
				spawnedTouches[point.Id].transform.position = moveLocation;
			}
		}

	}

	private void touchEndHandler(object sender, TouchEventArgs e){
		foreach(var point in e.Touches)
		{
			if(spawnedTouches.TryGetValue(point.Id, out tryOUT) != false){
				foreach (Transform child in spawnedTouches[point.Id].transform) {
					child.GetComponent<Childing> ().UnParentMe ();
				}

				Destroy (spawnedTouches [point.Id]);
			}
		}
	}

}