Step 1:

Create an object ion the hierachy and add a script component to it and name it MouseFollow

Step 2:

In void Start wrtie the following:

      Cursor.visible = false;
        //This will delete the cursor by setting its visibilty to false
    
Step 3:

Go to the void Update and make it public void Update().

Add the following below:

    Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.position = new Vector2(cursorPos.x, cursorPos.y);
      //Finding the current position of the mouse
      //Updating the objects position using the first line of code in the public void Update()
    
Go back to unity and check for errors
