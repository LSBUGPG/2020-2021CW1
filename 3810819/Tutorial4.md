# FPS Counter
This will teach you how to create a script that tells you how your game is performing so you can tell when and where it starts performing well and badly.

## Writing the Script
When you open up Unity, create a C# script and name it appropriately, such as **FrameCounter** or **FPS**. Then open the script and inside the top of public class, write in **Rect** and **GUIStyle** and name them appropriately such as **fpsRect** and **style**. Rect in Unity stands for **rectangle** and the GUIStyle is going to be used to change the size of the text's font.

Underneath them, write a **float** variable and name it **fps** with all letters in lowercase as the letters will be spaced out in the editor screen if camel cased. The Update void can be deleted as that is not needed, but keep the Start void and create a private void function called **IEnumerator RecalculateFPS**. If you want to change the amount of numbers visible on the FPS counter, then create a new private void function called **OnGUI** as this allows you control the numbers that can be visible on screen.

In the start method, write the following (or relevent if different):

fspRect = new Rect(100, 100, 400, 100); // Used to calculate the size of the rectangle

style = new GUIStyle();

style.fontSize = 30;

StartCoroutine(RecalculateFPS());

In the IEnumerator method write the following (or relevent if different):

while (true)

{
   
   fps = 1 / Time.deltaTime;
   
   yield return new WaitForSeconds(1);
   
}

In the OnGUI method, write the following (or relevent if different):

GUI.Label(fpsRect, "FPS: " + string.Format("{0:0.0}", fps), style); // The numbers in curly brackets control the amount of visible numbers ({0:0.0} = 0.0)

When you finish writing the script, just make an empty game object and implement the script component into it.

## How to Test the Script
If you want to see if it works properly when the game loses performance as it plays, you can add a high polly mesh into your project (downloaded or made by yourself) and duplicate it repeatedly so it takes up more performance. Afterwards you can create another script called CameraMovement that makes the camera rotate automatically so you can see when the performance is good and when it is bad.

When you feel like you have made enough duplicates to make a visible difference in the performance, just open the CameraMovement script and create a float for the rotation speed, name it appropriately and give it a speed of **30**. You can delete the start method, but in the Update method write the following (or applicable if different):

transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);

Afterwards, just apply the script component to the main camera where it can see the areas that you think require more processing power and then turns to an area where it plays smoothly.
