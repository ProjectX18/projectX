using UnityEngine;

public class Player : MonoBehaviour{

	public float speed;
	public Transform aim;
	public Weapon primaryWeapon;
	public Weapon secondaryWeapon;
	public Weapon grenade;
	public Health health;

	// Use this for initialization
	void Start (){
		if (primaryWeapon != null){
			primaryWeapon.tag = tag;
		}

		if (grenade != null){
			grenade.tag = tag;
		}

		health = GetComponent<Health>();
	}

	void FixedUpdate(){
		if (health.dead) return;
		checkMove();
		transform.LookAt(aim);
	}

	private void Update(){
		if (health.dead){
			Time.timeScale = 0;
			return;
		}
		checkFire();
	}

	private void checkFire(){
		if (Input.GetButtonDown("Fire1")){
			primaryWeapon.fire(aim.position);
		} else if (Input.GetButton("Fire1")){
			primaryWeapon.autoFire(aim.position);
		}
		if (Input.GetButton("Fire2")){
			primaryWeapon.aim(aim.position);
		} else{
			Global.aimingCam.enabled = false;
		}

		if (Input.GetButtonUp("Fire3")){
			grenade.fire(aim.position);
		} else if (Input.GetButton("Fire3")){
			grenade.aim(aim.position);
		}
	}

	private void checkMove(){
		Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		transform.position += move.normalized * speed * Time.fixedDeltaTime;
	}
}
