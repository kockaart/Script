using UnityEngine;
using System.Collections;

public class GoalFail : MonoBehaviour {

	public GameObject next;
	// Use this for initialization
	void Start () {
		MovieTexture movTexture= this.renderer.material.mainTexture as MovieTexture;
		movTexture.Play();
		PlayerPrefs.SetInt("On", 1);
	//	movTexture.loop = false;
	}
	
	// Update is called once per frame
	void Update () {
		MovieTexture movTexture= this.renderer.material.mainTexture as MovieTexture;
		movTexture.Play();
		if (!movTexture.isPlaying) {
			next.active = true;
			this.active = false;
		}
	}
}
