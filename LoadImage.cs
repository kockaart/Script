using UnityEngine;
using System.Collections;

public class LoadImage : MonoBehaviour {

	// and DXT compress them at runtime
	public string  url = "file://localhost/"+Application.dataPath+"/../Photo.jpg";
	public Texture2D photo;

	// Update is called once per frame
	public IEnumerator Load () {
		// Create a texture in DXT1 format
		photo = new Texture2D(4, 4, TextureFormat.DXT1, false);
		renderer.material.mainTexture = photo;
		while(true) {
			// Start a download of the given URL
			var www = new WWW(url);
			// wait until the download is done
			yield return www;
			// assign the downloaded image to the main texture of the object
			www.LoadImageIntoTexture(photo);
		}
	}
	
}
