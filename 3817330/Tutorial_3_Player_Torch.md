# PlayerTorch

This tutorial will show you how to craete a toggable torch attached to the player object. To learn how to create a `First Person Player` object, check tutorial 1.

## 1. Creating the Torch

- First we need to make the torch. Make sure you are clicked on the `First Person Player` object in the hierarchy, right click and head to the Light tab and add a `spotlight`. This will now be attached to the player controller. You can adjust it to whereever you would prefer on the player object.

- While clicked on the `spotlight` in the hierarchy, add a component in the Inspector called `PlayerTorch`, and open it in visual studio.

## 2. The PlayerTorch Script

- First of all we will need to reference the actual `spotlight` as the torch and whether the torch is on or off. We can do this by making two variables under `public class` and setting the state of the torch to off on start using a `bool`:
```
public Light torch;
public bool on = false;

public void Start
{
    on = false;
}
```

- Now we need to look for the input of the correct key to turn the torch on. We are going to use the F key as the input to toggle the torch on and off. To do this we will need to make an `if` statement that looks for that input. In `public void Update` type:
```
if (Input.GetKeyDown(KeyCode.F))
{

}
```

- Now we will want to determine what happens when the F key is pressed based on the current state of the torch. We can do this by using an `if` and and `else` statement inside the previous `if` statement we just made:
```
if (on == true)
{
    Torch.enabled = false;
    on = false;
}
else
{
    Torch.enabled = true;
    on = true;
}
```
This will turn the torch off if it is already on and set the bool to check its state to off. This is opposite if the torch is off when the F key is pressed.

- Save the code and swich back to unity. Click on the `spotlight` in the hierarchy and drag the `spotlight` into the torch section. Next untick the `Light` tab to turn the torch light off but not the actual object.
