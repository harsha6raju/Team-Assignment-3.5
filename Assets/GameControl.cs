using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	public int gameLength = 60;
	public int turnLength = 2;
	public static int score = 0;
	public int plusScore = 5;
	public float gameTimer = 0;
	public float turnTimer;
	public static GameObject [,] allCubes;
	public GameObject startCubes;
	public GameObject nextCubeGuiText;
	public GameObject newCube;
	public GameObject startGuiText;
	public int numCubesWide = 8;
	public int numCubesTall = 5;
	public static Color [] cubeColors;
	public static bool cubeInSpawnArea = false;
	public static bool gameBeingPlayed = false;
	public static bool activeCubey = false;
	public int destroyCubeX;
	public int destroyCubeY;
	public int [] cubeMemoryArray;
	public GameObject destroyThisCube;
	public GameObject [] destroyOneOfTheseCubes;

	//WHERE I AM LEAVING OFF RIGHT NOW FOR ALL SCRIPTS IN THIS PROGRAM:
	
	//I need to make it so in the New Cube Behaviour script, when i push down a key, the cube can only go to a white cube, not a previously colored cube/
	
	// Use this for initialization
	void Start () {
		
		cubeMemoryArray = new int [5];
		//Instantiate (startGuiText,new Vector2 (3,4), new Quaternion (0,0,0,0));
		
		//make array of colors for random colored cubes
		cubeColors = new Color [5];
		cubeColors [0] = Color.black;
		cubeColors [1] = Color.blue;
		cubeColors [2] = Color.green;
		cubeColors [3] = Color.red;
		cubeColors [4] = Color.yellow;
		
		//create nextcube text
		Instantiate (nextCubeGuiText, new Vector3 ( -8, 7, 2), new Quaternion (0,0,0,0));
		
		//create White Cube Array
		allCubes = new GameObject [numCubesWide, numCubesTall];
		
		for (int x = 0; x < numCubesWide; x++){
			for ( int y = 0; y < numCubesTall; y++){
				allCubes [x, y] = (GameObject) Instantiate(startCubes, new Vector3 (x*3 - 11, y*2 - 5, 2), new Quaternion (0,0,0,0));
				allCubes [x, y].GetComponent<WhiteCubeBehaviour>().startX = x;
				allCubes [x, y].GetComponent<WhiteCubeBehaviour>().startY = y;	
			//}
			}
		}
		
			
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		
				gameTimer = Time.deltaTime + gameTimer;
				turnTimer = Time.deltaTime + turnTimer;
		
				if (gameTimer > gameLength){
					gameTimer = 0;
					print ("gameover");	
					
				}
		
				if (turnTimer > turnLength){
					turnTimer = 0;
					print ("turn");
					TurnAction();
			
				}
			}	
		
		
	

	//In this method we go through all the action that must happen every turn.
	//this includes destroying the new colored cube if it hasn't moved
	
	void TurnAction () {
		if (cubeInSpawnArea == true){
			Destroy(GameObject.FindWithTag("newCube"));
			
			DestroyGridCubes ();
		}
	
		Instantiate (newCube, new Vector3 (0,7,2), new Quaternion (0,0,0,0));
	
		cubeInSpawnArea = true;
		
		
	}

	//void GamePlayStart (){
//		
//		gameTimer = 0;
//		turnTimer = 0;
//		
//		
//		//make array of colors for random colored cubes
//		cubeColors = new Color [5];
//		cubeColors [0] = Color.black;
//		cubeColors [1] = Color.blue;
//		cubeColors [2] = Color.green;
//		cubeColors [3] = Color.red;
//		cubeColors [4] = Color.yellow;
//		
//		//create nextcube text
//		Instantiate (nextCubeGuiText, new Vector3 ( -8, 7, 2), new Quaternion (0,0,0,0));
//		
//		//create White Cube Array
//		allCubes = new GameObject [numCubesWide, numCubesTall];
//		
//		for (int x = 0; x < numCubesWide; x++){
//			for ( int y = 0; y < numCubesTall; y++){
//				allCubes [x, y] = (GameObject) Instantiate(startCubes, new Vector3 (x*3 - 11, y*2 - 5, 2), new Quaternion (0,0,0,0));
//				allCubes [x, y].GetComponent<WhiteCubeBehaviour>().startX = x;
//				allCubes [x, y].GetComponent<WhiteCubeBehaviour>().startY = y;	
//			}
//		}
//		
//		
		
	//}
	

	void DestroyGridCubes () {

	
		destroyCubeX = Random.Range (0,8);
		destroyCubeY = Random.Range (0,5);
		if (allCubes[destroyCubeX, destroyCubeY] != null && allCubes[destroyCubeX, destroyCubeY].renderer.material.color == Color.white){
			
			if (allCubes[destroyCubeX, destroyCubeY].renderer.material.color == Color.white){
			
				Destroy(allCubes [destroyCubeX, destroyCubeY]);
				
				if (score > 0){
					
					score = score - 1;
				
				}
				
			}
		}
		
		else {
			
			DestroyGridCubes ();
			
		}
	
	
}
	
	
	}
