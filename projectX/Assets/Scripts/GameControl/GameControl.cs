using UnityEngine;

public class GameControl : MonoBehaviour{

	public GameObject player;
	public GameObject target;
	public GameObject camera;
	
	public Transform startPoint;
	
	public GameObject pauseMenu;
	public GameObject deathMenu;
	private bool paused = false;
	
	void Start (){
		Instantiate(camera);
		GameObject playerInstance = Instantiate(player, startPoint);
		GameObject targetInstance = Instantiate(target, startPoint);
		GameObject aimingCam = Instantiate(camera);
		
		Global.player = playerInstance;
		playerInstance.GetComponent<Player>().aim = targetInstance.transform;
		Camera.main.GetComponent<CameraControl>().target = playerInstance;
		aimingCam.GetComponent<Camera>().depth = 2;
		aimingCam.GetComponent<CameraControl>().target = targetInstance;
		aimingCam.GetComponent<AudioListener>().enabled = false;
		aimingCam.tag = "Untagged";
		Global.aimingCam = aimingCam.GetComponent<Camera>();
		Cursor.visible = false;
	}

	private void pause(){
		paused = !paused;
		Cursor.visible = paused;
		Time.timeScale = paused ? 0 : 1;
		pauseMenu.SetActive(paused);
	}
}
