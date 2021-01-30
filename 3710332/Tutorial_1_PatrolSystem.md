Step 1:

Create a 3D object and insert a script component

Step 2:

Open the script component and add the variables:

    public float speed;
    public float waitTime;
    public float startWaitTime;
    public Transform[] patrolPoint; 
      // this array will be how you set patrol points in your unity project without editting the script with every new point
    public int index; 
      //this is the numerical variable regarding how many points are in your array
Step 3:

In void Start():

    waitTime = startWaitTime; 
      //this makes the two aforementioned variables equal the same thing, allowing for a sense of regularity in the game
    index = Random.Range(0, patrolPoint.Length); 
      // this makes the int variable **Index** randomly select any of the points in the **patrolPoints** array
Step 4:

In void Update() you will need to input:

  transform.position = Vector3.MoveTowards(transform.position, patrolPoint[index].position, speed * Time.deltaTime); 
    // this causes the game object to move towards one of the points in the patrolPoint[] array.   

    if (Vector3.Distance(transform.position, patrolPoint[index].position) < 0.2f)
        // if the game object is 0.2 frames (or less) away from the patrol point--
       
      {
          if (waitTime <= 0) //if the wait time is less than or equal to 0--
          {
            index = Random.Range(0, patrolPoint.Length); 
                //a new point will be selected
            waitTime = startWaitTime; 
                //the wait time will be reset

          }
          else
          {

            waitTime -= Time.deltaTime; 
                //otherwise, keep counting down on the wait time
          }
      }    
Step 5:

Save your script and return to unity. The script will then have a new public float with the start wait time. You can adjust the time as nescessary to your needs.

Step 6:

Go to the GameObject menu and select Create empty. Instead of setting a 3d model, set an icon/gizmo in the inspector so you can see a visual of the game object and set it in a place where you want one of the patrol points. Copy and paste this gameObject however many times you wish and place them as you wish, these will be your patrol points.

Step 7:

In the Heirarchy, select the 3D gameObject that has the script component and in the size float, type in the number of patrol poionts you have made. Open the array settings and drag the patrol points into the array.


