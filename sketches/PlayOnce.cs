using UnityEngine;
using System.Collections;

public class PlayOnce : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MovieTexture movTexture= this.renderer.material.mainTexture as MovieTexture;
		movTexture.Play();
		movTexture.loop = false;
	}
	
	// Update is called once per frame
	void Update () {
		MovieTexture movTexture= this.renderer.material.mainTexture as MovieTexture;
		if (!movTexture.isPlaying) {
			PlayerPrefs.SetInt("On", 0);
			this.active = false;
		}
	
	}
}