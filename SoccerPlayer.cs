using UnityEngine;
using System.Collections;

public class SoccerPlayer : MonoBehaviour {
	
	public LoadImage loadImage;
	
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
	public Texture2D result;
	public Texture2D silhouette;
	public Texture2D picture;
	public MovieTexture loop;
	public MovieTexture lf;
	public MovieTexture lg;
	public MovieTexture cf;
	public MovieTexture cg;
	public MovieTexture rf;
	public MovieTexture rg;
	public MovieTexture goal;
	public MovieTexture fail;
	
	public int counter=0;
	public int counter2=0;
	public int animation=0;
	public int animationTime=800;
	public int time=70;
	public int time2=240;
	public int kicksLeft=5;
	public int score=0;
	public int no=0;
	public int random=0;
	public bool play=false;
	public bool approach=true;
	
	public float previous=0;
	public float previous1=0;
	public float previous2=0;
	public float previous3=0;
	public float previous4=0;
	public float previous5=0;
	public float previous6=0;
	public float previous7=0;

	//for kick detection, whether legs moved or not
	public float right=0;
	public float right1=0;
	public float right2=0;
	public float right3=0;
	public float right4=0;
	public float right5=0;
	public float left=0;
	public float left1=0;
	public float left2=0;
	public float left3=0;
	public float left4=0;
	public float left5=0;
	public float sensitivity = 0.5f;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		posRight = Foot_Right.transform.localPosition;
		posLeft = Foot_Left.transform.localPosition;
		posHead = Head.transform.localPosition;
		
		if (lf.isPlaying)	play = true;
		else lf.Stop();
		if (lg.isPlaying)	play = true;
		else lg.Stop();
		if (rf.isPlaying)	play = true;
		else rf.Stop();
		if (rg.isPlaying)	play = true;
		else rg.Stop();
		if (cf.isPlaying)	play = true;
		else cf.Stop();
		if (cg.isPlaying)	play = true;
		else cg.Stop();
		
		if (lf.isPlaying)	play = true;
		else if (lg.isPlaying)	play = true;
		else if (rf.isPlaying)	play = true;
		else if (rg.isPlaying)	play = true;
		else if (cf.isPlaying)	play = true;
		else if (cg.isPlaying)	play = true;
		else play = false;
		
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
		right5 = Foot_Right.transform.localPosition.z;
		left = left1;
		left1 = left2;
		left2 = left3;
		left3 = left4;
		left4 = left5;
		left5 = Foot_Left.transform.localPosition.z;
		
		
		//		if (Input.anyKey){
		//			Debug.Log("A key or mouse click has been detected");
		//
		//		}
	}
	
	public GUISkin menuSkin;
	public GUISkin menuSkin2;
	public GUISkin menuSkin3;
	public GUISkin menuSkin4;
	public string kicks = "KICKS REMAINING: ";
	public string name = "ALEXANDR!";
	public string comment1 = "YOU COULD DO BETTER COWBOY!";
	public string comment2 = "THAT'S QUITE IMPRESSIVE!";
	public string comment3 = "YOU ARE AN AWESOME KICKER!";
	
	void OnGUI()
	{
		if (lf.isPlaying)	play = true;
		else lf.Stop();
		if (lg.isPlaying)	play = true;
		else lg.Stop();
		if (rf.isPlaying)	play = true;
		else rf.Stop();
		if (rg.isPlaying)	play = true;
		else rg.Stop();
		if (cf.isPlaying)	play = true;
		else cf.Stop();
		if (cg.isPlaying)	play = true;
		else cg.Stop();
		
		if (lf.isPlaying)	play = true;
		else if (lg.isPlaying)	play = true;
		else if (rf.isPlaying)	play = true;
		else if (rg.isPlaying)	play = true;
		else if (cf.isPlaying)	play = true;
		else if (cg.isPlaying)	play = true;
		else play = false;
		
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), loop);
		loop.Play();
		loop.loop = true;
		if (play) {
			if (random==0){
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), lf);
				lf.Play();	
			}
			if (random==1){
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), lg);
				lg.Play();
			}
			if (random==2){
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), rf);
				rf.Play();
			}
			if (random==3) {
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), rg);
				rg.Play();
			}
			if (random==4){
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), cf);
				cf.Play();
			}
			if (random==5) {
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), cg);
				cg.Play();
			}
			
		}
		//player present
		if (posRight.z != 0 && previous != Head.transform.localPosition.z) { 
			approach = false;
			if (kicksLeft==0 && counter2<time2 && counter2>0 && !play) counter2++;
			if (kicksLeft>0 && !play && animation>animationTime){	
				counter++;
				if (counter>8  && ((right5-right)>sensitivity || ((left5-left)>sensitivity))){
					random = Random.Range(0, 5);
					if (random==0){
						GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), lf);
						lf.Play();	
					}
					if (random==1){
						GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), lg);
						lg.Play();
						score++;
					}
					if (random==2){
						GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), rf);
						rf.Play();
					}
					if (random==3) {
						GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), rg);
						rg.Play();
						score++;
					}
					if (random==4){
						GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), cf);
						cf.Play();
					}
					if (random==5) {
						GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), cg);
						cg.Play();
						score++;
					}
					counter=0;
					kicksLeft--;
				}
			}
		}
		
		if (counter>0 && counter<time && kicksLeft>0 && approach== false && animation>animationTime && !play){
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), loop);
			loop.Play();
			loop.loop = true;
			//GUI.Box (new Rect (50, Screen.height-100,460,90), (kicks + kicksLeft));
			if(kicksLeft==5){
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), leftK5);
			}
			if(kicksLeft==4){
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), leftK4);
			}
			if(kicksLeft==3){
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), leftK3);
			}
			if(kicksLeft==2){
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), leftK2);
			}
			if(kicksLeft==1){
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), leftK1);
			}
			GUI.skin = menuSkin2;
			GUI.Box (new Rect (Screen.width-500, Screen.height-170,360,90), name);
		}
		
		if (play == false && approach == false && animation>animationTime)
			GUI.DrawTexture(new Rect(Screen.width/2-135, 160, 263, 800), silhouette);
		
		if (kicksLeft==0 && counter2<time2 && counter2>0 & !play){
			//if (counter2==1 || counter2==30) loadImage.Load();
			plane.active=true;
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), result);
			GUI.skin = menuSkin3;
			GUI.Box (new Rect (Screen.width/4, Screen.height*5/20,600,60), comment3);
			GUI.skin = menuSkin4;
			GUI.Box (new Rect (Screen.width/4, Screen.height*6/20,560,90), name);
			GUI.Box (new Rect (Screen.width/4, Screen.height*8/20,360,90), (score + "/5"));
			GUI.DrawTexture(new Rect(Screen.width*3/40, Screen.height*4/20, 324, 576), picture);
			//GUI.Box (new Rect (600, 470,360,90), "picture");
			GUI.skin = menuSkin3;
			GUI.Box (new Rect (Screen.width/4, Screen.height*12/20,650,90), "LIKE YOUR result on FB/adress!");
			if (counter2==50 && score>2){
				Application.CaptureScreenshot(no + ". " +  name + " " + score + " goal.png", 4);
				no++;
			}
			//*screenshot comes and made here
			counter2++;
		}
		else plane.active=false;

		if (posRight.z == 0 | previous == Head.transform.localPosition.z) { 
			kicksLeft = 5;
			approach=true;
			counter2 = 0;
		}
		if (kicksLeft==0 && !play ){
			if (counter2==0) counter2++;
			if (counter2>=time2){
				kicksLeft = 5;
				approach=true;
				counter2 = 0;
			}
		}
		if (approach) {
			animation=0;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), come);
		}
		if (!approach && animation<=animationTime) 
		{
			animation=animation+80;
			GUI.DrawTexture (new Rect (0-2*animation, 0-animation, (Screen.width+(4*animation)), (Screen.height)+(2*animation)), come);	
		} 
	}
}