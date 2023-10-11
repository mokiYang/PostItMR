using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperInteract : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Quaternion initialRotation;
    private GameObject closestWall;
    private static GameObject draggingPaper;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 newPosition = ray.origin + ray.direction * offset.z;
            newPosition.x += offset.x;
            newPosition.y += offset.y;
            transform.position = newPosition;

            // Find the closest wall while dragging
            float minDistance = float.MaxValue;
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
            foreach (GameObject wall in walls)
            {
                float distance = Vector3.Distance(transform.position, wall.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestWall = wall;
                }
            }

            if (closestWall != null)
            {
                float distanceToWall = Vector3.Distance(transform.position, closestWall.transform.position);
                if (distanceToWall < 1.0f)
                {
                    transform.rotation = closestWall.transform.rotation;
                }
                else
                {
                    transform.rotation = initialRotation;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            if (draggingPaper == gameObject)
            {
                draggingPaper = null;
                if (closestWall != null)
                {
                    float distanceToWall = Vector3.Distance(transform.position, closestWall.transform.position);
                    if (distanceToWall < 1.0f)
                    {
                        transform.rotation = closestWall.transform.rotation;
                    }
                }
            }
        }
    }

    void OnMouseDown()
    {
        if (draggingPaper == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Paper")
            {
                isDragging = true;
                draggingPaper = gameObject;
                offset = hit.point - hit.collider.gameObject.transform.position;
                offset.z = (hit.point - Camera.main.transform.position).magnitude;
            }
        }
    }
}
