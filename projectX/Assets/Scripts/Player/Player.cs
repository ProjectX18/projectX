using UnityEngine;

public class Player : MonoBehaviour{

	public float speed;
	public Transform aim;
	public Weapon primaryWeapon;
	public Weapon secondaryWeapon;
	public Weapon grenade;

	// Use this for initialization
	void Start (){
		primaryWeapon.tag = tag;
		grenade.tag = tag;
	}

	void FixedUpdate(){
		checkFire();
		checkMove();
	}

	private void checkFire(){
		if (Input.GetButtonDown("Fire1")){
			primaryWeapon.fire(aim.position);
		} else if (Input.GetButton("Fire1")){
			primaryWeapon.autoFire(aim.position);
		} else if (Input.GetButton("Fire2")){
			primaryWeapon.aim(aim.position);
		} else if (Input.GetButton("Fire3")){
			grenade.fire(aim.position);
		}
	}

	private void checkMove(){
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		transform.position += move.normalized * speed * Time.fixedDeltaTime;
	}
}
