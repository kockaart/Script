using UnityEngine;
using System.Collections;

public class MenuBase : MonoBehaviour {
	
	//Use the skin defined in the inspector
	public GUISkin menuSkin;
	protected GUIText debug;

	protected float screenWidth, screenHeight;
	
	protected bool clickEnabled;

	// Use this for initialization
	public void Start () {
		this.clickEnabled = false;
		StartCoroutine("enableClick", 1f);
		this.screenWidth = Screen.width;
		this.screenHeight = Screen.height;
	}
	
	protected IEnumerator enableClick(float wait)
	{
		yield return new WaitForSeconds(wait);
		this.clickEnabled = true;
	}
}
