# PlayerMove

This tutorial will show how to create a script to make the `First Person Player` object move when certain key inputs are detected on the keyboard. To learn how to create a `First Person Player` object, check tutorial 1.

## 1. The PlayerMove Script

- To begin, click on the `First Person Player` in the hierarchy and add a component in the Inspector called `PlayerMove` and create the script. Open it up in visual studios.

- We won't need the `public void Start` function for this code so we can delete it. The next thing is to create the input we will be looking for to move the `First Person Player` object when pressed. We will do this by utilising unity's keybinding of the A and D keys with the `Horizontal` axis and the W and S keys with the `Vertical` axis. This also connects to the arrow keys as well. In `public void Update` type:
```
float x = Input.GetAxis("Horizontal");
float z = Input.GetAxis("Vertical");
```

- Now we want to create a direction for the player to move in with relation to the way we are looking in the world rather than the actual world coordinates. To do this, under the code we just wrote, type:
```
Vector3 move = transform.right * x + transform.forward * z;
```

- In order for the player to actually move howerver, we need to create a reference to the `Character Controller`, as well as a speed that the player moves at. So under `public class` type:
```
public CharacterController controller;
public float speed = 3f;
```

- With both of these variables referenced, we can use them together to make the player move at the set speed simply in the `public void Update`:
```
controller.Move(move * speed *Time.deltaTime);
```

- Save the code and head back to unity. Click on the `First Person Player` oject in the hierarchy and drag the object into the `controller` section in the Inspector.
