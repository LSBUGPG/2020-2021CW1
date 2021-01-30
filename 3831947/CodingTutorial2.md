# Countdown

-This tutorial will tell you how to make a countdown timer, to do this you will need to insert a text field. **Right click** under the Hierarchy you will see **UI** from there you will  need to **select Text**. 

-This will automatically create a canvas in Unity for the text field. To edit the text you will need to make sure you have selected Text, under the **Inspector** you can edit the **text colour**. 

-Make sure to centre the text by editing the alignment to centre and increase the font size. 

![Screenshot (6)](https://user-images.githubusercontent.com/72073841/98047723-534ad080-1e24-11eb-9f4c-f154aeb02afb.png)

-Create a script on the camera’s game object and name it countdown,  at the top of the script insert Unity Engine UI, this line is important because you will get an error when you try to change the text in the text box. 

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;


-Create a **public float called timeStart**, we use this to tell our timer how many seconds we like to count down, which is **currently 60**. 
Then we will create a new public text, labelling it  textbox which will hold our textbox object.


    public class Countdown : MonoBehaviour
    {
   	public float timeStart = 60;
    public Text textBox;
    

-In the start function we should set the text boxes equal to our **time value**. Since the time start value is a float, we need to convert it into **.ToString**

    / Use this for initialization
	  void Start()
	  {
		textBox.text = timeStart.ToString();
	  }

-In the **update function** we should edit the time start to subtract its current value by **time.deltatime**. We subtract this to keep the countdown consistent with the time itself instead of the **frame rate**
 
     // Update is called once per frame
   	void Update()
   	{
		timeStart -= Time.deltaTime;
		textBox.text = Mathf.Round(timeStart).ToString();
   	}

 
-In the **Inspector** we can see that the camera’s game object, make sure to **drag the textbox into the textbox field in the inspector**. This means the script can identify which text box to edit in the game scene. 

![Screenshot (13)](https://user-images.githubusercontent.com/72073841/98047996-d53af980-1e24-11eb-856d-9ed114ae4a2e.png)


-Press play and the textbox should change and the number decreases every second. 
