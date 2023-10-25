using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelSizeInSafePuzzle : MonoBehaviour
{
    [SerializeField] private GameObject parentSafePuzzle;
    [SerializeField] private GameObject LeftUpperCornerSafePuzzle;
    [SerializeField] private GameObject RightUpperCornerSafePuzzle;
    [SerializeField] private GameObject LeftLowerCornerSafePuzzle;
    [SerializeField] private GameObject RightLowerCornerSafePuzzle;
    private void Awake()
    {
        if(parentSafePuzzle == null)
        {
            parentSafePuzzle = GameObject.Find("SafePuzzle");
        }

        setSizeHalf(LeftUpperCornerSafePuzzle);
        setSizeHalf(RightUpperCornerSafePuzzle);
        setSizeHalf(LeftLowerCornerSafePuzzle);
        setSizeHalf(RightLowerCornerSafePuzzle);
        LeftUpperCornerSafePuzzle.GetComponent<RectTransform>().localPosition = new Vector3(-LeftUpperCornerSafePuzzle.GetComponent<RectTransform>().sizeDelta.x / 2f, LeftUpperCornerSafePuzzle.GetComponent<RectTransform>().sizeDelta.y / 2f, 0f);
        RightUpperCornerSafePuzzle.GetComponent<RectTransform>().localPosition = new Vector3(RightUpperCornerSafePuzzle.GetComponent<RectTransform>().sizeDelta.x / 2f, RightUpperCornerSafePuzzle.GetComponent<RectTransform>().sizeDelta.y / 2f, 0f);
        LeftLowerCornerSafePuzzle.GetComponent<RectTransform>().localPosition = new Vector3(-LeftLowerCornerSafePuzzle.GetComponent<RectTransform>().sizeDelta.x / 2f, -LeftLowerCornerSafePuzzle.GetComponent<RectTransform>().sizeDelta.y / 2f, 0f);
        RightLowerCornerSafePuzzle.GetComponent<RectTransform>().localPosition = new Vector3(RightLowerCornerSafePuzzle.GetComponent<RectTransform>().sizeDelta.x / 2f, -RightLowerCornerSafePuzzle.GetComponent<RectTransform>().sizeDelta.y / 2f, 0f);

    }
    private void setSizeHalf(GameObject childCornerObject)
    {
        childCornerObject.GetComponent<RectTransform>().sizeDelta = new Vector2(parentSafePuzzle.GetComponent<RectTransform>().sizeDelta.x / 2, parentSafePuzzle.GetComponent<RectTransform>().sizeDelta.y / 2);
    }
    // Update is called once per frame
    private void Update()
    {
        
    }
}
