# Learning Journal
29/09/2020

First session of programming, finally going to make use of this account since I created it last year. Also didn't really know that taking regular breaks is best when programming, maybe the hours spent on coding is just asking for stress.


04/10/2020

Finished designing characters development including the Rule of the protagonist and the motivation of the villian, no issues encountered.


05/10/2020

Started working on the 3D level design work, I didn't actually know we had this as a task so I am starting rather late, I have so for been able create three moodboards, a gameplay loop, the name of my game, the main mechanic and the name of my game.


05/10/2020

Made enemy pathing between two points using an array. Also finished the players movement script by using Unity's built in character controller.


05/10/2020

Can't figure out how to make the enemy chase the player. Was able to make a game over script where if the players collider hits a game objects with the tag "enemy" it will reload the scene.


09/10/2020

Can't get a way to set the axis for the field of view script.


13/10/2020

Started working on the first tutorial, I was originally going for the function where if you collect all collectables in a level, it would open the door to the next level, I however couldn’t find a method of doing this in the case of having multiple collectables with the same tag, so I decided to just do the first tutorial on destroying objects when having the player walk on them.


27/10/2020

Add force causes too many problems as a movement script, going to make a seperate public float instead and use Time.DeltaTime to avoid any issues.


09/11/2020

Did not have consistent capitalisation in my coding which gave me compile errors, now fixed


10/11/2020

Set a trigger for if the player collides with the enemy, game will reset.
```
 if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
        }
```


11/11/2020

Was working on the chase script for my game and couldn't figure out what was going wrong, had Initially tried to make it using `OnTriggerEnter` so once the player entered the enemies “Vision” collider, the enemy would chase the player. This became a problem as it interfered with a script to reset the game once the player collided with an enemy. Made the change from `OnTrigger` to `OnCollison` so it would hit the enemies hit box and not the collider set to trigger.
Encountered another problem where if the enemy lost sight of the player he would not return to patrolling and would continue in the direction he last saw the player. Got a tutor (David) to help my figure out what was wrong.


24/11/2020

Made a quit button and start button with coresponding scrips that works, small issue with the camera change making the mouse invisiable but not an issue.
```
   public static bool InMainMenu = false;

    

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        InMainMenu = false;
        ToCredits.InCredits = false;
    }

    public void quitGame()
        {
            Application.Quit();
        }
```


2/12/2020

Tried to add another enemy to patrol another part of the level, however having different ways points with the same tag conflicts with exisiting waypoints and enemies.


08/12/2020

Working on tutorial three, had issues with my `OnCollisionEnter`script, tutor helped me realise it had to do with my character controller, apparently to be removed and interferes with other code, plan to develop a different movement script for other project. 
Change the code to `void OnControllerColliderHit(ControllerColliderHit hit)` and my `if (other.gameObject.tag == "Enemy")` to `if (hit.gameObject.tag == "Enemy")`.

Issues with my enemy patrol script occuered when the second enemy reached a waypoint, it seemed that I forgot that one of the public varibles I used was another script that I had forgot to add to my waypoints.


12/1/2021

Made a pause menu scirpt that would freeze the game when paused and unfreezed it when resume was hit. I used timescale to freeze the game.
```
Time.timeScale = 0f;
```


18/1/2021

Bound the walking animations to W/A/S/D and made it so that animation wouldn't play if no buttons were being pressed.


21/1/2021

Had an issue with my pause and main menu, my game binds the mouse and the look function, so my character would turn with the mouse, now when the game was paused, the mouse would still be gone, this would stop me from using my pause menu, got some help on how to fix it.
```
 public class Start_Game : MonoBehaviour
{ 
    public static bool InMainMenu = false;

    

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        InMainMenu = false;
        ToCredits.InCredits = false;
    }
    
}
    public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject Minimap;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Minimap.SetActive(true);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Minimap.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        Minimap.SetActive(true);
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Start_Game.InMainMenu = true;
        ToCredits.InCredits = true;
    }
}

public class ToCredits : MonoBehaviour
{
    public static bool InCredits = false;
    
     void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(3);
        InCredits = true;
    }


}
```
