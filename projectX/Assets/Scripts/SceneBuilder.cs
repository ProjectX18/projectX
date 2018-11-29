using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SceneBuilder : MonoBehaviour{
	
	public GameObject obj;
	public GameObject g;
	public int xMin;
	public int xMax;
	public int yMin;
	public int yMax;
	
	void Start (){
		string[] lines = File.ReadAllLines("/Users/toby/Desktop/MazeLevel.csv");
		List<string[]> matrix = new List<string[]>();
		foreach (string line in lines){
			matrix.Add(line.Split(','));
		}

		for (int y = 0; y < matrix.Count; y++){
			for (int x = 0; x < matrix[0].Length; x++){
				GameObject structure;
				if (matrix[y][x] == "w"){
					structure = Instantiate(obj, transform);
					
				} else{
					structure = Instantiate(g, transform);
				}
				structure.name = obj.name + x + ", " + y;
				structure.transform.localPosition = new Vector3(x, 0, y);
			}
		}

//		for (int x = xMin; x <= xMax; x++){
//			for (int y = yMin; y <= yMax; y++){
//				var structure = Instantiate(obj, transform);
//				structure.name = obj.name + x + ", " + y;
//				structure.transform.localPosition = new Vector3(x, 0, y);
//			}
//		}
	}
}
