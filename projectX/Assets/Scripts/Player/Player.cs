﻿using UnityEngine;

public class Player : MonoBehaviour{

	public float speed;
	public Transform aim;
	public Weapon primaryWeapon;
	public Weapon secondaryWeapon;
	public Weapon grenade;

	// Use this for initialization
	void Start (){
		if (primaryWeapon != null){
			primaryWeapon.tag = tag;
		}

		if (grenade != null){
			grenade.tag = tag;
		}
	}

	void Update(){
		checkFire();
		checkMove();
		transform.LookAt(aim);
	}

	private void checkFire(){
		if (Input.GetButtonDown("Fire1")){
			primaryWeapon.fire(aim.position);
		} else if (Input.GetButton("Fire1")){
			primaryWeapon.autoFire(aim.position);
		} else if (Input.GetButton("Fire2")){
			primaryWeapon.aim(aim.position);
		} else if (Input.GetButtonDown("Fire3")){
			grenade.fire(aim.position);
		}
	}

	private void checkMove(){
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		transform.position += move.normalized * speed * Time.fixedDeltaTime;
	}
}
