using UnityEngine;

public class GameControl : MonoBehaviour{

	public GameObject player;
	public GameObject pauseMenu;
	public GameObject deathMenu;
	private bool paused = false;
	
	void Start (){
		Global.player = player;
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
