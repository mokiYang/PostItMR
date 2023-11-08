using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gateway : MonoBehaviour
{
    public GameObject player3D;
    public GameObject player2D;

    private void Start()
    {
        player2D.SetActive(true);
        player3D.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player3D") && tag == "22D")
        {
            // �� 3D С��ת�� 2D
            player2D.transform.position = player3D.transform.position;
            player2D.SetActive(true);
            player3D.SetActive(false);
        }
        if (other.CompareTag("Player") && tag == "23D")
        {
            // �� 2D С��ת�� 3D
            player3D.transform.position = player2D.transform.position;
            player2D.transform.rotation = player3D.transform.rotation;
            player2D.SetActive(false);
            player3D.SetActive(true);
        }
    }
}
