using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Menu : MonoBehaviour {
	
	static  public int CubeNumX =  20;
	static  public int CubeNumY = 30;

	
	static public int selGridInt = 0;
	static public int CubeSize = 16  ;
		
	static public string[] NamesArr;
	
	void Start () {
		var sr = new StreamReader(Application.dataPath + "/levels/" + "levels.txt");
		var fileContents = sr.ReadToEnd();
		NamesArr = fileContents.Split(',');
		sr.Close(); 
	}
	
	void Update () {
	}
		
	void OnGUI () {
		selGridInt = GUI.SelectionGrid(new Rect(25, 25, 150, 100), selGridInt, NamesArr, 2);
		if (GUI.Button (new Rect (Screen.width/2 -50 , 20,100,40), "Builder")) {
			Application.LoadLevel("Builder");
		}
		if (GUI.Button (new Rect (Screen.width/2 -50 , 70,100,40), "Play")) {
			Application.LoadLevel("Game");
		}
	}
}
