using UnityEngine;

public class SceneBuilder : MonoBehaviour{
	
	public GameObject obj;
	public int xMin;
	public int xMax;
	public int yMin;
	public int yMax;
	
	void Start () {
		for (int x = xMin; x <= xMax; x++){
			for (int y = yMin; y <= yMax; y++){
				var structure = Instantiate(obj, transform);
				structure.name = obj.name + x + ", " + y;
				structure.transform.localPosition = new Vector3(x, 0, y);
			}
		}
	}
}
