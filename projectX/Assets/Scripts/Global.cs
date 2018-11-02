using System.Collections.Generic;
using UnityEngine;

public static class Global{

	public static GameObject player;
	public static Camera aimingCam;

	public static GameObject[] findEnemies(GameObject self){
		return GameObject.FindGameObjectsWithTag(enemyTag(self));
	}

	public static string enemyTag(GameObject self){
		return self.CompareTag("Friendly") ? "Enemy" : "Friendly";
	}

	public static GameObject nearestEnemyInSight(GameObject self, float maxDistance){
		float shortestDistance = float.PositiveInfinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in findEnemies(self)){
			if (!inSight(self, enemy, maxDistance)) continue;
			float distance = Vector3.Distance(self.transform.position, enemy.transform.position);
			if (distance < shortestDistance){
				shortestDistance = distance;
				nearestEnemy = enemy;
			}
		}

		return nearestEnemy;
	}

	public static bool inSight(GameObject self, GameObject target, float maxDistance){
		Vector3 origin = new Vector3(self.transform.position.x, 1.1f, self.transform.position.z);
		Vector3 direction = new Vector3(target.transform.position.x - origin.x, 
			0, target.transform.position.z - origin.z).normalized;
		Ray sight = new Ray(origin, direction);
		Debug.DrawRay(origin, direction * maxDistance);
		RaycastHit hit;
		return Physics.Raycast(sight, out hit, maxDistance) &&
		       hit.collider.gameObject == target;
	}
}
