# Monster Spawner

## 10/11/2020

Hello, by the end of this tutorial you should have a random monste spawner.

---

1. Firstly you will need something to spawn, you can either drag in an asset or create a shape inside unity.

Name it enemy.
Give it a colour if it is a unity shape.
Give it a ridgid body.

---

2. Duplicate the object twice or drag in two more different enemy srpites.

Change the colours of the two new duplicates.
You can create a prefabs folder and drag in the 3 enemies.
Delete them from the hierarchy if they're there.

---

3. Now to create a spawner, rightclick in the hierarchy and create an empty gameobject.

Rename it to Random Enemy Spawner.
Right click your Random Enemy Spawner and click create empty.
In the inspector, next to the name if the object, click on the box.
Click on a coloured circle.

---

3. Duplicate the circle and place it in random locations.

This is where the enemy can spawn.

---

4. Go back to the Random Enemy Spawner and give it a script named Spawner. Once open, write up the following before void start.

public Transform[] spawnPoints;
publicGameObject[] enemyPrefabs;

You can delete the void Start section.

---

5. Now in the void Update the following will make a random enemy spawn when the mouse is clicked.

if (Input.GetMouseButtonDown(0))
{
int randEnemy = Random.Range(0, enemyPrefabs.Length);
int randSpawPoint = Random.Range(0, spawnPoints.Length);

Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawPoints].position, transform.rotation);
}

This will make the enemies spawn randomly when the mouse button is clicked.

---

6. Select all the spawners in the hierachy and drag them over to the drop down menu in the inspector labled Spawn Points.

---

7. Then select all the enemy assets and drag them into the Enemy Prefabs menu which is under the Spawn Points menu.

---

8. Now you should have enemy spawning whenever you click the mouse button.

Remember to save as you go.














