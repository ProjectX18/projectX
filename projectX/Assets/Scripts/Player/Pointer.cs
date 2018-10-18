using UnityEngine;

public class Pointer : MonoBehaviour{
	
	private int floorMask;
	public float camRayLen;
	
	void Start (){
		floorMask = LayerMask.GetMask("Ground");
	}
	
	void Update (){
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(camRay, out hit, camRayLen, floorMask)){
			transform.position = hit.point;
		}
	}
}
