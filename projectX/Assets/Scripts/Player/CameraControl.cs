using UnityEngine;

public class CameraControl : MonoBehaviour{
	
	public GameObject player;
	public GameObject pointer;
	private Vector3 offset;
	
	void Start (){
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update (){
		transform.position = player.transform.position + offset;
	}
}
