# How to make drag game object with mouse tutorial

## Setup

First, start unity then you need a cube to move around the scene go to the ``sample scene`` that is
located on the left of unity then right-click after that click on ``3D object`` and select cube. Then 
go to the ``inspector`` that is located on the right side of unity then go all the way to the bottom
and click on ``add component`` and in the search bar write ``rigidbody`` and click on it. After that 
go on the ``sample scene`` and right-click after that click on 3D object again but this time click 
on plane that will be your ground.

## Coding

Frist make a script by clicking on the ``project`` tab that is on the bottom of unity and then right
click inside of ``Assets`` then go to creat and C# scrips then open the scrip. Select everything inside 
of the public class and delete it then write in it places this.
```
 private Vector3 mOffset;

 private float mZCoord;
```
This is the refrenses you need for code to know.

Then you will need to make a new void like this.
```
void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }
```
This is a code that makes the camera act like an information gathering like coordinates of objects.

Then you will need to add this to your script.
```
 private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }
```
This is code tells the game that camera and the mouse together that you can click on an object and 
drag it around the scene. 
The only thing left for you to do is to add the script to the cube you made at the begging
