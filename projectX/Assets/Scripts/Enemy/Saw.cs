using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour {

    public int damage;
    [SerializeField] float rotateAmount = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, rotateAmount);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Friendly"))
            other.gameObject.GetComponent<Health>().takeDamage(damage);
    }
}
