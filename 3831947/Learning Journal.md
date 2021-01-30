

**03/10/2020**


I attemped to make AI for my game, this involved using the **NevMeshAgent** and **Baking** function . This allows the AI to move around the map that is walkable, and the walls that isn't walkable, since my game is in a maze the AI needs to move around the map without it bumping into the walls, I also made the AI to move at certain points as well so that it can move in a certain area rather than the whole map, since I plan to make more than one AI in my scene. I did have some issues with the waypoints, the AI wouldn't face in the right direction, but I just redid the waypoints and it worked. 






**16/11/2020**
  
  First time creating 3D animation in Unity for a game, I needed my character to move up down, left, right and down with animation. Used **Animator.SetBool** to trigger certain animations for the player- from idle to walk and vice versa. 
  
  I struggled to get the animations to move smoothly, the character would move in all directions but it would bounce back to the original position which is unnatural. 
  
  
  
     void Start()
     {
        myAnimator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey ("s") || Input.GetKey ("a") || Input.GetKey ("d"))
        {
            myAnimator.SetBool("istheplayermoving", true);
        }
        else
        if (!Input.GetKey("w") || Input.GetKey ("s") || Input.GetKey ("a") || Input.GetKey ("d"))
        {
            myAnimator.SetBool("istheplayermoving", false);
        }
        

    }



   **17/11/2020**
   
   
Attempted this the next day and made the code for the player model to rotate in all directions. And I finally fixed the issue and now the player moves without bouncing back and the animations seems to work well. 

      float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (moveX != 0 || moveZ != 0)
        {
            modelTransform.rotation = Quaternion.LookRotation(new Vector3(moveX, 0f, moveZ));

        }

    Vector3 movement = new Vector3(moveX, 0f, moveZ);
        GetComponent<Rigidbody>().velocity = movement * moveSpeed * Time.deltaTime;
        }


**9/11/2020**

There was an issue with one of the scripts when the player collected the honey, the UI wouldn’t go down to 0 instead it would stay at 1. The UI should’ve countdown from 5 to 0, which would show how many collectables they had left. This is what the script was like before.

    public void UpdateUI() 
    {
        if (cur_coins > 0)
        {
            coinsLeft.text = "Honey" + cur_coins.ToString ("D");
            Door.SetActive (true);
    
            
   **10/11/2020**
   
   
It was something I couldn’t ignore because the player wouldn’t know if they collected all  objects in the maze.
I gave up and returned the next day to think of why it wouldn’t work since the script looked fine, however I realised that I missed a couple of lines of code.  And this finally made the UI Countdown to 0 and trigger the door. Small error but I realised it and it made sense why the UI wasn't counting down properly.

  
    public void UpdateUI() 
    {
        if (cur_coins > 0)
        {
            coinsLeft.text = "Honey" + cur_coins.ToString ("D");

        }
        else if (cur_coins <= 0) {
            coinsLeft.text = "Honey" + cur_coins.ToString ("D");
            Door.SetActive (true);
        }

**20/11/2020** 


Created a script to trigger an image when the player goes near an object (collider), it was meant to be a board sign for the player to read the instructions of the game. A simple code but I made a small mistake again, I spelt 'enabled' wrong, took me a while to find it but I got there in the end. 

    {
     [SerializeField] private RawImage customImage;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            customImage.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            customImage.enabled = false;
        }
    }







