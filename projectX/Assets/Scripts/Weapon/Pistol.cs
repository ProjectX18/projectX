using UnityEngine;

public class Pistol : Weapon{

	public GameObject bullet;

	void Start (){
		name = "Pistol";
		ammo = int.MaxValue; //signals for infinite ammo
		maxAmmo = int.MaxValue;
		cooldownDelta = 0;
		overheatThreshold = 0;
		overheatCooldown = 0;
//		fireRate = ?; do not hard code any number other than the special numbers (max, 0)
	}

	// override the base function to implement the functionality
	public override bool fire(Vector3 target){
		// cooldown control is handled in the base class
		// call base function to check if can fire (also keeps track of bullet and cooldown)
		if (!base.fire(target)) return false;
		// instantiate, set tag at the end to avoid friendly fire
		Instantiate(bullet, transform.position, transform.rotation).tag = tag;
		return true;
	}

	// override the base function to dis allow auto fire
	public override bool autoFire(Vector3 target){
		return false;
	}

	public override void aim(Vector3 target){
		Global.aimingCam.enabled = true;
		Vector3 direction = new Vector3(target.x - transform.position.x, 0, target.z - transform.position.z);
		Ray ray = new Ray(transform.position, direction);
		Debug.DrawRay(ray.origin, ray.direction);
	}
}
