using UnityEngine;
using System.Collections;

public class LoadImage : MonoBehaviour {

	// and DXT compress them at runtime
	public string  url = "file://localhost/"+Application.dataPath+"/../photo.png";
	public Texture2D photo;
	
	//public TextAsset txt;
	public string name= "Please set name";

	// Update is called once per frame
	public IEnumerator Start () {
		// Create a texture in DXT1 format
		//Texture texture_title=Resources.Load("title5") as Texture;
		//GameObject.Find("title").renderer.material.mainTexture=texture_title;
		//kell a Resources konyvtar az assetben

		//1* txt = (TextAsset)Resources.Load("name", typeof(TextAsset));
		//2* txt.Load();
		//name = txt.text;
		
		sr = new StreamReader(Application.dataPath + "/../name.txt"); 
		name = sr.ReadLine();
		
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
		//print(Application.persistentDataPath);
		//string fileLocation = Application.persistentDataPath + "file.txt";
	}
	
}
