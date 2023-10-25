using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInventoryPosition : MonoBehaviour
{
    private GameObject Inventory;
    private GameObject OpenInventory;
    [SerializeField] private GameObject 
        collectedItem1,
        collectedItem2,
        collectedItem3;

    private float openSize;
    private float startXPos;
    private bool open;

    private void Awake()
    {
        if (Inventory == null)
        {
            Inventory = GameObject.Find("Inventory");

        }
        if (OpenInventory == null)
        {
            OpenInventory = GameObject.Find("openInventory");
        }
    }

    private void Start()
    {
        open = false;
        setOpenInvetoryPosition();
        ButtonClick();
        ChangeInventoryState();
    }
    private void setCollectedItemsPositions()
    {
        collectedItem1.GetComponent<RectTransform>().sizeDelta = new Vector2(Inventory.GetComponent<RectTransform>().sizeDelta.x * 0.91f, Inventory.GetComponent<RectTransform>().sizeDelta.y / 3f * 0.91f);
        collectedItem1.GetComponent<RectTransform>().localPosition = new Vector3(collectedItem1.GetComponent<RectTransform>().localPosition.x, Inventory.GetComponent<RectTransform>().sizeDelta.y / 3f * 0.91f, 0f);

        collectedItem2.GetComponent<RectTransform>().sizeDelta = collectedItem1.GetComponent<RectTransform>().sizeDelta;
        collectedItem3.GetComponent<RectTransform>().sizeDelta = collectedItem1.GetComponent<RectTransform>().sizeDelta;
        collectedItem3.GetComponent<RectTransform>().localPosition = new Vector3(collectedItem3.GetComponent<RectTransform>().localPosition.x, -Inventory.GetComponent<RectTransform>().sizeDelta.y / 3f * 0.91f, 0f);

    }
    private void setOpenInvetoryPosition()
    {

        float xPos =
            Inventory.GetComponent<RectTransform>().localPosition.x
            - Inventory.GetComponent<RectTransform>().sizeDelta.x / 2
            - OpenInventory.GetComponent<RectTransform>().sizeDelta.x / 2;

        OpenInventory.GetComponent<RectTransform>().localPosition = new Vector3(xPos,
            OpenInventory.GetComponent<RectTransform>().localPosition.y,
            OpenInventory.GetComponent<RectTransform>().localPosition.z);

        if (Inventory.GetComponent<RectTransform>().sizeDelta.x != 0)
        {
            openSize = Inventory.GetComponent<RectTransform>().sizeDelta.x;
            startXPos = Inventory.GetComponent<RectTransform>().localPosition.x;
        }
        else
        {
            Debug.LogError("Open Size is 0");
        }
    }
    private bool IsOpen()
    {
        if (Inventory.GetComponent<RectTransform>().sizeDelta.x == 0)
        {
            open = false;
            return open;
        }
        else
        {
            open = true;
            return open;
        }
    }
    private void ButtonClick()
    {
        OpenInventory.GetComponent<Button>().onClick.AddListener(ChangeInventoryState);
        
    }
    private void ChangeInventoryState()
    {
        if (!IsOpen())
        {
            Inventory.GetComponent<RectTransform>().sizeDelta = new Vector2(openSize, Inventory.GetComponent<RectTransform>().sizeDelta.y);
            Inventory.GetComponent<RectTransform>().localPosition = new Vector3(startXPos, Inventory.GetComponent<RectTransform>().localPosition.y, 0f);
            setOpenInvetoryPosition();

        }
        else
        {
            Inventory.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, Inventory.GetComponent<RectTransform>().sizeDelta.y);
            Inventory.GetComponent<RectTransform>().localPosition = new Vector3(960f, Inventory.GetComponent<RectTransform>().localPosition.y, 0f);
            OpenInventory.GetComponent<RectTransform>().localPosition = new Vector3(960f - OpenInventory.GetComponent<RectTransform>().sizeDelta.x/2,
            OpenInventory.GetComponent<RectTransform>().localPosition.y, OpenInventory.GetComponent<RectTransform>().localPosition.z);
        }

    }
    private void Update()
    {
        setCollectedItemsPositions();
    }

}
