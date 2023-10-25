using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCollectedObjectsManager : MonoBehaviour
{
    private GameObject paperWithMissingNumber;
    private GameObject PaperOfNumbers;
    private GameObject IVpaperWithMissingNumber;
    private GameObject IVPaperOfNumbers;
    private GameObject IVMorseCodeTranslator;
    private void Awake()
    {
        paperWithMissingNumber = GameObject.Find("PaperOfNumbersWithAnswer");
        PaperOfNumbers = GameObject.Find("PaperOfNumbers");
        IVpaperWithMissingNumber = GameObject.Find("IVPaperOfNumbersWithAnswer");
        IVPaperOfNumbers = GameObject.Find("IVPaperOfNumbers");
        IVMorseCodeTranslator = GameObject.Find("IVMorseCodeTranslator");

        

        

    }
    private void Start()
    {
        IVPaperOfNumbers.SetActive(false);
        IVpaperWithMissingNumber.SetActive(false);
        IVMorseCodeTranslator.SetActive(false);
        IVpaperWithMissingNumber.GetComponent<Button>().onClick.AddListener(delegate { EnablePaperWithMissingNumber(IVPaperOfNumbers); });
        IVPaperOfNumbers.GetComponent<Button>().onClick.AddListener(delegate { EnablePaperWithMissingNumber(IVPaperOfNumbers); });
    }
    private void EnablePaperWithMissingNumber(GameObject @object)
    {
        if (@object.activeSelf)
        {
            @object.SetActive(false);
        }
        else
        {
            @object.SetActive(true);
        }
    }
    private void Update()
    {
        
    }
}
