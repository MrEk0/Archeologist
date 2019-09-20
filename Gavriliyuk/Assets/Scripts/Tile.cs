using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject drop;
    private void OnMouseDown()
    {
        Debug.Log("Click");
        //Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float strictMouseX = Mathf.RoundToInt(mousePos.x);
        float strictMouseY = Mathf.RoundToInt(mousePos.y);
        Vector2 newMousePos = new Vector2(strictMouseX, strictMouseY);
        Instantiate(drop, newMousePos, transform.rotation);
    }
}
