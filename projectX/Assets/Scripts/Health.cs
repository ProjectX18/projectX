using UnityEngine;

/// <summary>
/// anything that can be destroyed must have this script, do not modify
/// </summary>
public class Health : MonoBehaviour{

	public int life;
	public bool dead;
	public bool destroyOnDeath;
	public Doable[] doOnDeath;

	public int initialHp;
	public int maxHp;
	private int hp;

	public int initialShield;
	public int maxShield;
	public int shieldRegenCooldown; //time before shield regeneration
	public int shieldRegenSpeed; //speed of shield regeneration
	private int shield;

	private float lastHitTime; // time of last hit

	// Use this for initialization
	void Start(){
		reset();
		foreach (Doable boable in doOnDeath){
			boable.addSender(gameObject);
		}
	}

	// Update is called once per frame
	void FixedUpdate(){
		if (shield < maxShield &&
		    Time.timeSinceLevelLoad - lastHitTime >= shieldRegenCooldown){
			shield += shieldRegenSpeed;
			if (shield > maxShield) shield = maxShield;
		}
	}

	/// <summary>
	/// used for player respawn
	/// </summary>
	public void reset(){
		hp = initialHp;
		shield = initialShield;
		dead = false;
	}

	public void gainHp(int gain){
		hp += gain;
		if (hp > maxHp) hp = maxHp;
	}

	public void gainShield(int gain){
		shield += gain;
		if (shield > maxShield) shield = maxShield;
	}

	public void takeDamage(int damage){
		if (dead) return;
		lastHitTime = Time.timeSinceLevelLoad;
		shield -= damage;
		if (shield < 0){
			hp += shield;
			shield = 0;
			if (hp < 0){
				hp = 0;
				life--;
				dead = true;
				foreach (Doable boable in doOnDeath){
					boable.signal(gameObject);
				}
				if (destroyOnDeath) Destroy(gameObject);
			}
		}
	}
}
