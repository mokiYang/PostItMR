using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMP : MonoBehaviour
{
    public int goal;
    public Material open;
    public Material halfOpen;

    private void Update()
    {
        if (GameControllerMP.instance.GetScore() >= goal)
        {
            MeshRenderer meshRenderer = transform.GetComponent<MeshRenderer>();
            StartCoroutine(ChangeMaterialWithDelay(meshRenderer));
        }
    }

    IEnumerator ChangeMaterialWithDelay(MeshRenderer meshRenderer)
    {
        meshRenderer.material = halfOpen;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.material = open;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(GameControllerMP.instance.GetScore() >= goal)
            {
                GameControllerMP.instance.Pass();
            }
        }
    }
}
