# Year-2-Learning-Journal.md

## Tuesday 29th September 2020

Today, I have learned a bit on how to GitHub and that the site is highly used by developers. Including that it is also used as a cloud storage like Google Drive, but it stores code in it. Another thing is that computers can't think things like people do, which reminded me what I was told at college is that computers are only as smart as peolpe make them.

## Tuesday 6th October 2020

I have learned what should and should not be included in the documents we submit for the course, such as the programming journal is not a diary as it should not include how our day was and the tutorials should be written in an understandable way that is not copying anyone. All while using Github in markdown (.md) format, save for the task log which will be made using spreadsheet software.

Another thing is that the libeary folder and the .vdCode is not needed for the submission of our work, as the library folder is large and deleting it will save a lot of memory. An additional thing is that there is a Unity function called .MoveTowards which can be used to make one object home in on a targeted object like a missle and the speed can be determined to your preferences.

## Tuesday 13th October 2020

I have relearned how to create the editor script to make all 2D sprites that get put into a specific folder turn into sprites automatically so they do not need to be changed manually without it. While doing this, I also learned how to write a tutorial using Github using the same markdown (.md) format as last time. Another thing I figured out is that the curly brackets ({}) are used as high lights as it makes a box containing what wal written in it.

## Tuesday 20th October 2020

I have learned how to write code in Unity to make an AI character move wherever the mouse is clicked when the game is playing. While doing this, I asked the teacher whether or not they should always involve code and Paul said that all the tutorials I make must involve code in them, or at least have something that refers to a currently existing component.

## Sunday 1st November 2020

Today, I have learned how to make an animation play through the press of a key and through a trigger. I watched a video to learn how to do this and I did struggle to understand how to write it as I thought I could do it similarly for the Audio Source code, but I realised that I forgot that the name of the Audio Source is crucial for playing it.

## Tuesday 10th November 2020

I have learned how to write code that makes a circle as well as a cone inside it that I can use to make a Field of Vision for the NPCs without using any external components. I
have also learned thay by typing "Range (0, 360)" in square brackets, it will make the public number variable underneath it turn into a slider that can be used for circular objects. I watched a video called "Field of view visualisation (E01)" and this is where I did struggle to understand how to do some of the things that were mentioned in it, but I got through it.

## Monday 16th November 2020

I have learned how to write code that creates an object mask that makes a game object block the view of the Field of Vision and a Target mask that draws a line to the game object. All with the corresponding layers. I continued watching the video from last week to finish off the creation of the Field of Vision and I learned how to draw a line to the target object.

## Tuesday 17th November 2020

Today, I have learned how to create a visible view cone that shows where the enemy is looking and what they can and cannot see. I watched the follow up video from last week's video on how to create the Field of Vision and I also learned how to change the color of the Field of Vision through a View Mesh Filter. While watching the video, I found out about structs and what they can be used for. The video showed that they can use public variables for the struct itself, but for the parentheses using the same public name of the struct, they need to be written differently.



### Example of Struct Usage

bool edgeDistThresholdExeeded = Mathf.Abs(minViewCast.**dist** - newViewCast.**dist**) > edgeDistThreshold;

public struct ViewCastInfo
{
        public bool hit;
        public Vector3 point;
        public float **dist**;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dist, float _angle)
        {
            hit = _hit;
            point = _point;
            **dist** = _dist;
            angle = _angle;
        }
    }

## Friday 20th November 2020

Today, I learned how to write a code for the Field of View that makes the objects that block it remain in a smooth angle while the character is moving. I used the same follow up video I wathed a few days ago that mentioned how to make the Field of Vision

## Saturday 21st November 2020

Today, I have learned how to write code to make the AI patrol the map using the transform data from empty game objects. I watched a different video that explained this and it also contained other code that can be used to make the AI chase the player after they get too close from any angle, but it did not explain how to make it only detect the player from a certain angle like the Field of Vision.

## Monday 23rd November 2020

I have watched a video called "Better AI in Unity" that explains how to write code that makes the AI follow the player when it get to a certain angle and only goes to the last known location of the player if something obstructs its view. It also shows the code that instantiates a ghost version (low alpha game object) on the player's last known location. I did watch another video called "AI that tracks the player's last know position | Unity Tutorial | AI Series", but it did not give a good explanation on how to write the code or look like it worked how I felt it should. So I discarded that video.

## Friday 27th November 2020

I have taken a look at Paul's Patrol script he made to make the AI move around the map and chase the player when the player enters its field of view and I have managed to learn some more effective ways on how to write the code and how to access other parts of the script in other scripts, but there are still some things I do not know about it.

## Sunday 29th November 2020



## Tuesday 1st December 2020

I have rewatched the video "Better AI in Unity" and I have learned how to write the code that makes an object block the AI's Field of View which will allow the player to hide behind low obstacles and walls. I have also learned about the functions OnEnable and OnDisable as they can make a difference between something being disabled with it's contents remaining on screen and being

I have also learned about making a ghost for the player's last known location and spawning it after the player leaves the enemies Field of Vision.
