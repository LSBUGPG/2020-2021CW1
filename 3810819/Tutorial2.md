# Making an AI move on the Nav Mesh in Unity.md
This is a tutorial on how to make an AI move to an area you click on in the Nav Mesh

After starting up a 3D Unity project, create a C# script and give it an applicable name, such as **AI Controller**. When you have created it, open it and delete the **System.Collections** and **System.Collections.Generic** code at the top, but keep the using **UnityEngine**. Then under the using UnityEngine code, add in **using UnityEngine.AI** as the script will not work without it.

Next delete the void start script as that is not needed, then creata two public components for the script. One for NavMeshAgent and one for Camera and give them an applicable name like **cam** for Camera and **agent** for NavMeshAgent. In the Update void, write the following:

if(Input.GetMouseButtonDown(0))
{
  Ray ray = cam.ScreenPointtoRay(Input.mousePosition);
  RaycastHit hit;
  
  if (Physics.Raycast(ray, out hit)
  {
    agent.SetDestination(hit.point)
  }
}

If you wrote it correctly, you should see two slots pop up on the AI Controller script component. If so, add in the relevant to each of the slots. After that you should see your character moving to where ever you click on the surfaces containing the baked NavMesh.
