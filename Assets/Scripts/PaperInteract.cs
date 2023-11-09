using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperInteract : MonoBehaviour
{
    public float detectionRadius;
    public bool canRotate = true;


    private Quaternion originalRotation;

    private void Start()
    {
        originalRotation = transform.rotation;
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
        Collider targetCollider = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Wall") && canRotate)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    targetCollider = collider;
                }
            }
        }

        if (targetCollider)
        {
            transform.rotation = targetCollider.transform.rotation;
        }
        else
        {
            // transform.rotation = originalRotation;
        }
    }
}
