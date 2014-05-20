using UnityEngine;
using System.Collections;

public class menu1 : MenuBase {

	private bool curropt1=true; private bool curropt2=false; private bool curropt3=false;

	void OnGUI() {		
		GUI.skin = menuSkin;


		if(GUI.Toggle(new Rect(Screen.width/2-360,Screen.height-600,200,40),
			              curropt1, new GUIContent("Head")))
		{
			PlayerPrefs.SetString("control", "head");
			curropt1=true;
			curropt2=false;
			curropt3=false;
		}
		if(GUI.Toggle(new Rect(Screen.width/2-360,Screen.height-550,200,40),
		              curropt2, new GUIContent("Left Hand")))
		{
			PlayerPrefs.SetString("control", "left");
			curropt2=true;
			curropt1=false;
			curropt3=false;
		}
		if(GUI.Toggle(new Rect(Screen.width/2-360,Screen.height-500,220,50),
		              curropt3, new GUIContent("Right Hand")))
		{
			PlayerPrefs.SetString("control", "right");	
			curropt3=true;
			curropt1=false;
			curropt2=false;	
		}

		GUI.Box (new Rect(Screen.width/2-90, 30, 180, (float)(Screen.height)), "OPTIONS");

		PlayerPrefs.SetFloat("sense", GUI.HorizontalSlider(new Rect(Screen.width/2-340, Screen.height-400, 150, 30), PlayerPrefs.GetFloat("sense"), 1.8f , 10f));
		GUI.Box (new Rect (Screen.width/2-360, Screen.height-370,380,60), ("Sensitivity: " + ((int)(PlayerPrefs.GetFloat("sense")*10f)-4)));

		PlayerPrefs.SetFloat("speed", GUI.HorizontalSlider(new Rect(Screen.width/2-340, Screen.height-300, 150, 30), PlayerPrefs.GetFloat("speed"), 3.2f , 7.6f));
		GUI.Box (new Rect (Screen.width/2-360, Screen.height-270,240,60), ("Velocity: " + ((int)(PlayerPrefs.GetFloat("speed")*10)-31)));
		PlayerPrefs.SetInt("time", 10*(int)GUI.HorizontalSlider(new Rect(Screen.width/2-340, Screen.height-200, 150, 30), PlayerPrefs.GetInt("time")/10, 3f , 12f));
		GUI.Box (new Rect (Screen.width/2-360, Screen.height-170,360,60), ("Time: " + PlayerPrefs.GetInt("time")+ " seconds"));


		if (GUI.Button (new Rect (Screen.width/2+100, Screen.height/2-50,200,100), "Play")) {
			Application.LoadLevel (1);
		}
		if (GUI.Button(new Rect( (Screen.width ) / 2-160, Screen.height-50,320, 50), "www.e-motion.tk"))
		{
			Application.OpenURL("http://www.e-motion.tk");
		}
	}
}
