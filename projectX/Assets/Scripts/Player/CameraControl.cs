using UnityEngine;

public class CameraControl : MonoBehaviour{
	
	public GameObject target;
	public Vector3 offset;
	
	// Update is called once per frame
	void Update (){
		transform.position = target.transform.position + offset;
	}
}
