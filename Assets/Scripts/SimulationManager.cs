using UnityEngine;
using System.Collections;


public enum GameState{None, LargeWeight, MiddleWeight, SmallWeight, Repel, Oscillate, ParticleObj};


public class SimulationManager : MonoBehaviour {

	public static SimulationManager Instance;
	public GameState MyGameState;

	public GameObject SmallWeightObj;
	public GameObject MiddleWeightObj;
	public GameObject LargeWeightObj;
	public GameObject RepelObj;
	public GameObject OscillateObj;
	public GameObject ParticleObj;


	// Use this for initialization
	void Start () {
		Instance = this;
		MyGameState = GameState.None;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
