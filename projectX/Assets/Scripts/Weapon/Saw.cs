using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Weapon {

    public int damage;
	public float lastDamageTime = 0;
    [SerializeField] float rotateAmount = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, rotateAmount);
	}

	private void OnTriggerStay(Collider other){
		if (Time.timeSinceLevelLoad - lastDamageTime < 1) return;
		if (Global.isEnemy(other.gameObject, gameObject)){
			other.GetComponent<Health>().takeDamage(damage);
			lastDamageTime = Time.timeSinceLevelLoad;
		}
	}
}
