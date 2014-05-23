using UnityEngine;
using System.Collections;

public class LoadImage : MonoBehaviour {

	// and DXT compress them at runtime
	public string  url = "file://localhost/"+Application.dataPath+"/../player_photo.png";
	public Texture2D photo;
	
	//public TextAsset txt;
	public string name= "Please set name";

	// Update is called once per frame
	void Start() {
		// Create a texture in DXT1 format
		//Texture texture_title=Resources.Load("title5") as Texture;
		//GameObject.Find("title").renderer.material.mainTexture=texture_title;

		Texture2D tex=Resources.Load("player_photo") as Texture2D;
		photo = tex;
		this.renderer.material.mainTexture=photo;
		Resources.UnloadAsset(tex);


		TextAsset txt = (TextAsset)Resources.Load("player_name", typeof(TextAsset));
		//txt.Load();
		name = txt.text;
		Resources.UnloadAsset(txt);

		print(name);
		
		
	}
	void Update(){
		Destroy(txt);
		Destroy(tex);
		Resources.UnloadAsset(txt);
		Resources.UnloadAsset(tex);
		GC.Collect()
		Resources.UnloadUnusedAssets();
		GC.Collect()
		
	}
}
