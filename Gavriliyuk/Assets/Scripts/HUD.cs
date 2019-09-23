using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] float startShovelNumber=10f;
    [SerializeField] float treasureCost = 50f;
    [SerializeField] float flowerCost = 10f;
    [SerializeField] float blueTreasureCost = 30f;
    [SerializeField] int numberOfAllItems = 25;
    [SerializeField] float additionalShovels = 4f;

    [Header("Inner References")]
    [SerializeField] Text shovelCount = null;
    [SerializeField] Text valueText = null;
    [SerializeField]  GameObject treasure = null;
    [SerializeField]  GameObject flower = null;
    [SerializeField]  GameObject blueTreasure = null;
    [SerializeField] GameObject losePanel = null;
    [SerializeField] GameObject winPanel = null;

    FieldTile[] fieldtiles;

    private float treasureAmount=0f;
    private float blueTreasureAmount=0f;
    private float flowerAmount=0f;
    private float value = 0f;
    private int numberOfItems = 0;

    private Text treasureText;
    private Text blueTreasureText;
    private Text flowerText;

    private void Awake()
    {
        fieldtiles = FindObjectsOfType<FieldTile>();
        treasureText = treasure.GetComponentInChildren<Text>();
        blueTreasureText = blueTreasure.GetComponentInChildren<Text>();
        flowerText = flower.GetComponentInChildren<Text>();
    }

    private void OnEnable()
    {
        foreach (FieldTile tile in fieldtiles)
        {
            tile.OnClick += DecreaseShovelCount;
        }
    }

    private void OnDisable()
    {
        foreach (FieldTile tile in fieldtiles)
        {
            tile.OnClick -= DecreaseShovelCount;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        shovelCount.text = startShovelNumber.ToString();
        valueText.text = value.ToString();
    }

    private void DecreaseShovelCount()
    {
        if (startShovelNumber > 1)
        {
            startShovelNumber--;
            shovelCount.text = startShovelNumber.ToString();
        }
        else
        {
            GameOver();
        }
    }

    private void ChangeValue()
    {
        value = treasureAmount * treasureCost + blueTreasureAmount * blueTreasureCost + flowerAmount * flowerCost;
        valueText.text = value.ToString();
    }

    public void ChangeItemsText(GameObject gameObject)
    {
        if (gameObject == flower)
        {
            flowerAmount++;
            CountItems();
            flowerText.text = flowerAmount.ToString();
            IncreaseShovelCount();

        }
        else if (gameObject == treasure)
        {
            treasureAmount++;
            CountItems();
            treasureText.text = treasureAmount.ToString();
            IncreaseShovelCount();
        }
        else if (gameObject == blueTreasure)
        {
            blueTreasureAmount++;
            CountItems();
            blueTreasureText.text = blueTreasureAmount.ToString();
            IncreaseShovelCount();
        }

        ChangeValue();
    }

    private void CountItems()
    {
        if (numberOfItems < numberOfAllItems - 1)
        {
            numberOfItems++;
        }
        else
        {
            Victory();
        }
    }

    private void IncreaseShovelCount()
    {
        startShovelNumber+=additionalShovels;
        shovelCount.text = startShovelNumber.ToString();
    }

    private void GameOver()
    {
        Instantiate(losePanel, transform);
    }

    private void Victory()
    {
        Instantiate(winPanel, transform);
    }
}
