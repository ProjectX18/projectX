using UnityEngine;

// a basic bullet
public class Bullet : MonoBehaviour{

	public int damage;
	public float speed;
	public float dieRange;
	private float dieTime;

	// Use this for initialization
	void Start (){
		dieTime = dieRange / speed + Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		checkDeath();
		move();
	}

	private void checkDeath(){
		if (Time.timeSinceLevelLoad > dieTime){
			Destroy(gameObject);
		}
	}

	private void move(){
		transform.position += transform.forward * speed * Time.fixedDeltaTime;
	}

	private void OnTriggerEnter(Collider other){
		string enemyTag = CompareTag("Friendly") ? "Enemy" : "Friendly";
		if (other.CompareTag(enemyTag)){
			other.GetComponent<Health>().takeDamage(damage);
		}
		Destroy(gameObject);
	}
}
