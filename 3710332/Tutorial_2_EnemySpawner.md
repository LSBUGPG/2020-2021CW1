Step 1:

Create a 3D object inside unity and name it enemy then give the enemy object a rigidbody.

Step 3:

Create a prefab folder and drag the object from the hierachy into it to create a prefab and delete it from the hierachy.

Step 4:

Create a empty gameobject in the hierachy and rename it "Random Enemy Spawner". Right click the Random Enemy Spawner and create empty. Duplicate the spawner and place them in random loactions.

Step 5:

Give the spawner a new script component and name it Spawner. Open the script and delete the void start. Once deleted put this line in:

    public Transform[] spawnPoints; 
    public GameObject[] enemyPrefabs;
  
Step 6:

In void update enter this:

  if(Input.GetkeyDown(t))
  {
    int randomEnemy = Random.Range(0, enemyPrefabs.Length); int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
    
    Instantiate(EnemyPrefab[randEnemy], spawnPoints[randomSpwnPoints].position, transform.rotation);
  }
    //This will make the enemies spawn randomly when the "t" key is pressed. 
    //If you dwon want to use GetKeyDown, you can use GetMouseButtonDown instead
    
Step 7:

Drag the enemy prefabs into the spawners inspector where it says Spawn Points
    



