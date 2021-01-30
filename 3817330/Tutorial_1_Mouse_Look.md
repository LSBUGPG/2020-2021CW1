# MouseLook

This tutorial will show how to create a first person controller and link it to a vision script centered around the `main.camera` object and where it is pointing.

## 1. The First Person Controller

- To begin with, head over to the hierarchy and create empty on the drop down, renaming it to `First Person Player`.

- While you have the `First Person Player` selected in th hierarchy, click on add component in the Inspector and add `Character Controller`. By hitting Gizmos in the scene tab will show the collider of the `Character Controller`.

- While in the Inspector, head over to the radius of the `Character Controller` to 0.6 and the height to 3.8, this will provide a collider that is more of ana average player character size (This is depening on the type of character you are making).

- In the hierarchy, right-click the `First Person Player` and hover over 3D object and click on capsule (or any other prefered object). Set the scale of this capsule to `x = 1.2`, `y = 1.8`, `z = 1.2`. This makes the object around the same size as the `Character Controller`. You can remove the capsule collider in the Inspector since the `Character Controller` acts as a collider by itself.

## 2. Assigning the Camera

- In the hierarchy, click and drag the `Main Camera` object under the `First Person Player` to make it a child of the `Character Controller`. In the Inspector, right-click transform and clcik reset. This will reset the camera position to the `First Person Player` automatically.

- On the y axis, drag the `Main Camera` almost to the top of the character in the scene. Make sure that the camera has some room from the top to prevent the camera from clipping into cielings as well as keeping it within the graphic so it doesn't see the graphic.

- While clicked on `Main Camera` in the hierarchy, add a component in the Inspector called `MouseLook`, and create a script of it. Double click the script in the Inspector to open it in visual studios.

## 3. The MouseLook Script

- To begin with we need to write some code that allows the mouse to control the vision direction. First of all we need to determine the speed of the cursor in the game so under `public class` we nee to create a reference to the `mouseSensitivity` and assign a value to it:
```
public float mousSensitivity = 100f;
```

- Next we need to create the code that will look for the input on both the `Mouse X` and `Mouse Y` axis and connect it with the `mouseSensitivity` variable we just made to allow the cursor to move the vision of the character. Under `public void Update` type:
```
float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
```

- Now that we have the mouse controlling the player vision, we will want to reference the actual playerbody to the movement of the camera along the y axis. To do this we will need to make another variable under `public class`:
```
public Transform playerBody;
```

- With the playerbody now referenced we can now link it to the `mouseX` float we made to make the actual player rotate along the y axis in the game to face the direction we want to face. Under `public void Update` type:
```
playerBody.Roate(Vector3.up * mouseX);
```

- From here we can save the code and switch back to unity to assign some variables in the Inspector. Select the `Main Camera` in the hierarchy and drag the `First Person Player` into the playerBody section to assign the playerBody as the object that is going to be rotating along with player vision.

- Now we need to tackle the vision looking up and down along the x axis in the game. First of all we need to make a variable to keep track of the rotation along the x axis. Under `public class` type:
```
float xRotation = 0f;
```

- Now we need to link this rotation with the `mouseY` float we made earlier. So under `public void Update` type:
```
xRotation -= mouseY;
```
We use `-=` instead of `+=` because otherwise the rotation would be flipped.

- With this link now established we can apply the rotation, so under the code we just wrote, type:
```
transform.loacalRotation = Quaternion.Euler(xRotation, 0f, 0f);
```

- With the code how it is, we can continue to rotate along the x axis and look all the way behind us. We don't want to be able to do that so we are going to need to `Clamp` the rotation by claculating the maximum angle the vision can move along the x axis using `Mathf`. On the next line down type:
```
xRotation = Mathf.Clamp(xRotation, -90f, 90f);
```
This locks the angle to 180 degrees.

- Finally, we need to lock and hide the cursor during the game so that the cursor doesn't move off the application during play and isn't visible to produce an eyesoar and a distraction. Under `public void Start` type:
```
Cursor.lockState = CursorLockMode.Locked;
Cursor.visible = false;
```

- Save the code and switch back to unity. Play the scene and you should now be able to move the camera up, down, left and right, with a clamp on the up and down when trying to look to far.
