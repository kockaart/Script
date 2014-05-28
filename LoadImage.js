var url ="" ;
var tex: Texture;

function Start () {

      a=0;
     var www = new WWW("file://localhost/"+Application.dataPath+"/../player_photo.png"); 
      tex = new Texture2D(1024, 512, TextureFormat.DXT1, false);
       renderer.material.mainTexture=tex;
       www.LoadImageIntoTexture(tex);	
       while(true) {
        yield www; 
      
    } 
   
}


