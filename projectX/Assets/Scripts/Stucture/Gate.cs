using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : Doable{

	public GameObject[] openPosMarker;
	public GameObject[] gates;
	public float speed;
	public bool close = true;
	private Vector3[] openPos;
	private Vector3[] closePos;
	private int length;

	// Use this for initialization
	void Start (){
		length = gates.Length < openPosMarker.Length ? gates.Length : openPosMarker.Length; 
		closePos = new Vector3[length];
		openPos = new Vector3[length];
		for (int i = 0; i < length; i++){
			closePos[i] = gates[i].transform.position;
			openPos[i] = openPosMarker[i].transform.position;
		}
	}

	private void FixedUpdate(){
		moveGates(close ? closePos : openPos);
	}

	private void moveGates(Vector3[] target){
		for (int i = 0; i < length; i++){
			Vector3 pos = gates[i].transform.position;
			gates[i].transform.position = Vector3.MoveTowards(pos, target[i], speed * Time.fixedDeltaTime);
		}
	}

	public override void action(){
		close = !close;
	}
}
