using UnityEngine;
using System.Collections;

public class LoadImage : MonoBehaviour {
	
	public string  urlP = "file://localhost/"+Application.dataPath+"/../player_photo.png";
	public string  urlN = "file://localhost/"+Application.dataPath+"/../player_name.txt";
	public Texture2D photo;
	public string name= "Please set name";

	IEnumerator Start () {
		// Create a texture in DXT1 format
		// and DXT compress them at runtime
		//Texture texture_title=Resources.Load("title5") as Texture;
		//GameObject.Find("title").renderer.material.mainTexture=texture_title;

		photo = new Texture2D(4, 4, TextureFormat.DXT1, false);
		renderer.material.mainTexture = photo;
		while(true) {
			// Start a download of the given URL
			WWW wwwP = new WWW(urlP);
			WWW wwwN = new WWW(urlN);
			// wait until the download is done
			yield return wwwP;
			// assign the downloaded image to the main texture of the object
			wwwP.LoadImageIntoTexture(photo);
			yield return wwwN;
			name=wwwN.text;
		}
	}
	
}
