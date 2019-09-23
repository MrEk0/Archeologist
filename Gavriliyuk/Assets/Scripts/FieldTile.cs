using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class FieldTile : MonoBehaviour
{
    [SerializeField] float chanceToDigUp = 30f;
    [SerializeField] List<GameObject> dropItems;
    [SerializeField] Tilemap fieldTilemap;

    private Vector3 previousPosition;
    private int tileLevel = 0;

    public event Action OnClick;

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        OnClick();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float strictMouseX = Mathf.RoundToInt(mousePos.x);
        float strictMouseY = Mathf.RoundToInt(mousePos.y);
        Vector2 newMousePos = new Vector2(strictMouseX, strictMouseY);

        DigUp(newMousePos);

        if (RandomInstantiation())
        {
            Instantiate(dropItems[RandomDrop()], newMousePos, transform.rotation);
        }
    }

    private bool RandomInstantiation()
    {
        float probability = Random.Range(0, 100);

        if(probability<=chanceToDigUp)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int RandomDrop()
    {
        int rand = Random.Range(0, dropItems.Count);

        return rand;
    }

    private void DigUp(Vector3 position)
    {
        Vector3Int currentCell = fieldTilemap.WorldToCell(position);

        fieldTilemap.SetTile(currentCell, null);
        Debug.Log("Delete");
    }
}
