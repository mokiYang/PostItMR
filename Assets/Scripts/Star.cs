using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public GameObject vfx;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //add score

            //play sfx

            //play vfx
            Instantiate(vfx, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
