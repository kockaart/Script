using UnityEngine;
using System.Collections;

public class LoadImage : MonoBehaviour {
	
	public string url = "file:///c:/soccer/player_photo.png";
	public string  urlN = "file:///c:/soccer/player_name.txt";
	public Texture2D photo;
	public string name= "Please set name";
	
	IEnumerator Start() {
		WWW www = new WWW(url);
		WWW wwwN = new WWW(urlN);
		yield return www;
		photo = www.texture;
		renderer.material.mainTexture = photo;
		yield return wwwN;
		name = wwwN.text;
	}
//	void OnGUI(){
//		GUI.Box(new Rect(0, Screen.height*10/20, 460, 120), name);
//	}
	
}