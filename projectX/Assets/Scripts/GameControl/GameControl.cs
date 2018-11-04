using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour{

	[Header("Player")]
	public GameObject player;
	public GameObject target;
	public GameObject camera;
	public GameObject miniMapCamera;
	
	[Header("Points")]
	public CheckPoint[] checkPoints;
	public int lastCheckPoint;
	
	public GameObject pauseMenu;
	public GameObject deathMenu;
	private bool paused;

	#region initialization

	void Start (){
		playerInitialize();
		checkPointInitialize();
	}
	
	private void playerInitialize(){
		CameraControl mainCamera = Instantiate(camera).GetComponent<CameraControl>();
		GameObject miniMap = Instantiate(miniMapCamera);
		GameObject playerInstance = Instantiate(player, checkPoints[0].transform.position, Quaternion.identity);
		GameObject targetInstance = Instantiate(target, checkPoints[0].transform.position, Quaternion.identity);
		GameObject aimingCam = Instantiate(camera);
		
		Global.player = playerInstance;
		playerInstance.GetComponent<Player>().aim = targetInstance.transform;
		
		mainCamera.target = playerInstance;
		
		miniMap.GetComponent<CameraControl>().target = playerInstance;
		float width = 0.4f * Screen.height / Screen.width;
		miniMap.GetComponent<Camera>().rect = new Rect(1 - width, 0.6f, width, 0.4f);
		
		aimingCam.GetComponent<Camera>().depth = 0;
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
		if (Input.GetButtonDown("Pause")) pause();
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
