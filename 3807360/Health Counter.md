# Health Counter

## 13/10/2020

Hello there, here is a simple tutorial on how to create a health/life counter.

---

1. Firstly insert a heart asset which will act as your health or lives. For now there will be 3.

Once they are in your assets folder, drag them into your scene.

Place them where you wish to have them viewable in game.

Rename each heart to: heart1 heart2 heart3. This is to make it easier to differentiate between the 3.

---

2. Now to test the code after it is complete, there will be a health increasing zone and decreasing zone.

Drag in the object which will increase and decrease the life count. Increase on the left. Decrease on the right.

Drag in a simple player. Player will be inbetween the increase and decrease objects.

Give all the increase and decrease objects a box collider which activates on trigger.

Give the player object a rigidbody, set the gravity to 0 and collision detection to continous. This is so the object doesn't fall and is always looking for colliders.

---

3. Give the health increase object a script called HeartScript. Once the script is open, delete anything inside the public class {} and replace it with the following:
     
     void OnTriggerEnter2D (Collider2D col)
     
    {
    
            GameControlScript.health += 1;
            
    }
    
    
    This means when something, the player, collides with it the health count will increase by 1.
    
---
    
4. Give the health decrease object a script called DeathScript. Once the script is open, delete anything inside the public class {} and replace it with the following:
     
     void OnTriggerEnter2D (Collider2D col)
     
    {
    
            GameControlScript.health -= 1;
            
    }    
    
    
    This means when something, the player, collides with it the health count will decrease by 1.
    
---
    
5. Now the player will need a movement script. Give the player object the script, name it MovementScript. Open it and insert the following:
    
    public class MovementScript : MonoBehaviour

{

    public float speed = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}

The public float speed will set the base speed of the player to 10.

The if statments mean that when the left key is pressed, the character will move left at the speed of 10. Same goes for the right key.

---

### Now that all the set up is complete, the long tedious part begins. The part of making the hearts increase and decrease. So! Here goes nothing.

---

6. Create a text object and write in Game Over in the text box, edit as you wish then name the conponent GameOverText.

Drag the text wherever you wish on your scene.

---

7. Create an empty game object and name it GameControl.

Give this object a script called GameControlScript. Once it's open, write in the following.

public class GameControlScript : MonoBehaviour

{

    public GameObject heart1, heart2, heart3, gameOver;
    public static int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 3)
            health = 3;

        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
                
        }
    }
}

What this block of code does is count the amount of hearts active, when none are left the game over text will be displayed and further movements stopped.

---

8. Now click on the GameControl object and drag the required objects into the slots that show up under the inspector.

These are now here thanks to the giant block of code.

---

9. Hit play and see how it runs.

Remember to save everything as you go along.

---








