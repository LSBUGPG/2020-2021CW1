# How to make a shadow detector

## Setup 

First, start unity then you need a player to get a player right click on the `sample scene` 
then click on 3d object and select cube this is your player. To `tag` him as the player you 
need to click on the cube then go to inspector, it should be on the left of unity near the top 
you should is a rectangle that says untagged click on it and select the tag `player` after 
that you can cheng the name of the cube to player. Then you right-click the sample scene again 
and this time go to light then select `spotlight`. After that click on the spotlight go to 
inspector again and select tag then go and click on add tag on the bottom then click on the 
`+ sign` and wright sun on it then enter. Click on the spotlight again go to tag and you 
should see the tag you made that's called sun select it. After you have tagged the spotlight 
you need to click on it for that last time then go in the inspector, there should be an 
opened box with text that says light in the middle of the text there should be something 
called shadow type make sure is set up on `Soft Shadow` if there is no shadow on the player
increase the range of the light. Then go to the bottom of inspector and click on add component
in the search bar wright box collider. The last thing to do before starting the code is 
right-click sample scene and select 3d object the click on cube, that will be the wall make it 
big enough to hide the player in the shadow of the wall. 

## Coding 

Click on the player and go to inspector after going to the bottom, of inspector and select add 
component in the search bar wright sun the click new script and press enter. Select the green
text above `void start` and delete it than write in it's place this.

```
   publice GameObject NewSun;

   privete MeshRenderer mesh;
   privete RaycastHit hit;
   privete bool underSun = false;
   privete Vector3 sunPos;
```

This is values that you need a reference to so your code knows what it's meant to do.

Then `inside of void Start` wright this.

``` 
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        underSun = false;
    }
```
This code is used to reference the player's mesh and cheng it's colour and the underSun is used to
tell the code that if it's not detecting the sun it's set to false.

After that, you need to write this inside of your `void Update`.

```      
    void Update()
    {
        sunPos = NewSun.transform.position;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, (sunPos - transform.position), out hit, 200))
        {
            Debug.DrawLine(transform.position, (sunPos - transform.position), Color.red);
            if (hit.collider.tag == "sun")
            {
                print("hit sun");
                underSun = true;
            }
            
            else
            {
                print("not hit sun");
                underSun = false;
            }
            
        }


        if (underSun)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }

        else if(underSun == false)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
```
So first let's start with the `sunPos` this is just a reference of the position of the object.
Then the `RaycastHit` this is just referencing the hit of the Raycast.
The purpose of the `if statement` is that if the player casts a Raycastto at the sun it will 
detect it and it will change the bool to true and the `else statement` is if the Raycast doesn't 
hit the sun then the player will stay false.
The last part of the code is if the bool is false the player is green and if it's true it
the player will become red.
