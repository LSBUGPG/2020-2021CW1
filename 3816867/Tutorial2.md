Camera follow player 

To Start create a new scene 
Create game object cube and call it player 
Create a plane and call this ground. Place the player above it. 
Add a rigidbody to the player 
Create a c sharp script and call it player movement. I am using the same movement script as last tutorial. 
Add this script to the player and adjust movement speed to 2 

Add another script and call it 'CameraFollow' 
In this script the first thing to write is "public GameObject face;
    private Vector3 offset; "  Put this above void start. By writing this it makes unity recognise the game object that it will follow. In this case it is the player
    
    Under Void Start write "offset = transform.position - face.transform.position;" this tells the postion of the camera from the start and tells the camera to follow the player at that angle we set the camera at. If we take this code out the player will move but the view would be first person.
    Under Void Update write "transform.position = face.transform.position + offset;" This tells the camera to follow the player moving. If you don't have it the camera will not follow the player.
    
    Now add the code to the camera by going to Add component, scritps and then selecting the CameraFollow script. 
