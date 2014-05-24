using UnityEngine;
using System.Collections;

public class test1 : MonoBehaviour {

	public int counter2=0;
	public MovieTexture resTexture;
	// Use this for initialization
	void Start () {
	
	}
	public GUISkin menuSkin2;
	public GUISkin menuSkin3;
	public GUISkin menuSkin4;
	public string name = "Name!";
	public string comment = "You are an awesome kicker!";
	public string like = "LIKE YOUR result on FB";
	public string link = "vk.com/cocaccola_ukr";
	// Update is called once per frame
	void OnGUI () {
		counter2++;
		renderer.material.mainTexture = resTexture;
		resTexture.Play();

		GUI.skin = menuSkin2;
		GUI.Box (new Rect (Screen.width / 2, Screen.height / 19, Screen.width / 2, Screen.height / 4), name);
		GUI.skin = menuSkin3;
		GUI.Box (new Rect (Screen.width *6 / 11, Screen.height * 5 / 20, Screen.width / 2, Screen.height / 9), comment);
		if (counter2 > 11) {
			GUI.skin = menuSkin4;
			GUI.Box (new Rect (Screen.width *6 / 11, Screen.height * 15/ 20, Screen.width /2, Screen.height / 9), like);
			GUI.Box (new Rect (Screen.width *6 / 11, Screen.height * 17 / 20, Screen.width /2, Screen.height / 9), link);
		}
	}
}
