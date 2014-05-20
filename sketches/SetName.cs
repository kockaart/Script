using UnityEngine;
using System.Collections;

public class SetName : MonoBehaviour {

	public MovieTexture movTexture;
	void Start() {
		renderer.material.mainTexture = movTexture;
		movTexture.Play();
	}

	public MovieTexture guimovie;
	public GUISkin menuSkin;
	public string first = "APPROACH THE LINE";
	public string second = "TO PLAY";
	public string name = "";
	void OnGUI() {
		GUI.skin = menuSkin;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), guimovie);
		GUI.Box (new Rect (Screen.width/2-360, Screen.height-270,240,60), ("APPROACH THE LINE"));
		GUI.Box (new Rect (Screen.width/2, Screen.height-170,360,60), ("TO PLAY"));
		name = GUI.TextField(new Rect(10, 10, 200, 20), name, 25);
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetButtonDown ("Jump")) {
//			if (renderer.material.mainTexture.isPlaying) 
//			{
//				renderer.material.mainTexture.Pause();
//			}
//			else {
//				renderer.material.mainTexture.Play();
//			}
//		}
	}
}