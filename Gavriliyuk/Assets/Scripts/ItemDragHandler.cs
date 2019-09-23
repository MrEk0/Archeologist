using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDragHandler : MonoBehaviour
{
    private bool selected = false;
    private Vector3 startPosition;

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x, mousePos.y);
        }
    }

    private void OnMouseDown()
    {
        selected = true;
        startPosition = transform.position;
    }

    private void OnMouseUp()
    {
        selected = false;
        transform.position = startPosition;
    }
}
