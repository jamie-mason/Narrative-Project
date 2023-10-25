using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class RandomNumbersOnPaper : MonoBehaviour
{

    private GameObject papersCombined;
    private GameObject paperWithMissingNumber;
    private GameObject PaperOfNumbers;
    private float missingNumber = 14;

    float getMissingNumber()
    {
        return missingNumber;
    }

    private void Start()
    {
        papersCombined = GameObject.Find("PapersCombined");
        paperWithMissingNumber = GameObject.Find("PaperOfNumbersWithAnswer");
        PaperOfNumbers = GameObject.Find("PaperOfNumbers");

        papersCombined.SetActive(false);
        paperWithMissingNumber.SetActive(false);
        PaperOfNumbers.SetActive(false);
        


    }
    private void Update()
    {
        if(paperWithMissingNumber.activeSelf && PaperOfNumbers.activeSelf)
        {
            papersCombined.SetActive(true);
            paperWithMissingNumber.SetActive(false);
            PaperOfNumbers.SetActive(false);
        }
    }

}
