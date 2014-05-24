using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class test : MonoBehaviour
{   
	private Color guiColor;
	public KinectManager km;
	public LoadImage lm;
	
	public Vector3 posLeft;
	public Vector3 posRight;
	public Vector3 posHead;
	public GameObject Head;
	public GameObject Foot_Left;
	public GameObject Foot_Right;
	public GameObject plane;
	
	public Texture2D come;
	public Texture2D leftK1;
	public Texture2D leftK2;
	public Texture2D leftK3;
	public Texture2D leftK4;
	public Texture2D leftK5;
	public MovieTexture loop;
	public MovieTexture lf;
	public MovieTexture lg;
	public MovieTexture cf;
	public MovieTexture cg;
	public MovieTexture rf;
	public MovieTexture rg;
	public MovieTexture shining;
	
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
	
	public float previous = 0;
	public float previous1 = 0;
	public float previous2 = 0;
	public float previous3 = 0;
	public float previous4 = 0;
	public float previous5 = 0;
	public float previous6 = 0;
	public float previous7 = 0;
	
	//for kick detection, whether legs moved or not
	private Vector3 right;
	private Vector3 right1;
	private Vector3 right2;
	private Vector3 right3;
	private Vector3 right4;
	private Vector3 right5;
	private Vector3 left;
	private Vector3 left1;
	private Vector3 left2;
	private Vector3 left3;
	private Vector3 left4;
	private Vector3 left5;
	
	public float sensitivity = 0.4f;
	public float threshold = 0.2f;
	
	// Use this for initialization
	void Start()
	{
		guiColor = Color.white;
		movTexture = lg;
		resTexture = lg;
	}
	
	// Update is called once per frame
	void Update()
	{
		posRight = Foot_Right.transform.localPosition;
		posLeft = Foot_Left.transform.localPosition;
		posHead = Head.transform.localPosition;
		
		previous = previous1;
		previous1 = previous2;
		previous2 = previous3;
		previous3 = previous4;
		previous4 = previous5;
		previous5 = previous6;
		previous6 = previous7;
		previous7 = Head.transform.localPosition.z;
		
		right = right1;
		right1 = right2;
		right2 = right3;
		right3 = right4;
		right4 = right5;
		right5 = Foot_Right.transform.localPosition;
		left = left1;
		left1 = left2;
		left2 = left3;
		left3 = left4;
		left4 = left5;
		left5 = Foot_Left.transform.localPosition;
		
		if(approach) plane.GetComponent<LoadImage>().enabled = false;
		if(!approach) plane.GetComponent<LoadImage>().enabled = true;
		
		//		if (Input.anyKey){
		//			Debug.Log("A key or mouse click has been detected");
		//		}
		
	}
	public GUISkin menuSkin1;
	public GUISkin menuSkin2;
	public GUISkin menuSkin3;
	public GUISkin menuSkin4;
	//public string name = "Name!";
	//public string comment = "You are an awesome kicker!";
	public string like = "LIKE YOUR result on FB";
	public string link = "vk.com/cocaccola_ukr";
	
	void OnGUI()
	{
		if (!movTexture.isPlaying){
			if (!lf.isPlaying) lf.Stop();
			if (!lg.isPlaying) lg.Stop();
			if (!rf.isPlaying) rf.Stop();
			if (!rg.isPlaying) rg.Stop();
			if (!cf.isPlaying) cf.Stop();
			if (!cg.isPlaying) cg.Stop();
		}
		if (!resTexture.isPlaying){
			if (!result.isPlaying){
				result.Stop();
				renderer.enabled=false;
			}
			if (!result1.isPlaying){
				result1.Stop();
				renderer.enabled=false;
			}
			if (!result2.isPlaying){
				result.Stop();
				renderer.enabled=false;
			}
			if (!result3.isPlaying){
				result.Stop();
				renderer.enabled=false;
			}
			if (!result4.isPlaying){
				result.Stop();				
				renderer.enabled=false;
			}
			if (!result5.isPlaying){ 
				result.Stop();
				renderer.enabled=false;
			}
		}
		
		if (resTexture.isPlaying){
			renderer.enabled=true;
			resTexture.Play();
			playResult = true;
		}
		else{
			playResult = false;
			renderer.enabled=false;
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), loop);
		}
		if (movTexture.isPlaying){
			play = true;
			counter3++;
		}
		else{
			play = false;
			counter3=0;
			loop.loop = true;
			loop.Play();
		}
		
		if (play && counter3>5)
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movTexture);
			movTexture.Play();
		}
		if (playResult)
		{
			resTexture.Play();
		}
		
		//player present
		if (posRight.z != 0 && previous != Head.transform.localPosition.z)
		{
			approach = false;
			
			if (kicksLeft == 0 && !play) counter2++;
			if (kicksLeft > 0 && !play && animation > animationTime)
			{		
				//print (Mathf.Abs((right5.x) - (right.x)));
				counter++;             
				//right leg
				if (counter > 8 && (right5.z - right.z) > sensitivity )
				{
					random = Random.Range(0, 2);
					//failed
					if (random == 0)
					{
						if (Mathf.Abs((right5.x) - (right.x)) < threshold )
						{
							cf.Stop();
							movTexture=cf;                      
						}
						else if (right5.x > right.x)
						{
							rf.Stop();
							movTexture=rf;                           
						}
						else {
							lf.Stop();
							movTexture=lf;                            
						}
					}
					//goal
					if (random == 1 || random == 2)
					{
						if (Mathf.Abs((right5.x) - (right.x)) < threshold)
						{
							cg.Stop();
							movTexture=cg;
						}
						else if (right5.x > right.x)
						{
							rg.Stop();
							movTexture=rg;                           
						}
						else
						{
							lg.Stop();
							movTexture=lg;
						}
						score++;
					}
					counter = 0;
					kicksLeft--;
					movTexture.Play();
				}
				//leftleg
				if (counter > 8 && (left5.z - left.z) > sensitivity)
				{
					random = Random.Range(0, 2);
					//failed
					if (random == 0)
					{
						if (Mathf.Abs((left5.x) - (left.x)) < threshold )
						{
							cf.Stop();
							movTexture=cf;                      
						}
						else if (left5.x > left.x)
						{
							rf.Stop();
							movTexture=rf;                           
						}
						else {
							lf.Stop();
							movTexture=lf;                            
						}
					}
					//goal
					if (random == 1 || random == 2)
					{
						if (Mathf.Abs((left5.x) - (left.x)) < threshold)
						{
							cg.Stop();
							movTexture=cg;
						}
						else if (left5.x > left.x)
						{
							rg.Stop();
							movTexture=rg;                           
						}
						else
						{
							lg.Stop();
							movTexture=lg;
						}
						score++;
					}
					counter = 0;
					kicksLeft--;
					movTexture.Play();
				}
			}
		}
		
		if (counter > 0 && kicksLeft > 0 && approach == false && animation > animationTime && !play)
		{
			if (kicksLeft == 5)
			{
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), leftK5);
			}
			if (kicksLeft == 4)
			{
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), leftK4);
			}
			if (kicksLeft == 3)
			{
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), leftK3);
			}
			if (kicksLeft == 2)
			{
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), leftK2);
			}
			if (kicksLeft == 1)
			{
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), leftK1);
			}
			GUI.skin = menuSkin1;
			GUI.Box(new Rect(Screen.width*7/10, Screen.height*9/11, 460, 120), lm.name);
		}
		
		if (!play && !playResult && approach == false && animation > animationTime)
		{
			//print ("silhouette");
			guiColor.a = 0.28f;
			GUI.color = guiColor; //sets all next gui color to transparent 0,5
			//guiTexture.color = colorT;
			GUI.DrawTexture(new Rect(Screen.width * 5 / 40, Screen.height, Screen.width * 15 / 20, -Screen.height * 8 / 10), km.usersLblTex);
			GUI.color = Color.white; //sets it back
		}
		if (kicksLeft == 0 && counter2 == 1 && !play) {
			if(score==0) resTexture=result;
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
		if (kicksLeft == 0 && counter2 > 1 && playResult) {
			
			GUI.skin = menuSkin2;
			GUI.Box (new Rect (Screen.width / 2, Screen.height / 19, Screen.width / 2, Screen.height / 4), lm.name);
			//			GUI.skin = menuSkin3;
			//			GUI.Box (new Rect (Screen.width *6 / 11, Screen.height * 5 / 20, Screen.width / 2, Screen.height / 9), comment);
			//			if (counter2 > 11) {
			//				GUI.skin = menuSkin4;
			//				GUI.Box (new Rect (Screen.width *6 / 11, Screen.height * 15/ 20, Screen.width /2, Screen.height / 9), like);
			//				GUI.Box (new Rect (Screen.width *6 / 11, Screen.height * 17 / 20, Screen.width /2, Screen.height / 9), link);
			//			}
			
			//*screenshot comes and made here
			if (counter2 == 11 && score > 2) {
				Application.CaptureScreenshot (no + ". " + lm.name + " " + score + " goal.png", 4);
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
		if (posRight.z == 0 | previous == Head.transform.localPosition.z)
		{
			kicksLeft = 1;
			approach = true;
			counter2 = 0;
			score = 0;
		}
		if (kicksLeft == 0 && counter2 > 20 && !play && !playResult)
		{           
			kicksLeft = 1;
			approach = true;
			counter2 = 0;
			score = 0;            
		}
		if (approach)
		{
			animation = 0;
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), come);
		}
		if (!approach && animation <= animationTime)
		{
			animation = animation + 80;
			GUI.DrawTexture(new Rect(0 - 2 * animation, 0 - animation, (Screen.width + (4 * animation)), (Screen.height) + (2 * animation)), come);
		}
	}
}
