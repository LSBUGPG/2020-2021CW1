## Learning Journal - Matthew Wilson

#### Note on Formating

While this journal should have been written as the year progressed, and I had intended to do so, that did not end up happening. As will be explained in more detail below, the work on this module ended being delayed greatly and so I had nothing to write in this journal. As a result everything up until Janurary is written retroactively. I appologise for this, and would have prefered not to have left so much of the writting so late.

#### Start of Term to Winter Holiday

Throughout the whole of this period little to no progress was made one this module. This was not due to a lack of effort, but rather due to large amounts of my time being taken up elsewhere. Various health issues have plagued me, which slowed progress and took up time. And in particular the 3D game design project was a constant source of difficulties and delays. I spent much of the time that should have been for this module working on the 3D game project instead. Doing this meant that I had to rush a lot of the work for this module later on. In hindsight it would have likely been a better idea to have stuck to working on this module earlier and to have not left it so late. However it was hard to judge that at the time.

#### Winter Holiday

During the winter holiday I finally made the first tutorial. I decided it would be best to make it on code that would also be used within the game, and that could be combined for the second part of work. For this reason I decided to make the tutorials on the scripting required for a basic main menu system.

#### Tutorial 1

The tutorial was relatively easy to make. Most of the time making it was spent watching tutorials. The process I used was more or less to learn how to create the script through tutorials, then to create it, referencing the tutorials whenever I was uncertain about something. And finally to write it down as a tutorial, referencing back to both the work I had done and the tutorials to ensure everthing was correct. In retrospect this was slower than just making the tutorial at the same time as learning to make the script. However, I feel this slow process did at least have the benifit of helping to refinforcing what had been learned.

#### Janurary

Although I did all the scripting covered in the remaining tutorials over december, I was so focused on the 3D game project that I didn't get around to writing the tutorials. It was only during Janurary that the writing was done. Although I had to rush through it which likely harmed its quality, I was still able to get it all done in time. As mentioned before, it would in retrospect have been a better idea to get the work done earlier. However I still feel it turned out okay.

#### Tutorial 2

This tutorial was relatively simple to make. I used the same procress as described earlier for tutorial one. The only difficulty I encountered was when I accidentally missed the step of adding the line ```using unityEngine.Audio;``` and proceeded to spend several minutes getting frustrated trying to figure out why it was not working. Once I rewatched the tutorial I realised my mistake. It wasn't a big deal, but did serve as a reminder of why it's important to pay close attention and double check all the required steps.

#### Tutorial 3

I encountered a strange problem while creating this script. This problem isn't in the script itself or in the unity project I created for this module, but rather a conflict with another script in the 3D game design project. The camera control script I was using, which I had gotten from standard assets, also contained a function for relocking and hiding the cursor. This would make clicking anywhere while paused disable the cursor and break things. I tried to edit the camera control script so that it would check if the game is paused and not interfer if it is. However this did not work for no apparent reason. After hours of searching online and experimenting trying to find a solution, I tried something desperate that I didn't think would do anything. I created a new script, and copied everything from the camera control script into it. This script worked fine. I do not know why or how. It was identical to the original in every way. I'd just about had it at that point, so I decided to just leave it and not risk breaking it.

#### Tutorial 4

In this script I encountered a problem which although I resolved, I'm not sure that my method was the best one available. However it was the only thing I could think of. The problem in question was with the count down. In order to make it consistant I needed to use ```Time.deltaTime```. This doesn't work with intergers though, so the value of the would have to be a float. I thought this would be fine, until I attached it to the UI. The UI would then desplay the time to several decimal places. This looked ugly and was not what I wanted. Maybe there's a way to stop this, but I'm not currently aware of it. I figured I'd have to find a way of counting down the time with a float variable, but then have a seperate interger variable to actually display. The best thing I could think to do was have a float repeatedly count down one second then reset, and have an interger count down each time. This way the interger could be used for the UI to display a counting down number with no decimals. 

#### Tutorial 5

I had one problem during the creation of this script that was frustrating at the time but made me feel rather silly once I figured out what it was. Upon either pressing retry or returning to menu and then retying the timer would be frozen. My first thought was that I obviously needed to reset the amount of time remaining when restarting the level. However this didn't seem to do anything. Eventually I realised my mistake: I was reseting the interger that displays the time remaining, but not the float that actually counts down. If there is a better way of doing the count down then doing so probably would have avoided this problem all together, which is something I'll keep in mind as something to look into should I ever need to create any similar scripts in the future.
