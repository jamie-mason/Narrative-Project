using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBookSize : MonoBehaviour
{
    [SerializeField] private GameObject childSafePuzzle;
    [SerializeField] private GameObject VerticalBook1;
    [SerializeField] private GameObject VerticalBook2;
    [SerializeField] private GameObject VerticalBook3;
    [SerializeField] private GameObject HorizontalBook1;
    [SerializeField] private GameObject HorizontalBook2;
    [SerializeField] private GameObject HorizontalBook3;

    [SerializeField] private bool left;
    private void Start()
    {
        arrangeVerticalBooks();
        arrangeHorizontalBooks();
    }
    private void arrangeVerticalBooks()
    {
        VerticalBook1.GetComponent<RectTransform>().sizeDelta = new Vector2(childSafePuzzle.GetComponent<RectTransform>().sizeDelta.y / 4,
            childSafePuzzle.GetComponent<RectTransform>().sizeDelta.y * 0.9259f);
        VerticalBook1.GetComponent<RectTransform>().sizeDelta = new Vector2(VerticalBook1.GetComponent<RectTransform>().sizeDelta.y / 3,
            VerticalBook1.GetComponent<RectTransform>().sizeDelta.y);
        VerticalBook2.GetComponent<RectTransform>().sizeDelta = VerticalBook1.GetComponent<RectTransform>().sizeDelta;
        VerticalBook3.GetComponent<RectTransform>().sizeDelta = VerticalBook1.GetComponent<RectTransform>().sizeDelta;

        if (left)
        {
            moveVerticalBookRight(VerticalBook2);
        }
        else
        {
            moveVerticalBookLeft(VerticalBook2);
        }
        VerticalBook1.GetComponent<RectTransform>().localPosition = VerticalBook2.GetComponent<RectTransform>().localPosition;
        VerticalBook1.GetComponent<RectTransform>().localPosition = new Vector3(VerticalBook1.GetComponent<RectTransform>().localPosition.x -
            VerticalBook2.GetComponent<RectTransform>().sizeDelta.x,
            VerticalBook1.GetComponent<RectTransform>().localPosition.y, 0f);

        VerticalBook3.GetComponent<RectTransform>().localPosition = VerticalBook2.GetComponent<RectTransform>().localPosition;
        VerticalBook3.GetComponent<RectTransform>().localPosition = new Vector3(VerticalBook3.GetComponent<RectTransform>().localPosition.x +
            VerticalBook2.GetComponent<RectTransform>().sizeDelta.x,
            VerticalBook3.GetComponent<RectTransform>().localPosition.y, 0f);
    }
    private void arrangeHorizontalBooks()
    {
        HorizontalBook1.GetComponent<RectTransform>().sizeDelta = new Vector2(
            VerticalBook1.GetComponent<RectTransform>().sizeDelta.y, 
            //only line where vertical variable should not change
            VerticalBook1.GetComponent<RectTransform>().sizeDelta.x);
        HorizontalBook2.GetComponent<RectTransform>().sizeDelta = HorizontalBook1.GetComponent<RectTransform>().sizeDelta;
        HorizontalBook3.GetComponent<RectTransform>().sizeDelta = HorizontalBook1.GetComponent<RectTransform>().sizeDelta;


        HorizontalBook1.GetComponent<RectTransform>().localPosition = HorizontalBook2.GetComponent<RectTransform>().localPosition;
        HorizontalBook1.GetComponent<RectTransform>().localPosition = new Vector3(
            HorizontalBook1.GetComponent<RectTransform>().localPosition.x, 
            HorizontalBook1.GetComponent<RectTransform>().localPosition.y -
            HorizontalBook2.GetComponent<RectTransform>().sizeDelta.y,
             0f);

        HorizontalBook3.GetComponent<RectTransform>().localPosition = HorizontalBook2.GetComponent<RectTransform>().localPosition;
        HorizontalBook3.GetComponent<RectTransform>().localPosition = new Vector3(
            HorizontalBook3.GetComponent<RectTransform>().localPosition.x,
            HorizontalBook3.GetComponent<RectTransform>().localPosition.y +
            HorizontalBook2.GetComponent<RectTransform>().sizeDelta.y, 0f);
    }

    private void moveVerticalBookRight(GameObject book)
    {
        float distanceFromCentre = (childSafePuzzle.GetComponent<RectTransform>().sizeDelta.y - book.GetComponent<RectTransform>().sizeDelta.y)/2f;
        book.GetComponent<RectTransform>().localPosition = new Vector3 (book.GetComponent<RectTransform>().localPosition.x 
            + childSafePuzzle.GetComponent<RectTransform>().sizeDelta.x/2 
            - book.GetComponent<RectTransform>().sizeDelta.x 
            - book.GetComponent<RectTransform>().sizeDelta.x / 2 
            - distanceFromCentre,
            book.GetComponent<RectTransform>().localPosition.y,
            book.GetComponent<RectTransform>().localPosition.z);
    }
    private void moveVerticalBookLeft(GameObject verticalBook)
    {
        float distanceFromCentre = (childSafePuzzle.GetComponent<RectTransform>().sizeDelta.y - verticalBook.GetComponent<RectTransform>().sizeDelta.y) / 2f;
        verticalBook.GetComponent<RectTransform>().localPosition = new Vector3(verticalBook.GetComponent<RectTransform>().localPosition.x
            - childSafePuzzle.GetComponent<RectTransform>().sizeDelta.x / 2
            + verticalBook.GetComponent<RectTransform>().sizeDelta.x
            + verticalBook.GetComponent<RectTransform>().sizeDelta.x / 2
            + distanceFromCentre,
            verticalBook.GetComponent<RectTransform>().localPosition.y,
            verticalBook.GetComponent<RectTransform>().localPosition.z);

    }
    private void Update()
    {

    }
}
