# Tutorial I


### Introduction
This is part one of the tutorial series, dedicated to creating a dice-throwing mechaninc in Unity3D. In this part we are going to start with camera controls and set up board for future use. 


### Blocking out the board

*You may skip this, if you are here for camera controls.*

To do this, go to GameObject -> 3D Object -> Cube/Plane. Build of this blocks box-shaped board, so that our dice dont fall out. After all of them are set up, click on each one and click **Add Component** button, then serach for Box Collider and add it. Make sure, that **Is Trigger** is turned off. 

Or you may just create big enough plain. 

![Collider](/Tutorial%20I/Assets/Images/Image2.png)


### Setting up camera
Lets now start work on the actual camera. First of all, we need to position it properly, facing downwards. You may use **Rotate** tool directly on camera or enter values on righthandside manualy. Tilt camera to 60-80 degrees to your liking. You can check the result in camera window or by pressing Play button. 

![Angle](/Tutorial%20I/Assets/Images/1.png)


### Code

Create new script. We are not going to need Start() method, so you may delete it. Now lets declare few variables: 

    public float speed = 20f;
    public float scrollSpeed = 20f
    public float edge = 10f

First one is going to be used for our camera movement speed and second for zoom speed. Edge is used to check if cursore is close to the edge of the screen.
Now we can move to **Update()** method. We are going to use WASD keys and our cursor to move camera around. Movement using keyboard is not complicated and we can call for **Input.GetKey("keycode")** in the **if** statement to check if the corresponding button is pressed and add speed into that direction. For cursor we are going to check if it is located near the edge of the screen to move a camera. To save some time and space, we may create Vector 3 variable, making shortcut for our game object position. Your method should look something like this now: 

    void Update()
    {
        Vector 3 pos = transform.position;
        
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - edge)
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= edge)
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - edge)
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= edge)
        {
            pos.x -= speed * Time.deltaTime;
        }
        
    }
    
**Time.deltaTime** is being used so that distance that game object travels is the same on every computer and not impacted by FPS. Adding scroll controls is a bit different, but also very easy. We capture our mouse wheel imput and then apply speed to the camera. 

    float scroll = Input.GetAxis("Mouse ScrollWheel");

        pos.y -= scroll * scrollSpeed * 100f *  Time.deltaTime; 
 
Alright, now we can save the file, return to the main scene and attach script to the camera. Press play and enjoy moving camera and try to zoom. However, there is still one thing, that demands our attention. Right now camera can be moved as far as we want into any direction. Generally, you want some limitations on movement and zoom, but it is not always the case. Lets add some limitations to our example. We should start by adding few more variables:

    public Vector2 limit;
    public float miny = 20f;
    public float maxy = 100f;
    
Our Vector 2 variable is going to be limit for horizontal movement, like edges of the map. Other two variables are going to controll maximum and minimum height that you can reach with mouse wheel. To limit movement, we can use awesome Mathf.Clamp() method. Now, your complete script should look something like this: 


    public class RTSCamera : MonoBehaviour
    {
    public float speed = 20f;
    public float edge = 10f;
    public Vector2 limit;
    public float scrollSpeed = 20f;
    public float miny = 20f;
    public float maxy = 100f;

    
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - edge)
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= edge)
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - edge)
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= edge)
        {
            pos.x -= speed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        pos.y -= scroll * scrollSpeed * 100f *  Time.deltaTime; 

        pos.x = Mathf.Clamp(pos.x, -limit.x, limit.x);
        pos.z = Mathf.Clamp(pos.z, -limit.y, limit.y);
        pos.y = Mathf.Clamp(pos.y, miny, maxy);

        transform.position = pos;
        }
    }
