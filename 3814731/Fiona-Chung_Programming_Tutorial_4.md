# Tutorial 4: Creating a Main Menu UI that Scales to Screen Size
This tutorial makes use of the Unity UI system and does not require a script to be written, but requires adjustments to be made within the hierarchy and inspector tab of Unity.

#### 1) Setting up the Canvas
Right click within the hierarchy, go to UI, and then select `Panel`. This will automatically create a canvas and event system that is required for the UI to work.
The color of the panel can be adjusted within the image component, found in the inspector tab. 
For elements (e.g. images, buttons) to show up within the Unity UI they must be within the canvas in the heirarchy.

For the canvas to scale correctly, make sure the canvas has a `canvas scaler` component.
Set the UI scaler mode to `scale with screen size`.

A reference resolution can now be entered for the canvas. For a high quality image I would recommend to go with X = 3840 and Y = 2160. This resolution will allow your main menu to look good on many different screen sizes.

#### 2) Setting up the menu buttons
Within the canvas create an empty gameobject and call it `MainMenu`. This game object will hold all the buttons for the main menu and should be sized appropriately. In my case I have four buttons and have set it's size to 1718x2160.

Now right click on the MainMenu gameobject and go to UI, `Button` (or Button - TextMeshPro). Create as many buttons as needed and size them to your liking. 
Each of the buttons contains a `text` object. The text of the button can be changed within the inspector (e.g. Start, Credits, Quit, etc.).

For the purposes of this tutorial the buttons do not have a game function other than to show the scaling of the screen.
In order for the buttons to work, a script `using UnityEngine.SceneManagement` would have to be written and attached to the `MainMenu` gameobject. The `MainMenu` gameobject would then have to be dragged into the onclick components of each buttons, werein each button calls on a specific function within the script.

Now just by dragging the width of the game view window, you should see the menu scaling to the screen size.
