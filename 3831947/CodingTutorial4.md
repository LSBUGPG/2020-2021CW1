# Health/Heart System

- In this tutorial we will be making a health system in Unity, we will need a empty heart and a full heart sprites. Create a UI canvas and make sure the scale mode is set to **scale with screen size** so the UI will scale to the aspect ratio.

- Create a UI image and drag the heart sprite into the empty sprite slot, once that is done duplicate as many hearts as you like into the scene.

- Insert a new Script called **health** and insert a **public int health and int hearts** at the top of the script, so when this is equal to one we should only have one heart container visible in the scene. Make sure to type in **Unity Engine UI at the very top of the script.**

- Insert the variables called **full heart**, it should look like this. 

      public Image [] hearts;
      public Sprite fullheart;
      public emptyHeart;
      
 - Back into Unity, we will create a empty object and name it **player** and drag our **health script** into it. Insert a default value (4) for health qand drag and drop the empty heart images in the empty slots in the inspector.
 
 - under the void update insert the following. If i is smaller than we want the heart of  index i to be visible, and if the i is bigger than the  number of hearts then the hearts in the array would be hidden. 
 
        for ( int i = 0; i hearts.Length; i++) {
         if (if < numOfHearts){
           hearts [i].enabled = true;
         } else {
            hearts [i].enabled = false;

- In Unity, we can see when we press play the number of hearts are equal to 4, this can be altered in the inspector to any number. 

-Back to the script, we will create another **if statement** inside the same loop, and checking whether i is smaller than the amount of Health. So the health sprite of index i will display a full heart. And all the heart images with an index greater than i will have an empty heartsprite.

    for ( int i = 0; i hearts.Length; i++) {
         if( i < health){
           hearts [i].sprite = fullHeart;
          } else {
            hearts [i].sprite = emptyHeart;
          }
         if (if < numOfHearts){
           hearts [i].enabled = true;
         } else {
            hearts [i].enabled = false;
         }
         
   - And for the last part we need to make sure that the player does not have more health than the number of heart containers. So will need to make a **if statement** under the void update function. So this will check whether the health is greater than the number of hearts containers so we will set health equal to the number of hearts. 
   
    void Update(){
   
    if ( health > numOfHearts){
      health = numOfHearts;
      
 - Into Unity we can press play and we can see that the health system is working. In the inspector we can alter the **Number of Hearts** and the **Health**. 
   






