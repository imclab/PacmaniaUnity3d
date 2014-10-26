using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class GameEngine : MonoBehaviour {

	static public GameObject[,]  Walls;
	public Camera SceneCam;
	
	public GameObject Player;

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
		PlaneLevel.transform.position = new Vector3(0,0,8);
		for (var i = 0; i< Menu.CubeNumX; i ++) {
					for (var j = 0; j < Menu.CubeNumY; j++) {
						if(  LevelArray[ArrayCount] != '0') {

								// 1 - wall 2-Ghost Spawn 3-Player Spawn
								if ( LevelArray[ArrayCount] == '1' ) {
									Walls [i, j] = GameObject.CreatePrimitive (PrimitiveType.Cube) as GameObject;
									Walls [i, j].name = "Wall";
									Walls [i, j].transform.renderer.material.color = Color.green;
									Walls [i, j].transform.position = new Vector3 (((Menu.CubeNumX * Menu.CubeSize) / -2 + Menu.CubeSize / 2) + i * Menu.CubeSize, ((Menu.CubeNumY*Menu.CubeSize) / -2 + Menu.CubeSize / 2) + j * Menu.CubeSize, -1);
									Walls [i, j].transform.localScale = new Vector3 (Menu.CubeSize, Menu.CubeSize, Menu.CubeSize);
								} 
								if (LevelArray[ArrayCount] == '2' ) {

								}
								if (LevelArray[ArrayCount] == '3' ) {
										//SceneCam.transform.position  =transform.position = new Vector3 (((Menu.CubeNumX * Menu.CubeSize) / -2 + Menu.CubeSize / 2) + i * Menu.CubeSize, ((Menu.CubeNumY*Menu.CubeSize) / -2 + Menu.CubeSize / 2) + j * Menu.CubeSize - 60, -60);
										Player.transform.position  = transform.position = new Vector3 (((Menu.CubeNumX * Menu.CubeSize) / -2 + Menu.CubeSize / 2) + i * Menu.CubeSize, ((Menu.CubeNumY*Menu.CubeSize) / -2 + Menu.CubeSize / 2) + j * Menu.CubeSize, -1);
										Player.transform.localScale = new Vector3 (Menu.CubeSize, Menu.CubeSize, Menu.CubeSize);
										PlayerClass.NumAtX = i;
										PlayerClass.NumAtY = j	;
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
