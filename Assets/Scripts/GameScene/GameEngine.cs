using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class GameEngine : MonoBehaviour {

	public GameObject[,]  Walls;
	
	void Start () {
	
		var Filename = Menu.NamesArr[Menu.selGridInt].ToString() + ".txt";
		var TextArrayFromFile = new StreamReader(Application.dataPath + "/levels/" + Filename);	
		var  LevelArray = TextArrayFromFile.ReadToEnd();
		TextArrayFromFile.Close();
		
		
		Walls = new GameObject[Menu.CubeNumX, Menu.CubeNumY];
		
		var ArrayCount = 0;
		var PlaneLevel = GameObject.CreatePrimitive (PrimitiveType.Plane) as GameObject;
		PlaneLevel.transform.localScale = new Vector3 (Menu.CubeSize* Menu.CubeNumX / 10 , 1, Menu.CubeSize * Menu.CubeNumY / 10);
		PlaneLevel.transform.rotation = Quaternion.Euler(-90,transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
		
		for (var i = 0; i< Menu.CubeNumX; i ++) {
					for (var j = 0; j < Menu.CubeNumY; j++) {
						if(  LevelArray[ArrayCount] != '0') {
								Walls [i, j] = GameObject.CreatePrimitive (PrimitiveType.Cube) as GameObject;
								Walls [i, j].name = "Wall";
								Walls [i, j].transform.renderer.material.color = Color.white;
								Walls [i, j].transform.position = new Vector3 (((Menu.CubeNumX * Menu.CubeSize) / -2 + Menu.CubeSize / 2) + i * Menu.CubeSize, ((Menu.CubeNumY*Menu.CubeSize) / -2 + Menu.CubeSize / 2) + j * Menu.CubeSize, -1);
								Walls [i, j].transform.localScale = new Vector3 (Menu.CubeSize, Menu.CubeSize, Menu.CubeSize);
								
								if ( LevelArray[ArrayCount] == '1' ) {
										Walls [i, j].transform.renderer.material.color = Color.green;
								} 
								if (LevelArray[ArrayCount] == '2' ) {
										Walls [i, j].transform.renderer.material.color = Color.red;
								}
								if (LevelArray[ArrayCount] == '3' ) {
										Walls [i, j].transform.renderer.material.color = Color.yellow;
								}
							}
								ArrayCount++;
						}
				}
	}
	
	
	void Update () {
			
	}
	void OnGUI ()
		{
			int buttonWidth = 100 ;
			GUIStyle style = GUI.skin.GetStyle ("Button");
			style.fontSize = 12  ;
			
			if (GUI.Button (new Rect (Screen.width / 2 + 10 + buttonWidth /2 , Screen.height - Menu.CubeSize-10, buttonWidth, Menu.CubeSize+5), "Exit")) {		
				Application.LoadLevel("Menu");
			}
		}
}
