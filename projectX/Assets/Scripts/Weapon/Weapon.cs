using UnityEngine;

// all weapons must extend this class directly instead of MonoBehaviour
// assume both player and enemy can use the weapons
public class Weapon : MonoBehaviour{
	
	public string name; // the name of the weapon
	public int ammo; // amount of ammo
	public int maxAmmo; // max ammo
	public int cooldownDelta; // the amount of "heat" per bullet
	public int overheatThreshold; // the threshold what will overheat the weapon
	public int overheatCooldown; // the cooldown that will be added when weapon is over heat
	public float fireRate; // minimum time before shots
	
	private float cooldown;
	private float lastShot;

	/// <summary>
	/// aim or other assistant action
	/// </summary>
	/// <param name="target"> location of where player if aim at </param>
	public virtual void aim(Vector3 target){
		
	}

	/// <summary>
	/// fire the weapon
	/// called while button is down
	/// </summary>
	/// <param name="target"> location of where player if aim at </param>
	/// <returns> whether fire is successful </returns>
	public virtual bool fire(Vector3 target){
		if (cooldown > overheatThreshold || ammo <= 0 || Time.timeSinceLevelLoad < lastShot + fireRate) 
			return false;
		if (ammo != int.MaxValue) ammo--;
		cooldown += cooldownDelta;
		if (cooldown > overheatThreshold) cooldown += overheatCooldown;
		lastShot = Time.timeSinceLevelLoad;
		return true;
	}

	/// <summary>
	/// fire the weapon
	/// called only at the moment button is down
	/// </summary>
	/// <param name="target"> location of where player if aim at </param>
	/// <returns> whether fire is successful </returns>
	public virtual bool autoFire(Vector3 target){
		return fire(target);
	}

	void FixedUpdate(){
		cooldown -= Time.fixedDeltaTime;
		if (cooldown < 0) cooldown = 0;
	}

	public void gainAmmo(int gain){
		if (ammo == int.MaxValue) return;
		ammo += gain;
		if (ammo > maxAmmo) ammo = maxAmmo;
	}
}
