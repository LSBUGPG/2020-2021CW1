# Learning Journal

## 13/10/2020
I was able to successfully rotate my block by 90 degrees, however if there are 2 blocks, they both rotate at the same time. This could be useful for some puzzles in my game (to make them harder), but I also need blocks that only rotate by themselves when they are clicked.
I had to change the `Physics Raycast` to a `Collider Raycast` and that solved the issue.
```
public class RotateBlock : MonoBehaviour
{

    Collider coll; 

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (coll.Raycast(ray, out hit, 100.0f))
            {
                if(hit.collider.tag == "MyBlock")
                {
                    transform.Rotate(Vector3.back, 90.0f);
                }
            }
        }
    }
}
```

## 20/10/2020
I first tried to figure out how to create a counter by myself. For this I created a separate if statement. This did not work and was more lines of code than needed.

First attempt:
```
RotationCounter();
   private void RotationCounter()
    {
        if (MyBlock.transform.eulerAngles.z == 90)
        {
            Counter = 1;
            Debug.Log("Counter = 1");
        }

    }
```
Solution:
Change in raycast if statement to
```
if (hit.collider.tag == "MyBlock")
                {
                    Counter = Counter + 1;
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f * Counter);
                }
                Debug.Log(Counter);
            }
            if (Counter > 3)
            {
                Counter = 0;
            }
```

## 30/10/2020
I tried to make a point and click character movement for my 3D game using the `NavMesh` function, but I don't know why I can't bake the areas of the ground. I need to bake the areas of the ground that the can be clicked and walked on, but this is not working. I think everything should work once the areas of the ground are baked. 
#### Fixed 3/11/2020:
I just had to lower the radius of the navmesh area before baking. The previous surface area was too small for the radius, so I scaled up the ground and reduced the radius.

## 3/11/2020
I am trying to randomize the rotation at the start of whent he blocks are set up. I had to change my script around and I thought that was the issue, but it still doesn't work. The randomization of the counter works, but changing the counter does not change the rotation at the start. 
Solution: I realized I made a small mistake of not putting the `transform.rotation` line fully outside of the if statements. After changing this, the rotation works. 

Inside of update:
```
if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (coll.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "MyBlock")
                {
                    Counter = Counter + 1;
                    if (Counter > 3)
                    {
                        Counter = 0;
                    }
                }
                 Debug.Log(Counter);
            }
        }
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f * Counter);
```

## 7/11/2020
I am trying to set up two lists, one that records the vertical blocks and the other records the horizontal blocks. With these lists I can set up a count for the lists, and once the counts are the correct number of blocks, the puzzle will be solved. For some reason the list is not accessible in the other script.
### Solved 9/11/2020: 
After setting up the lists as static I can directly call upon the lists by writing `BlockCounter.verticalList`. There is no need to set up a variable for the script to reference it.

## 15/11/2020
I am trying to move an object to the position of an empty game object by using the mousebuttondown input. There is nothing wrong with the code in the sense that there are no errors, but it does not do anything. Using raycast I want to check for collision by using tags, so that when a certain area is clicked on, the player will me moved to the empty game objects position. I set the game object positions in the inspector by dragging and dropping the game objects into the slots, and then I set the vector3s equal to the corresponding game objects. I have empty game objects set up with colliders and they have the correct tags. 
```
if (coll.Raycast(myRay, out hitInfo, 100.0f))
            {
                if (hitInfo.collider.tag == "To1up")
                {
                    player.transform.position = floor1;
                }
                if (hitInfo.collider.tag == "To2up")
                {
                    player.transform.position = floor2;
                    Debug.Log("hithit");
                }
                if (hitInfo.collider.tag == "To1down")
                {
                    player.transform.position = floor1;
                }
                if (hitInfo.collider.tag == "ToGdown")
                {
                    player.transform.position = floorG;
                }
            }
```
### Fixed 17/11/2020:
The problem was solved by changing `coll.Raycast` to `Physics.Raycast`.

## 17/11/2020
I have a new issue where to link the nav meshes together I can use nav mesh link, which means I don't need to make use of the raycast code one above. 
I tried to use `navmeshagent.warp`, but warp was not being recognized in the code, so I switched back to using `transform.position`. In order for transform to work I needed to write this in the script:
```
myAgent.transform.position = floor1;
myAgent.enabled = false;
myAgent.enabled = true;
```
Instead of taking the player position it references the navmesh and through that the player can move between navmeshes.

