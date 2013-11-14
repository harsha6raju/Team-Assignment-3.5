using UnityEngine;
using System.Collections;

public class NewCubeBehaviour : MonoBehaviour {
	
	public Color cubeColor;
	public int cubePlacement;
	
	// Use this for initialization
	void Start () {
		
		renderer.material.color = GameControl.cubeColors [Random.Range (0,5)];
		
		cubeColor = renderer.material.color;
		
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.Alpha1)){
		Destroy(gameObject);
			
		FindCubePlacement1();
		
			
		GameControl.allCubes[cubePlacement, 4].renderer.material.color = cubeColor;	
		GameControl.cubeInSpawnArea = false;	
		}
		
	if (Input.GetKeyDown(KeyCode.Alpha2)){
		Destroy(gameObject);
		
		FindCubePlacement2();
			
		GameControl.allCubes[cubePlacement, 3].renderer.material.color = cubeColor;
		GameControl.cubeInSpawnArea = false;	
		}
		
	if (Input.GetKeyDown(KeyCode.Alpha3)){
		Destroy(gameObject);
		
		FindCubePlacement3();	
			
		GameControl.allCubes[cubePlacement, 2].renderer.material.color = cubeColor;
		GameControl.cubeInSpawnArea = false;	
		}
		
	if (Input.GetKeyDown(KeyCode.Alpha4)){
		Destroy(gameObject);
		
		FindCubePlacement4();
			
		GameControl.allCubes[cubePlacement, 1].renderer.material.color = cubeColor;
		GameControl.cubeInSpawnArea = false;	
		}
		
	if (Input.GetKeyDown(KeyCode.Alpha5)){
		Destroy(gameObject);
		
		FindCubePlacement5();
			
		GameControl.allCubes[cubePlacement, 0].renderer.material.color = cubeColor;
		GameControl.cubeInSpawnArea = false;	
		}
	}
	
	void FindCubePlacement1 (){
	
		cubePlacement = Random.Range (0, 8);
		
		if (GameControl.allCubes[cubePlacement, 4] == null || GameControl.allCubes[cubePlacement, 4].renderer.material.color != Color.white){
			
			FindCubePlacement1();
			
		}
		
		
	}
	
	void FindCubePlacement2 (){
	
		cubePlacement = Random.Range (0, 8);
		
		if (GameControl.allCubes[cubePlacement, 3] == null || GameControl.allCubes[cubePlacement, 3].renderer.material.color != Color.white){
			
			FindCubePlacement2();
			
		}
		
		
	}
	
	void FindCubePlacement3 (){
	
		cubePlacement = Random.Range (0, 8);
		
		if (GameControl.allCubes[cubePlacement, 2] == null || GameControl.allCubes[cubePlacement, 2].renderer.material.color != Color.white){
			
			FindCubePlacement3();
			
		}
		
		
	}

	void FindCubePlacement4 (){
	
		cubePlacement = Random.Range (0, 8);
		
		if (GameControl.allCubes[cubePlacement, 1] == null || GameControl.allCubes[cubePlacement, 1].renderer.material.color != Color.white){
			
			FindCubePlacement4();
			
		}
		
		
	}
	
	void FindCubePlacement5 (){
	
		cubePlacement = Random.Range (0, 8);
		
		if (GameControl.allCubes[cubePlacement, 0] == null || GameControl.allCubes[cubePlacement, 0].renderer.material.color != Color.white){
			
			FindCubePlacement5();
			
		}
		
		
	}
}

