using System.Collections;
using UnityEngine;
using SocketIO;
using SimpleJSON;
using Prizm;

[HideInInspector]
public class SocketToJSON : MonoBehaviour{
	public static SocketToJSON instance;
	private SocketIOComponent socket;
	public RFManager RFManagerReference;

	void Awake(){
		if (instance) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void Update(){
		if (Input.GetKeyDown ("q")) {
			string RFID = "04 4C 34 BA";
			touchType ST = enumerateString ("smarttouch-start");
			Vector3 smartTouchPoint1 = new Vector3 (600f, 900f, 0);
			Vector3 smartTouchPoint = new Vector3 ();
			smartTouchPoint.x = smartTouchPoint1.x;
			smartTouchPoint.y = Camera.main.pixelHeight - smartTouchPoint1.y;
			RFManagerReference.prizmFactory.RFIDEventManager (RFID, ST, smartTouchPoint);
		}
		if (Input.GetKeyDown ("w")) {
			string RFID = "04 EC 44 BA";
			touchType ST = enumerateString ("smarttouch-start");
			Vector3 smartTouchPoint1 = new Vector3 (300f, 600f, 0);
			Vector3 smartTouchPoint = new Vector3 ();
			smartTouchPoint.x = smartTouchPoint1.x;
			smartTouchPoint.y = Camera.main.pixelHeight - smartTouchPoint1.y;
			RFManagerReference.prizmFactory.RFIDEventManager (RFID, ST, smartTouchPoint);
		}
		if (Input.GetKeyDown ("e")) {
			string RFID = "04 EE 31 BA";
			touchType ST = enumerateString ("smarttouch-start");
			Vector3 smartTouchPoint1 = new Vector3 (700f, 600f, 0);
			Vector3 smartTouchPoint = new Vector3 ();
			smartTouchPoint.x = smartTouchPoint1.x;
			smartTouchPoint.y = Camera.main.pixelHeight - smartTouchPoint1.y;
			RFManagerReference.prizmFactory.RFIDEventManager (RFID, ST, smartTouchPoint);
		}
		if (Input.GetKeyDown ("r")) {
			string RFID = "04 C3 35 BA";
			touchType ST = enumerateString ("smarttouch-start");
			Vector3 smartTouchPoint1 = new Vector3 (1500f, 600f, 0);
			Vector3 smartTouchPoint = new Vector3 ();
			smartTouchPoint.x = smartTouchPoint1.x;
			smartTouchPoint.y = Camera.main.pixelHeight - smartTouchPoint1.y;
			RFManagerReference.prizmFactory.RFIDEventManager (RFID, ST, smartTouchPoint);
		}

	}
	public void Start() {
		RFManagerReference = GameObject.Find ("GameManager").GetComponent<RFManager> ();
		socket = GetComponent<SocketIOComponent>();
		socket.On("smarttouch-start", SmartTouch);
		socket.On("smarttouch-end", SmartTouch);
	}

	//when receiving smart touch data, call this function:
	public void SmartTouch(SocketIOEvent e){
		string RFID = e.data.GetField("tagId").str;
		string typeOfTouch = e.name;
		Vector3 smartTouchPoint = new Vector3 ();
		touchType ST;
		ST = enumerateString (typeOfTouch);
		RFID = filterRFID (RFID);
		smartTouchPoint.x = e.data.GetField("x").n;
		smartTouchPoint.y = Camera.main.pixelHeight - e.data.GetField("y").n;

		RFManagerReference.prizmFactory.RFIDEventManager (RFID, ST, smartTouchPoint);
	}

	#region filters
	private touchType enumerateString(string str){
		if (str == "smarttouch-start") {
			return touchType.smartTouchStart;
		} else
			return touchType.smartTouchEnd;
	}

	private string filterRFID(string ID){
		if (ID.Length == 12) {
			return ID.Substring (0, ID.Length - 1);
		} else
			return ID;

	}

	#endregion
}