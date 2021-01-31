## First Person Camera and Movement

## 17/11/2020

In this tutorial you will learn how to make a first person camera and movement script.

---

1. Firstly what you want to do is make sure you have an enviornment to test this on.

---

2. Now we create an empty object, name it first person player.

Add a character controller to this through add component.

---

3. Right click on the first person player to create a cylinder, this is so we can see the player. You can change this to your character model if you wish.

Scale it to the empty object.
Turn off capsul collider.
Add a material so it is easier to see.

---

4. Add a camera if there isn't one, however if there is drag in into the first person player folder in the heirarchy.

Reset the transform.
Drag it up to the top of the object.

---

5. Time to add a player look script, write up the following script on the camera.

public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

Mouse sensotivity is the speed at which the camera will move.

Now in void start put:

        Cursor.lockState = CursorLockMode.Locked;
        
This will lock the camera to the centre of the screen and hide it.

Now in void update:

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

This will make the camera move up down left and right, however stop it from going 360 degrees up and down.

---

6. Click on the first person player object and create a new player movement script with the following.

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

The first three are controlling the speed, jump height and gravity component.
The next three are a ground check, this stops the velocity of falling from consantly increasing.

Delete void start and add this to void update:

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

This will allow the player to move, jump, fall and reset the velocity.

---

7. Create an empty object under the first person player object, drag it to the very bottom and name this ground check.

---

8. After all the chuncky code, select your first person player object.

Add a new layer in the inspector, call this Ground. 
Drag the first person player into the controller spot.
Drag the ground check object tp groung check.
Select the layer Ground to ground mask

You will have to change the actual ground to have the layer ground.

---

Now test it out, remember to save as you go.

























