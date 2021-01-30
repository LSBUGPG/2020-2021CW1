# Learning Journal Part I: Programming module


* ##  Accessing other scripts
This always has been a problem for me, as often object interaction is the key for a working game. I've been using Transform.Find() for a long time, but what really makes code more readable and shorter is usage of public GameObject variables and dragging needed object in the editor. After that, you simply can use variable.GetComponent<script>() to access everything you need. 
  
* ## Camera clipping into objects
I've been doing RTS-like camera for my game and encountered a problem, when zoomed too much camera just goes throught object, which was not ideal. While this not exactly saves from every possible clipping, Mathf.Clamp() sets boundries on where your camera can go up/down and left/right, solving my issue. 

Overall for camera tutorial I found very usefull this Brackeys video: 
https://www.youtube.com/results?search_query=unity+how+to+make+rts+

* ## Weird results while using OnMouseDrag()
I got unexpected results when tried OnMouseDrag() to throw objects. Part of those were resolved by changing cursor coordinates to world coordinates with WorldToScreenPoint(). 
It was the only thing concerning this method, that got resolved, sadly. When dragged down, dice will clip through colliders and fall down. Trying to hardcode lowest coordinate just ended up with dice sometimes flying to the mars. Direction was unpredicted. 

Summary: don't touch OnMouseDrag() for physic-related things. 

Also, nice video on OnMouseDrag() for anything not physics-related:
https://www.youtube.com/watch?v=0yHBDZHLRbQ&ab_channel=Jayanam

* ## Don't overcomplicate 
This is follow up for the last one. Sometimes your overcomples method that is timesink in project can be replaced with really basic solution. If you start from such basic things, it will be easier to determine if they are going to be enough to make project work. However, if you start from complex ideas, there is a lot time to waste befor you can say 
that this idea is not going to work out. 
It happened way too many times, so its time to write it down. 

* ## Throws are not random enough 
Dice tends to land on few sides, as launching it up is not enough. AddTorque() solves this, with randomised values, so it spins while falling. Learned this (and proper way of adding colliders to sides instead of raycasting and overcomplicating again) here:

https://www.youtube.com/watch?v=i4-EAZpJwV4&ab_channel=xOctoManx

* ## GitHub Desktop

So, when you commit, you need to press "push" button as well or your stuff will not be visible online. Good thing I noticed before deadline, huh. 

# Learning Journal Part II: 3DGD module

* ## Text UI component 

So, unity does not recognise this one unless you impored UI things with `using UnityEngine.UI;` .

* ## Tooltips! 

A lot of tooltips. Learned how to create them, how to scale sprites and many more here:

https://www.youtube.com/watch?v=bglMAlyYCEU&list=PLX-uZVK_0K_6JEecbu3Y-nVnANJznCzix&index=67&ab_channel=inScopeStudios

* ## TextMeshPro

So, many tutorials are outdated and TextMeshPro is now part of Unity by default, you don't have too look for it in Asset Store. 


# Learning Journal Part III: Links

Not exactly mindblowing stuff, just links I used more than once or something I had to google. 

### Text, again
https://answers.unity.com/questions/864840/how-to-access-textscript-component-in-unity.html

### Markdown and images
https://stackoverflow.com/questions/14494747/how-to-add-images-to-readme-md-on-github

### Vector3.up 
https://docs.unity3d.com/ScriptReference/Vector3-up.html

### Rb velocity syntax 
https://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html

### Markdown guide
https://www.markdownguide.org/basic-syntax/

### Components in child
https://answers.unity.com/questions/1389872/getcomponentinchildren.html
https://answers.unity.com/questions/1357365/how-do-i-access-childs-with-name-and-getcomponent.html

### Coursor position
https://docs.unity3d.com/ScriptReference/Input-mousePosition.html

