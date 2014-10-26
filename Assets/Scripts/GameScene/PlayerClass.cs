using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {

	// Use this for initialization
	static public int NumAtX = 0;
	static 	public int NumAtY = 0;

	public GameObject Player;

	public float Deltax = 0.0f;
	public float Deltay = 0.0f;

	public int Napr = 1;

	public float PlayerSpeed = 1f;
	void Start () {
	
	}
	
	// Update is called once per frame

	// 1 - down, 2 - up , 3 - right 4 - left;
	void Update () {
		if (Input.GetKeyDown ("down")) {
			Napr = 1;
		}
		if (Input.GetKeyDown ("up")) {
			Napr = 2;
		}
		if (Input.GetKeyDown ("right")) {
			Napr = 3;
		}
		if (Input.GetKeyDown ("left")) {
			Napr = 4;
		}

		if( Mathf.Abs(Deltay) >= Menu.CubeSize){
			if(Deltay>0){
				NumAtY+=1;
			} else {
				NumAtY-=1;
			}
			Deltay = 0.0f;
			print(NumAtY);
		}
		if( Mathf.Abs(Deltax) >= Menu.CubeSize){
			if(Deltax>0){
				NumAtX+=1;
			} else {
				NumAtX-=1;
			}
			Deltax = 0.0f;
		}


		if(Napr == 1 && ( GameEngine.Walls[NumAtX,NumAtY-1] == null ) ) {
			Player.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y- PlayerSpeed,Player.transform.position.z);
			Deltay-= PlayerSpeed;
		}
		if(Napr == 2 && ( GameEngine.Walls[NumAtX,NumAtY+1] == null ) ) {
			Player.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y+ PlayerSpeed,Player.transform.position.z);
			Deltay+= PlayerSpeed;
		}
		if(Napr == 3  && ( GameEngine.Walls[NumAtX+1,NumAtY] == null) ) {
			Player.transform.position = new Vector3(Player.transform.position.x+ PlayerSpeed,Player.transform.position.y,Player.transform.position.z);
			Deltax+= PlayerSpeed;
		}
		if(Napr == 4  && ( GameEngine.Walls[NumAtX-1,NumAtY] == null) ) {
			Player.transform.position = new Vector3(Player.transform.position.x- PlayerSpeed,Player.transform.position.y,Player.transform.position.z);
			Deltax-= PlayerSpeed;
		}
		
	}
}
