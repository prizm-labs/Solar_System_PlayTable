using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using SocketIO;

namespace Prizm {
	public enum touchType{smartTouchStart, smartTouchEnd};
	public delegate void rfidDetected(bindedObject rfBinded);

	/*Define your own varibles as reflected on your json file
	 example:
	    "04 03 37 2A": {
        "exp": "0",
        "level": "1",
        "multiAttack": "Thunder Strike",
        "multiDefend": "Bifrost Blessing",
        "name": "Thormon",
        "singleAttack": "Hammer Throw",
        "singleDefend": "Windup Hammer"
    },
	*/
	public class bindedObject{
		public Vector3 LOCATION{ get; set;}
		public string ID{get;set;}
		public string TYPE{ get; set; }
		
		public bindedObject( Vector3 location, string id, string type){
			ID = id;
			TYPE = type;
			LOCATION = location;
		}
	}

	public class PrizmObject{
		public rfidDetected smartTouchStart;
		public rfidDetected smartTouchEnd;
		public rfidDetected unregisteredSmartTouchStart;
		public rfidDetected unregisteredSmartTouchEnd;
		private JSONObject j;

		public void RFIDEventManager(string ID, touchType ST, Vector3 location){
			Debug.LogError (location);
			string type;

			checkJSON.findTagInfo (j, ID, out type, location);
			bindedObject rfReadyObject = new bindedObject(location, ID, type);

			if (type != "") { //entry MUST contain some components and properties
				if (ST == touchType.smartTouchStart) {
					smartTouchStart (rfReadyObject);
				} else if (ST == touchType.smartTouchEnd) {
					smartTouchEnd (rfReadyObject);
				}
			} 
		}

		public IEnumerator readJson(){
			j = null;
			string fileName = "pieces.json"; //rename this to your json file
			string jsonPath = Application.streamingAssetsPath + "/" + fileName;
			StreamReader sr;

			//windows
			if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer) {
				sr = new StreamReader (jsonPath);
				yield return sr;
				j = new JSONObject (sr.ReadToEnd ());
				sr.Close ();
			}
			
			//android 
			else if (Application.platform == RuntimePlatform.Android) {
				WWW www = new WWW (jsonPath);
				yield return www;
				j = new JSONObject (www.text.ToString ());
				//j = JSON.Parse (www.text.ToString ()) as JSONClass;
				Debug.LogError ("JSON found! Number of IDs located: " + j["rfBindings"].Count);
			} else 
				Debug.LogError ("Android and Windows only");
			
			yield return null;


		}
	}


	/*Modify this to reflect your own JSON
	 example:
	 
	   "04 03 37 2A": {
        "exp": "0",
        "level": "1",
        "multiAttack": "Thunder Strike",
        "multiDefend": "Bifrost Blessing",
        "name": "Thormon",
        "singleAttack": "Hammer Throw",
        "singleDefend": "Windup Hammer"
    },

	*/
	public static class checkJSON{
		public static void findTagInfo(JSONObject j, string id, out string type, Vector3 location){
			type = "";

			if (j.HasField (id)) {
				type = j.GetField (id).GetField ("type").str;
			}
		}



	}
}