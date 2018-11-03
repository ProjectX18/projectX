using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour{

	[Header("Player")]
	public GameObject player;
	public GameObject target;
	public GameObject camera;
	
	[Header("Points")]
	public CheckPoint[] checkPoints;
	public int lastCheckPoint;
	
	public GameObject pauseMenu;
	public GameObject deathMenu;
	private bool paused = false;

	#region initialization

	void Start (){
		playerInitialize();
		checkPointInitialize();
	}
	
	private void playerInitialize(){
		Instantiate(camera);
		GameObject playerInstance = Instantiate(player, checkPoints[0].transform);
		GameObject targetInstance = Instantiate(target, checkPoints[0].transform);
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

	private void checkPointInitialize(){
		for (int i = 0; i < checkPoints.Length; i++){
			checkPoints[i].gameControl = this;
			checkPoints[i].index = i;
		}
	}

	#endregion

	private void Update(){
		if (Input.GetButtonDown("Pause")) ;
	}

	private void pause(){
		paused = !paused;
		Cursor.visible = paused;
		Time.timeScale = paused ? 0 : 1;
		pauseMenu.SetActive(paused);
	}

	public void setCheckPoint(int index){
		if (index > lastCheckPoint) lastCheckPoint = index;
	}

	#region menu functions

	public void resume(){
		pause();
	}

	public void restart(){
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
	}

	public void loadCheckPoint(){
		Global.player.transform.position = checkPoints[lastCheckPoint].transform.position;
		Global.player.GetComponent<Health>().reset();
	}
	
	public void exit(){
		SceneManager.LoadSceneAsync("Home");
	}

	#endregion
	
}
