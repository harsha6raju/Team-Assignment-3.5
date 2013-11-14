using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	
	public GameObject GamePlayer;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		
		if (GUI.Button(new Rect(Screen.width/4,Screen.height/4,400,200), "Start")){
			Instantiate (GamePlayer, new Vector3 (0,0,0), new Quaternion (0,0,0,0));	
			
			Destroy(gameObject);
		}
		
		
		
	}
		
	
}
