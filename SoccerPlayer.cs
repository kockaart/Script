﻿using UnityEngine;
using System.Collections;

public class SoccerPlayer : MonoBehaviour
{

    public LoadImage loadImage;
    private Color guiColor;
    public KinectManager km;

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
    public MovieTexture shining;

    public MovieTexture result;
    public MovieTexture result1;
    public MovieTexture result2;
    public MovieTexture result3;
    public MovieTexture result4;
    public MovieTexture result5;

    public int counter = 0;
    public int counter2 = 0;
    public int animation = 0;
    public int animationTime = 800;
    public int time = 70;
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

    public float sensitivity = 0.5f;
    public float threshold = 0.5f;

    // Use this for initialization
    void Start()
    {
        guiColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        posRight = Foot_Right.transform.localPosition;
        posLeft = Foot_Left.transform.localPosition;
        posHead = Head.transform.localPosition;

        if (!lf.isPlaying) lf.Stop();
        if (!lg.isPlaying) lg.Stop();
        if (!rf.isPlaying) rf.Stop();
        if (!rg.isPlaying) rg.Stop();
        if (!cf.isPlaying) cf.Stop();
        if (!cg.isPlaying) cg.Stop();
        if (!result.isPlaying) result.Stop();
        if (!result1.isPlaying) result1.Stop();
        if (!result2.isPlaying) result.Stop();
        if (!result3.isPlaying) result.Stop();
        if (!result4.isPlaying) result.Stop();
        if (!result5.isPlaying) result.Stop();

        if (lf.isPlaying) play = true;
        else if (lg.isPlaying) play = true;
        else if (rf.isPlaying) play = true;
        else if (rg.isPlaying) play = true;
        else if (cf.isPlaying) play = true;
        else if (cg.isPlaying) play = true;
        else play = false;

        if (result.isPlaying) playResult = true;
        else if (result1.isPlaying) playResult = true;
        else if (result2.isPlaying) playResult = true;
        else if (result3.isPlaying) playResult = true;
        else if (result4.isPlaying) playResult = true;
        else if (result5.isPlaying) playResult = true;
        else playResult = false;

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

    void OnGUI()
    {
        if (!lf.isPlaying) lf.Stop();
        if (!lg.isPlaying) lg.Stop();
        if (!rf.isPlaying) rf.Stop();
        if (!rg.isPlaying) rg.Stop();
        if (!cf.isPlaying) cf.Stop();
        if (!cg.isPlaying) cg.Stop();
        if (!result.isPlaying) result.Stop();
        if (!result1.isPlaying) result1.Stop();
        if (!result2.isPlaying) result.Stop();
        if (!result3.isPlaying) result.Stop();
        if (!result4.isPlaying) result.Stop();
        if (!result5.isPlaying) result.Stop();

        if (lf.isPlaying) play = true;
        else if (lg.isPlaying) play = true;
        else if (rf.isPlaying) play = true;
        else if (rg.isPlaying) play = true;
        else if (cf.isPlaying) play = true;
        else if (cg.isPlaying) play = true;
        else play = false;

        if (result.isPlaying) playResult = true;
        else if (result1.isPlaying) playResult = true;
        else if (result2.isPlaying) playResult = true;
        else if (result3.isPlaying) playResult = true;
        else if (result4.isPlaying) playResult = true;
        else if (result5.isPlaying) playResult = true;
        else playResult = false;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), loop);
        loop.Play();
        loop.loop = true;
        if (play)
        {
            if (random == 0)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), lf);
                lf.Play();
            }
            if (random == 1)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), lg);
                lg.Play();
            }
            if (random == 2)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), rf);
                rf.Play();
            }
            if (random == 3)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), rg);
                rg.Play();
            }
            if (random == 4)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), cf);
                cf.Play();
            }
            if (random == 5)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), cg);
                cg.Play();
            }

        }
        //player present
        if (posRight.z != 0 && previous != Head.transform.localPosition.z)
        {
            approach = false;
            if (kicksLeft == 0 && counter2 < time2 && counter2 > 0 && !play) counter2++;
            if (kicksLeft > 0 && !play && animation > animationTime)
            {
                counter++;
                plane.active = true;
                //right leg
                if (counter > 8 && (right5.z - right.z) > sensitivity )
                {
                    random = Random.Range(0, 1);
                    //failed
                    if (random == 0)
                    {
                        if ((Math.Abs(right5.x) - Math.Abs(right.x)) < threshold )
                        {
                            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), cf);
                            cf.Play();
                        }
                        else if (right5.x > right.x)
                        {
                            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), rf);
                            rf.Play();
                        }
                        else {
                            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), lf);
                            lf.Play();
                        }
                    }
                    //goal
                    if (random == 1)
                    {
                        if ((Math.Abs(right5.x) - Math.Abs(right.x)) < threshold)
                        {
                            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), cg);
                            cg.Play();
                        }
                        else if (right5.x > right.x)
                        {
                            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), rg);
                            rg.Play();
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), lg);
                            lg.Play();
                        }
                        score++;
                    }
                    counter = 0;
                    kicksLeft--;
                }
                //leftleg
                if (counter > 8 && (left5.z - left.z) > sensitivity)
                {
                    random = Random.Range(0, 1);
                    //failed
                    if (random == 0)
                    {
                        if ((Math.Abs(left5.x) - Math.Abs(left.x)) < threshold)
                        {
                            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), cf);
                            cf.Play();
                        }
                        else if (left5.x > left.x)
                        {
                            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), rf);
                            rf.Play();
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), lf);
                            lf.Play();
                        }
                    }
                    //goal
                    if (random == 1)
                    {
                        if ((Math.Abs(left5.x) - Math.Abs(left.x)) < threshold)
                        {
                            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), cg);
                            cg.Play();
                        }
                        else if (left5.x > left.x)
                        {
                            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), rg);
                            rg.Play();
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), lg);
                            lg.Play();
                        }
                        score++;
                    }
                    counter = 0;
                    kicksLeft--;
                }
            }
        }

        if (counter > 0 && counter < time && kicksLeft > 0 && approach == false && animation > animationTime && !play)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), loop);
            loop.Play();
            loop.loop = true;
            //GUI.Box (new Rect (50, Screen.height-100,460,90), (kicks + kicksLeft));
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
            GUI.skin = menuSkin2;
            GUI.Box(new Rect(Screen.width - 500, Screen.height - 170, 360, 90), name);
        }

        if (play == false && approach == false && animation > animationTime)
        {
            guiColor.a = 0.28f;
            GUI.color = guiColor; //sets all next gui color to transparent 0,5
            //guiTexture.color = colorT;
            GUI.DrawTexture(new Rect(Screen.width * 5 / 40, Screen.height, Screen.width * 15 / 20, -Screen.height * 8 / 10), km.usersLblTex);
            GUI.color = Color.white; //sets it back
        }
        if (kicksLeft == 0 && counter2 < time2 && counter2 > 0 && !play)
        {
          
            renderer.material.mainTexture = result;
            result.Play();

            GUI.skin = menuSkin4;
            GUI.Box(new Rect(Screen.width / 4, Screen.height * 6 / 20, 560, 90), name);
            //GUI.Box(new Rect(Screen.width / 4, Screen.height * 8 / 20, 360, 90), (score + "/5"));
            //GUI.DrawTexture(new Rect(Screen.width * 3 / 40, Screen.height * 4 / 20, 324, 576), picture);
            //GUI.Box (new Rect (600, 470,360,90), "picture");
            if (counter2 > 10)
            {
                GUI.skin = menuSkin3;
                GUI.Box(new Rect(Screen.width / 4, Screen.height * 12 / 20, 650, 90), "LIKE YOUR result on FB/adress!");
            }
             //*screenshot comes and made here
            if (counter2 == 10 && score > 2)
            {
                Application.CaptureScreenshot(no + ". " + name + " " + score + " goal.png", 4);
                no++;
            }
            //
            guiColor.a = 0.3f;
            GUI.color = guiColor; //sets all next gui color to transparent 0,5
            //guiTexture.color = colorT;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), shining);
            shining.Play();
            GUI.color = Color.white; //sets it back

            counter2++;
        }
        else plane.active = false;

        if (posRight.z == 0 | previous == Head.transform.localPosition.z)
        {
            kicksLeft = 5;
            approach = true;
            counter2 = 0;
        }
        if (kicksLeft == 0 && !play)
        {
            if (counter2 == 0) counter2++;
            if (counter2 >= time2)
            {
                kicksLeft = 5;
                approach = true;
                counter2 = 0;
            }
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
