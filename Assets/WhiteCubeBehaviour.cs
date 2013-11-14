using UnityEngine;
using System.Collections;

public class WhiteCubeBehaviour : MonoBehaviour {
	public int startX;
	public int startY;
	public bool activeCube = false;
	public GameObject [] activeCubes;
	public GameObject adjacentCube;
	public int cubeColorMemory;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	//make sure correct tags exist on the cube
		if (renderer.material.color != Color.white && renderer.material.color != Color.gray && activeCube == false){
		 
			transform.gameObject.tag = "coloredGridCube";
			
			
		}
		
		if (renderer.material.color == Color.white){
		 
			transform.gameObject.tag = "whiteCube";
			
			
		}
		
		//set cube's memory of its own color
		
		SetCubeColorMemory ();
	}
	
	
		
	
			
	
	
	void SetCubeColorMemory (){
		
		if (renderer.material.color == Color.black){
		
			cubeColorMemory = 0;
			
		}
		
		if (renderer.material.color == Color.blue){
		
			cubeColorMemory = 1;
			
		}
		
		if (renderer.material.color == Color.green){
		
			cubeColorMemory = 2;
			
		}
		
		if (renderer.material.color == Color.red){
		
			cubeColorMemory = 3;
			
		}
		
		if (renderer.material.color == Color.yellow){
		
			cubeColorMemory = 4;
			
		}
		
		
	}
	
	void OnMouseDown () {
	//find out if this is a colored grid cube, an active cube, and if it is then activate/deactivate accordingly
		//first check is for if there are no active cubes and this one is colored
		if (gameObject.tag == "coloredGridCube" && GameControl.activeCubey == false && activeCube == false){
			
			//activate this one
			transform.localScale = new Vector3 (2,2,2);
			transform.gameObject.tag = "doubleSizeCube";
			activeCube = true;
			GameControl.activeCubey = true;
			
		}
		//second check is if there is already an active cube but this one is colored
		else if (gameObject.tag == "coloredGridCube" && GameControl.activeCubey == true && activeCube == false){
			//take any active cubes and make them back to normal color cubes
			activeCubes = GameObject.FindGameObjectsWithTag("doubleSizeCube");
			
			foreach (GameObject active in activeCubes){
				
				active.transform.gameObject.tag = "coloredGridCube";
				active.transform.localScale = new Vector3 (1,1,1);
				active.GetComponent<WhiteCubeBehaviour>().activeCube = false;
				
			}
			//activate this one
			transform.localScale = new Vector3 (2,2,2);
			transform.gameObject.tag = "doubleSizeCube";
			GameControl.activeCubey = true;
			activeCube = true;
			
			
		}
		//check if this one is active and colored
		else if (gameObject.tag == "doubleSizeCube" && GameControl.activeCubey == true && activeCube == true){
		//deactivate it
			transform.localScale = new Vector3 (1,1,1);
			transform.gameObject.tag = "coloredGridCube";
			GameControl.activeCubey = false;
			activeCube = false;
		}
		
		//check if this is a white cube that was clicked and there are other active cubes adjacent
		
		else if (gameObject.tag == "whiteCube" && GameControl.activeCubey == true){
		
			adjacentCube = GameObject.FindGameObjectWithTag("doubleSizeCube");
			//check if the adjacent cube is close enough to be moved to the clicked cube
			if ((((adjacentCube.GetComponent<WhiteCubeBehaviour>().startX == (startX + 1)) || (adjacentCube.GetComponent<WhiteCubeBehaviour>().startX == (startX - 1))) || ((adjacentCube.GetComponent<WhiteCubeBehaviour>().startY == (startY + 1)) || (adjacentCube.GetComponent<WhiteCubeBehaviour>().startY == (startY - 1))))){
				if ((((adjacentCube.GetComponent<WhiteCubeBehaviour>().startX < (startX + 2)) && (adjacentCube.GetComponent<WhiteCubeBehaviour>().startX > (startX - 2))) && ((adjacentCube.GetComponent<WhiteCubeBehaviour>().startY < (startY + 2)) && (adjacentCube.GetComponent<WhiteCubeBehaviour>().startY > (startY - 2))))){
				//make the clicked cube the adjacent cubes color
				renderer.material.color = adjacentCube.renderer.material.color;
				//make the adjacent cube back to deactivated white
				adjacentCube.transform.gameObject.tag = "whiteCube";
				adjacentCube.transform.localScale = new Vector3 (1,1,1);
				adjacentCube.transform.renderer.material.color = Color.white;
				adjacentCube.GetComponent<WhiteCubeBehaviour>().activeCube = false;
				
				//"activate" the clicked cube
				
				transform.localScale = new Vector3 (2,2,2);
				transform.gameObject.tag = "doubleSizeCube";
				GameControl.activeCubey = true;
				activeCube = true;
			}
			}
				
			
			
			
		}
		
	
			
	
	}
	
	
}
