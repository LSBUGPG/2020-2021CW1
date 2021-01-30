using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public List<Behaviour> states = new List<Behaviour>();

    void SetBehaviour(string behaviourName)
    {
        states.ForEach((behaviour) =>
            behaviour.enabled =
                (behaviour.GetType().ToString() == behaviourName));
    }
}
