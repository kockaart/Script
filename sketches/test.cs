using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class test : MonoBehaviour
{   
	private Color guiColor;
	public KinectManager km;
	public LoadImage lm;
	public float timeScale=0;
	public GameObject plane;


	public MovieTexture result;
	public MovieTexture result1;
	public MovieTexture result2;
	public MovieTexture result3;
	public MovieTexture result4;
	public MovieTexture result5;
	
	private MovieTexture movTexture;
	private MovieTexture resTexture;
	
	public int counter = 0;
	public int counter2 = 0;
	public int counter3 = 0;
	public int animation = 0;
	public int animationTime = 800;
	public int time2 = 240;
	public int kicksLeft = 5;
	public int score = 0;
	public int no = 0;
	public int random = 0;
	public bool play = false;
	public bool playResult = false;
	public bool approach = true;

	// Use this for initialization
	void Start()
	{
		guiColor = Color.white;
		resTexture = result;
		movTexture = result1;
	}
	
	// Update is called once per frame
	void Update()
	{

		Time.timeScale=2.2f;
		

		
		if(!playResult) plane.GetComponent<LoadImage>().enabled = false;
		if(playResult) plane.GetComponent<LoadImage>().enabled = true;
		
		//		if (Input.anyKey){
		//			Debug.Log("A key or mouse click has been detected");
		//		}
		
	}
	public GUISkin menuSkin1;
	public GUISkin menuSkin2;
	public GUISkin menuSkin3;
	public GUISkin menuSkin4;
	public string name = "Name!";
	//public string comment = "You are an awesome kicker!";
	public string like = "LIKE YOUR result on FB";
	public string link = "vk.com/cocaccola_ukr";
	
	void OnGUI()
	{


		if (!resTexture.isPlaying){
			if (!result.isPlaying) result.Stop();
			if (!result1.isPlaying)	result1.Stop();
			if (!result2.isPlaying)	result.Stop();
			if (!result3.isPlaying) result.Stop();
			if (!result4.isPlaying)	result.Stop();
			if (!result5.isPlaying)	result.Stop();
			renderer.enabled=false;			
		}
		
		if (resTexture.isPlaying){
			renderer.enabled=true;
			resTexture.Play();
			playResult = true;
		}
		else{
			playResult = false;
			renderer.enabled=false;
		}
		if (movTexture.isPlaying){
			play = true;
			counter3++;
		}
		else{
			play = false;
			counter3=0;

		}
		
		if (play && counter3>7)
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movTexture);
			movTexture.Play();
		}
		if (playResult)
		{
			resTexture.Play();
		}
		

		if (Input.anyKey) {
			print("click");
			resTexture=result;
			if(score==1) resTexture=result1;
			if(score==2) resTexture=result2;
			if(score==3) resTexture=result3;
			if(score==4) resTexture=result4;
			if(score==5) resTexture=result5;
			
			renderer.material.mainTexture = resTexture;
			resTexture.Play();
			playResult=true;
			renderer.enabled=true;
		}
		if ( playResult) {
			
			GUI.skin = menuSkin2;
			GUI.Box (new Rect (Screen.width / 2, Screen.height / 19, Screen.width / 2, Screen.height / 4), name);
			//			GUI.skin = menuSkin3;
			//			GUI.Box (new Rect (Screen.width *6 / 11, Screen.height * 5 / 20, Screen.width / 2, Screen.height / 9), comment);
			//			if (counter2 > 11) {
			//				GUI.skin = menuSkin4;
			//				GUI.Box (new Rect (Screen.width *6 / 11, Screen.height * 15/ 20, Screen.width /2, Screen.height / 9), like);
			//				GUI.Box (new Rect (Screen.width *6 / 11, Screen.height * 17 / 20, Screen.width /2, Screen.height / 9), link);
			//			}
			
			//*screenshot comes and made here
			if ((counter2 == 100 || counter2 == 134) && score > 2) {
				Application.CaptureScreenshot (no + ". " + name + " " + score + " goal.png", 4);
				no++;
				print("shot");
			}
			//			guiColor.a = 0.3f;
			//			GUI.color = guiColor; //sets all next gui color to transparent 0,5
			//			//guiTexture.color = colorT;
			//			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), shining);
			//			shining.Play ();
			//			GUI.color = Color.white; //sets it back
			
			counter2++;
		}
		
		//restart

		if (kicksLeft == 0 && counter2 > 20 && !play && !playResult)
		{           
			kicksLeft = 5;
			approach = true;
			counter2 = 0;
			score = 0;            
		}
		if (approach)
		{
			animation = 0;

		}
		if (!approach && animation <= animationTime)
		{
			animation = animation + 80;
		}
	}
}
