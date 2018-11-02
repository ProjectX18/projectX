using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// anything that can be destroyed must have this script, do not modify
/// </summary>
public class Health : MonoBehaviour{

	public int life;
	public bool dead;
	public bool destroyOnDeath;
	public Doable[] doOnDeath;
	public GameObject explosion;
	public Transform explosionLocation;

	[Header("UI")]
	public RectTransform canvas;
	public Image healthBar;
	public Image shieldBar;
	public GameObject shieldBG;

	[Header("Health")]
	public int initialHp;
	public int maxHp;
	private int hp;

	[Header("Shield")]
	public int initialShield;
	public int maxShield;
	public int shieldRegenCooldown; //time before shield regeneration
	public int shieldRegenSpeed; //speed of shield regeneration
	private float shield;

	private float lastHitTime; // time of last hit

	// Use this for initialization
	void Start(){
		reset();
		foreach (Doable boable in doOnDeath){
			boable.addSender(gameObject);
		}
	}

	private void Update(){
		canvas.rotation = Quaternion.Euler(0, 0, 0);
		healthBar.fillAmount = hp / (float) maxHp;
		shieldBG.SetActive(maxShield != 0);
		shieldBar.fillAmount = shield / maxShield;
		
		if (shield < maxShield && shield > 0 &&
		    Time.timeSinceLevelLoad - lastHitTime >= shieldRegenCooldown){
			shield += shieldRegenSpeed * Time.deltaTime;
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
			hp += (int)shield;
			shield = 0;
			if (hp <= 0){
				hp = 0;
				if (life != int.MaxValue) life--;
				dead = true;
				if (explosion != null){
					GameObject explode = Instantiate(explosion, explosionLocation.position, Quaternion.identity);
					Destroy(explode, 5);
				}
				foreach (Doable boable in doOnDeath){
					boable.signal(gameObject);
				}
				if (destroyOnDeath) Destroy(gameObject);
			}
		}
	}
}
