using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPicture : MonoBehaviour, IPointerEnterHandler
{
    Image image;
    Text countText;

    HUD hud;
    private float startAmount=0f;

    private void Awake()
    {
        image = GetComponent<Image>();
        countText = GetComponentInChildren<Text>();
        hud = GetComponentInParent<HUD>();
    }

    private void Start()
    {
        countText.text = startAmount.ToString(); 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(hit.collider!=null)
        {
            if(hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite==image.sprite)
            {
                hud.ChangeItemsText(gameObject);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
