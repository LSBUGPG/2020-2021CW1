# How to make a camera follow script

## Setup

you just need to open unity and then click on the main camera that is located on the left side of 
unity. Go to inspector in the top right then go to add component on the bottom of the inspector and 
click it, then in the search bar write ```follow``` and click on new script. 
Then open the script my click on it.

## Coding

Select the green text above '''void start''' and delete it than write this in it places.
```
    public Transform PlayerTransfrom;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
```
This is the references you need for code to know.

Then inside of the ```void start``` write this.
```
_cameraOffset = transform.position - PlayerTransfrom.position;
```
This is just taking the starting values fo the camera and the player.

then inside of the ```void update``` write this.
```
    Vector3 newPos = PlayerTransfrom.position + _cameraOffset;

    transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
```
This is telling the camera to change it's position the same way the player changes 
his position which will make the camera to follow.

The go back to unity go the main camera click on it go to inspector then you will see your
script has an empty space called player transform drag and drop the player there and the camera will
follow him around the environment.
