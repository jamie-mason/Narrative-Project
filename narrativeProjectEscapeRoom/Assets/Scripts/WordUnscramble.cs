using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WordUnscramble : MonoBehaviour
{
    [SerializeField] private TMP_InputField UnscrambledWordInput;
    [SerializeField] private TextMeshProUGUI UnscrambledWordInputText;

    private string word;
    private void Awake()
    {
        if (UnscrambledWordInput == null)
        {
            UnscrambledWordInput = GameObject.Find("computerPassword")?.GetComponent<TMP_InputField>();
        }
        if (UnscrambledWordInputText == null)
        {
            UnscrambledWordInputText = GameObject.Find("Text")?.GetComponent<TextMeshProUGUI>();
            UnscrambledWordInputText.text = "";
        }
        word = "november";
        
    }
    public bool checkWord()
    {
        if (word == UnscrambledWordInput.text)
        {
            UnscrambledWordInput.interactable = false;
            return true;
        }
        else
        {
            UnscrambledWordInput.interactable = true;
            return false;
        }
    }
    public string getWord()
    {
        return word;
    }
    private void Update()
    {
        checkWord();
    }

}
