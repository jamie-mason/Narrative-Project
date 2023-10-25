using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafePuzzle : MonoBehaviour
{
    private uint[] shelfQuantities = { 1, 1, 1, 1 };
    private uint[] shelfCorrect =new uint[4];
    [SerializeField] private GameObject[] childPanels = new GameObject [4];
    private GameObject puzzle;
    private GameObject SafeBody;
    private GameObject SafeDoor;

    private uint numberOfShelfStates = 7;
    private void Awake()
    {
        puzzle = GameObject.Find("SafePuzzle");
        SafeBody = GameObject.Find("Safe1Body");
        SafeDoor = GameObject.Find("Safe1Door");
    }
    private void Start()
    {
        shelfCorrect[0] = 2;
        shelfCorrect[1] = 3;
        shelfCorrect[2] = 7;
        shelfCorrect[3] = 6;

        for (int i = 0; i < shelfQuantities.Length; i++)
        {
            ShelfLookOn1(i);

        }
        ButtonClick(0);
        ButtonClick(1);
        ButtonClick(2);
        ButtonClick(3);
        puzzle.SetActive(false);
        SafeDoor.GetComponent<BoxCollider>().enabled = false;
        SafeBody.GetComponent<BoxCollider>().enabled = true;
    }
    private void ButtonClick(int index) {

        if (index < 4)
        {
            childPanels[index].GetComponent<Button>().onClick.AddListener(delegate { NumberIncrease(index); });
        }
    }
    private void NumberIncrease(int index)
    {
        if(shelfQuantities[index] < numberOfShelfStates)
        {
            childPanels[index].transform.GetChild((int)shelfQuantities[index]-1).gameObject.SetActive(true);
            if (shelfQuantities[index] - 1 == childPanels[index].transform.childCount / 2)
            {
                for (int i = 0; i < childPanels[index].transform.childCount / 2; i++)
                {
                    if (childPanels[index].transform.GetChild(i).gameObject.activeSelf)
                    {
                        childPanels[index].transform.GetChild(i).gameObject.SetActive(false);
                    }
                }
            }
            shelfQuantities[index] = shelfQuantities[index] + 1;
        }
        else
        {
            shelfQuantities[index] = 1;
            ShelfLookOn1(index);
        }
        Debug.Log($"shelfQuantities Index {index} = {shelfQuantities[index]}");
    }
    private void ShelfLookOn1(int index)
    {
        if (shelfQuantities[index] == 1)
        {
            for (int j = 0; j < childPanels[index].transform.childCount; j++)
            {
                if (childPanels[index].transform.GetChild(j).gameObject.activeSelf)
                {
                    childPanels[index].transform.GetChild(j).gameObject.SetActive(false);
                }
            }
        }
    }
    public bool checkSafe()
    {
        bool isCorrect = false;
        for(int i = 0; i<shelfCorrect.Length; i++)
        {
            if(shelfQuantities[i] == shelfCorrect[i])
            {
                isCorrect = true;
            }
            else
            {
                isCorrect = false;
                break;
            }
        }
        return isCorrect;
    }
    private void Update()
    {
        if (checkSafe())
        {
            puzzle.SetActive(false);
            SafeDoor.GetComponent<BoxCollider>().enabled = true;
            SafeBody.GetComponent<BoxCollider>().enabled = false;

        }
    }

}
