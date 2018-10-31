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
		Camera.main.GetComponent<CameraControl>().player = playerInstance;
		Global.player = playerInstance;
		playerInstance.GetComponent<Player>().aim = Instantiate(target, startPoint).transform;
		Global.aiming = false;
		Cursor.visible = false;
	}
	
	void Update () {
		
	}

	private void pause(){
		paused = !paused;
		Cursor.visible = paused;
		Time.timeScale = paused ? 0 : 1;
		pauseMenu.SetActive(paused);
	}
}
