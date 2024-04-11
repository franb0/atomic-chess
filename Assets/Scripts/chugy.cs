using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pice : MonoBehaviour
{
    public bool moving;
    public Vector3 currentPos;
    public float tileSize = 1.0f;
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moving = true;
            currentPos = transform.position;
        }
    }

    private void OnMouseUp()
    {
        moving = false;
        Snap();
    }

    void Update()
    {
        if (moving)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 1;
            transform.position = newPos;
        }
    }

    void Snap()
    {
        Vector3 snappedPos = new Vector3(
            Mathf.Round(transform.position.x / tileSize) * tileSize,
            Mathf.Round(transform.position.y / tileSize) * tileSize,
            transform.position.z
        );

        transform.position = snappedPos;
    }
}
