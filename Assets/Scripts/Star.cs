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
            Debug.Log("here2!!");
            //add score
            GameControllerMP.instance.AddScore();

            //play sfx


            //play vfx
            Instantiate(vfx, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("here1!!");
            //add score
            GameControllerMP.instance.AddScore();

            //play sfx


            //play vfx
            Instantiate(vfx, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
