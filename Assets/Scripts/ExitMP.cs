using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMP : MonoBehaviour
{
    public int goal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(GameControllerMP.instance.GetScore() >= goal)
            {
                GameControllerMP.instance.LoadNextLevel();
            }
        }
    }
}
