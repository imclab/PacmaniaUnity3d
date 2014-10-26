using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class BuilderLabyrihth : MonoBehaviour
{

	
		public GUIText SaveError ;
		public GameObject[,]  CubesOnScene;
		static public int CubeType = 1 ; // 1 - wall 2-Ghost Spawn 3-Player Spawn
		static public bool GhostSpawner = false;
		static public bool PlayerSpawner = false;
		static public bool OnMouseFlag = false;
		public string stringToEdit = "";
	
		void Start ()
		{
			
		stringToEdit = "Level" + (	Menu.NamesArr.Length + 1 ).ToString();
		CubesOnScene = new GameObject[Menu.CubeNumX, Menu.CubeNumY];
		
		
		
		for (var i = 0; i< Menu.CubeNumX; i ++) {
						for (var j = 0; j<Menu.CubeNumY; j++) {
								CubesOnScene [i, j] = GameObject.CreatePrimitive (PrimitiveType.Cube) as GameObject;
								CubesOnScene [i, j].name = "Wall";
								CubesOnScene [i, j].transform.renderer.material.color = Color.white;
								CubesOnScene [i, j].AddComponent ("BuilderWallObject");
								CubesOnScene [i, j].transform.position = new Vector3 (( (Menu.CubeNumX*Menu.CubeSize) / -2 + Menu.CubeSize / 2) + i * Menu.CubeSize, ( (Menu.CubeNumY*Menu.CubeSize) / -2 + Menu.CubeSize / 2) + j * Menu.CubeSize, -1);
								CubesOnScene [i, j].transform.localScale = new Vector3 (Menu.CubeSize, Menu.CubeSize, Menu.CubeSize);
								if (i == 0 || j == 0 || i + 1 == Menu.CubeNumX || j + 1 == Menu.CubeNumY ) {
										CubesOnScene [i, j].transform.renderer.material.color = Color.green;
								}
						}
				}
		}

		void ColorRemove ()
		{
				for (var i = 0; i< Menu.CubeNumX; i ++) {
						for (var j = 0; j<Menu.CubeNumY; j++) {
								CubesOnScene [i, j].transform.renderer.material.color = Color.white;
								if (i == 0 || j == 0 || i + 1 == Menu.CubeNumX || j + 1 == Menu.CubeNumY ) {
										CubesOnScene [i, j].transform.renderer.material.color = Color.green;
								}
						}
				}
		GhostSpawner = false;
		PlayerSpawner = false;
		CubeType = 1;
		}

		void SaveLevel ()
		{
				if (GhostSpawner == false || PlayerSpawner == false) {
					SaveError.text = "Set ghost/player spawners";
				} else {
						int[,] LevelArr = new int [ Menu.CubeNumX, Menu.CubeNumY];
						for (var i = 0; i<  Menu.CubeNumX; i ++) {
								for (var j = 0; j< Menu.CubeNumY; j++) {
										if (CubesOnScene [i, j] .renderer.material.color == Color.yellow) {
												LevelArr [i, j] = 3;
										} else 
								if (CubesOnScene [i, j] .renderer.material.color == Color.red) {
												LevelArr [i, j] = 2;
										} else if (CubesOnScene [i, j] .renderer.material.color != Color.white) {
												LevelArr [i, j] = 1;
										} else {
												LevelArr [i, j] = 0;
										}
								}
						}
						StreamWriter writer = new StreamWriter (Application.dataPath + "/levels/"+stringToEdit+".txt"); //Сохраняем матрицу уровня в отдельный файл
						for (var i = 0; i<  Menu.CubeNumX; i ++) {
								for (var j = 0; j< Menu.CubeNumY; j++) {
										writer.Write (LevelArr [i, j]);
								}
						}
						writer.Close ();
						StreamWriter WriteName = new StreamWriter (Application.dataPath + "/levels/"+"levels.txt",true); // Сохраняем имя уровня в дополнительный файл ( решение для большинства платформ )
						WriteName.Write (","+stringToEdit); 
						WriteName.Close();
				Application.LoadLevel("Menu");
				}
		}
		void Update ()
		{
				if (Input.GetMouseButtonDown (0)) {
						OnMouseFlag = true;
				} 
				if (Input.GetMouseButtonUp (0)) {
						OnMouseFlag = false;
				}
		}

		void OnGUI ()
		{
			int buttonWidth = 100 ;
			GUIStyle style = GUI.skin.GetStyle ("Button");
			style.fontSize =12  ;
			if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth - 10 - buttonWidth , 10, buttonWidth, Menu.CubeSize+5), "Wall")) {
							CubeType = 1;
					}
			if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth , 10, buttonWidth,Menu.CubeSize+5), "Ghost Spawn")) {
							CubeType = 2;
					}
			if (GUI.Button (new Rect (Screen.width / 2  + 10  , 10, buttonWidth, Menu.CubeSize+5), "Player Spawn")) {
							CubeType = 3;
					}
			if (GUI.Button (new Rect (Screen.width / 2   + 20 + buttonWidth , 10, buttonWidth,Menu.CubeSize+5), "Clear")) {
							ColorRemove ();
					}

			if (GUI.Button (new Rect (Screen.width / 2  - buttonWidth/2 , Screen.height - Menu.CubeSize-10, buttonWidth, Menu.CubeSize+5), "Save")) {
							SaveLevel();
					}

			if (GUI.Button (new Rect (Screen.width / 2 + 10 + buttonWidth /2 , Screen.height - Menu.CubeSize-10, buttonWidth, Menu.CubeSize+5), "Exit")) {		
				Application.LoadLevel("Menu");
			}
			
			stringToEdit = GUI.TextField (new Rect (Screen.width / 2 - buttonWidth - buttonWidth/2 - 10,  Screen.height - Menu.CubeSize-10, 100, Menu.CubeSize+5),stringToEdit);
					

		}
	
	
}
