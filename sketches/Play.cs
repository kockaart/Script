using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MovieTexture movTexture= this.renderer.material.mainTexture as MovieTexture;
		movTexture.Play();
		//movTexture.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		MovieTexture movTexture= this.renderer.material.mainTexture as MovieTexture;

	//	movTexture.loop = true;
	}
}
