using UnityEngine;
using System.Collections;

public class BuilderWallObject : MonoBehaviour
{

		public int X_cord = 0;
		public int Y_cord = 0;
		public int Type_number = 0;

		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{

	
		}

		void OnMouseEnter ()
		{
				if (BuilderLabyrihth.OnMouseFlag == true && BuilderLabyrihth.CubeType == 1) {
						if (renderer.material.color == Color.white) {
								transform.renderer.material.color = Color.blue;
						} else if (renderer.material.color == Color.blue) {
								transform.renderer.material.color = Color.white;
						}
				
				}		
		}

		void OnMouseDown ()
		{     
				if (renderer.material.color != Color.green) {
						if (BuilderLabyrihth.CubeType == 1  && 	transform.renderer.material.color == Color.white ) {
								transform.renderer.material.color = Color.blue;
						} else 
						if (BuilderLabyrihth.CubeType == 2 && BuilderLabyrihth.GhostSpawner == false && 	transform.renderer.material.color == Color.white ) {
								BuilderLabyrihth.GhostSpawner = true;
								transform.renderer.material.color = Color.red;
						} else 
						if (BuilderLabyrihth.CubeType == 3 && BuilderLabyrihth.PlayerSpawner == false && 	transform.renderer.material.color == Color.white ) {
								BuilderLabyrihth.PlayerSpawner = true;
								transform.renderer.material.color = Color.yellow;
						} else {
							if (renderer.material.color == Color.red) {
								BuilderLabyrihth.GhostSpawner = false;
							}
							if (renderer.material.color == Color.yellow) {
								BuilderLabyrihth.PlayerSpawner = false;
							}
							transform.renderer.material.color = Color.white;
						}
				}
		}
	

}
