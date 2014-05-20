using UnityEngine;
using System.Collections;

public class SoccerMain : MonoBehaviour {
	
	public Vector3 posLeft;
	public Vector3 posRight;
	public Vector3 posHead;
	public GameObject Head;
	public GameObject Foot_Left;
	public GameObject Foot_Right;
	
	public GameObject approach;
	public GameObject loop;
	public GameObject lf;
	public GameObject lg;
	public GameObject cf;
	public GameObject cg;
	public GameObject rf;
	public GameObject rg;
	public GameObject goal;
	public GameObject fail;
	
	public int counter=0;
	public int counter2=0;
	public int time=70;
	public int time2=130;
	public int kicksLeft=5;
	public int score=0;
	public int random=0;
	public float previous=0;
	public float previous1=0;
	public float previous2=0;
	public float previous3=0;
	public float previous4=0;
	public float previous5=0;
	public float previous6=0;
	public float previous7=0;
	// Use this for initialization
	void Start () {
		approach.active = true;
		loop.active = true;
		PlayerPrefs.SetInt("On", 0);
	}
	
	// Update is called once per frame
	void Update () {
		posRight = Foot_Right.transform.localPosition;
		posHead = Head.transform.localPosition;
		//player present
		if (posRight.z != 0 && previous != Head.transform.localPosition.z) { 
			approach.active = false;
			if (kicksLeft>0 && PlayerPrefs.GetInt("On")==0 && !(lf.active || lg.active || rf.active ||  rg.active || cf.active || cg.active || goal.active || fail.active )){	
				counter++;
				if (kicksLeft==0 && counter2<time2 && counter2>0) counter2++;
				if (counter>=(time)){
					//	loop.active = false;
					loop.renderer.enabled = false;
					random = Random.Range(0, 5);
					if (random==0) lf.active=true;
					if (random==1){
						lg.active=true;
						score++;
					}
					if (random==2) rf.active=true;
					if (random==3) {
						rg.active=true;
						score++;
					}
					if (random==4) cf.active=true;
					if (random==5) {
						cg.active=true;
						score++;
					}
					counter=0;
					kicksLeft--;
				}
			}
			if (kicksLeft==0 && PlayerPrefs.GetInt("On")==0 && !(lf.active | lg.active | rf.active |  rg.active | cf.active | cg.active | goal.active | fail.active )){
				if (counter2==0) counter2++;
				if (counter2>=time2){
					kicksLeft = 5;
					approach.active = true;
					//loop.active = true;
					loop.renderer.enabled = true;
					counter2 = 0;
				}
			}
		}
		if (posRight.z == 0 | previous == Head.transform.localPosition.z) { 
			kicksLeft = 5;
			approach.active = true;
			//		loop.active = true;
			loop.renderer.enabled = true;
			counter2 = 0;
		}
		previous7 = Head.transform.localPosition.z;
		previous6 = previous7;
		previous5 = previous6;
		previous4 = previous5;
		previous3 = previous4;
		previous2 = previous3;
		previous1 = previous2;
		previous = previous1;
		//		if (Input.anyKey){
		//			Debug.Log("A key or mouse click has been detected");
		//
		//		}
	}
	
	public GUISkin menuSkin;
	public GUISkin menuSkin2;
	public GUISkin menuSkin3;
	public GUISkin menuSkin4;
	public string first = "KICK IT";
	public string kicks = "KICKS REMAINING: ";
	public string name = "ALEXANDR!";
	public string comment1 = "YOU COULD DO BETTER COWBOY!";
	public string comment2 = "THAT'S QUITE IMPRESSIVE!";
	public string comment3 = "YOU ARE AN AWESOME KICKER!";
	void OnGUI() {
		if (counter>0 && counter<time && kicksLeft>0 && approach.active == false){
			loop.renderer.enabled = true;
			GUI.skin = menuSkin;
			GUI.Box (new Rect (Screen.width-400, Screen.height-240,240,60), first);
			GUI.Box (new Rect (50, Screen.height-100,460,90), (kicks + kicksLeft));
			GUI.skin = menuSkin2;
			GUI.Box (new Rect (Screen.width-500, Screen.height-170,360,90), name);
		}
		if (kicksLeft==0 && counter2<time2 && counter2>0){
			counter2++;
			GUI.skin = menuSkin3;
			GUI.Box (new Rect (400, 270,560,60), comment3);
			GUI.skin = menuSkin4;
			GUI.Box (new Rect (400, 320,560,90), name);
			GUI.Box (new Rect (400, 400,360,90), (score + "/5"));
			GUI.Box (new Rect (100, 470,360,90), "picture");
			GUI.skin = menuSkin3;
			GUI.Box (new Rect (400, 530,500,90), "LIKE YOUR result on FB/adress!");
			Application.CaptureScreenshot(name + " " + score + " goal.png", 4);
			//*screenshot comes and made here
		}
	}
	
}
