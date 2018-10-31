using UnityEngine;

public class CameraControl : MonoBehaviour{
	
	public GameObject player;
	public GameObject pointer;
	public Vector3 offset;
	
	// Update is called once per frame
	void Update (){
		transform.position = player.transform.position + offset;
	}
}
