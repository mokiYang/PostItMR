using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMP : MonoBehaviour
{
    public int goal;
    public Material open;

    private void Update()
    {
        if (GameControllerMP.instance.GetScore() >= goal)
        {
            MeshRenderer meshRenderer = transform.GetComponent<MeshRenderer>();
            meshRenderer.material = open;
        }
    }

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
