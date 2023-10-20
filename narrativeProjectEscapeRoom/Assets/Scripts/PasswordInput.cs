using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswordInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TextMeshProUGUI passwordText;

    private string randNum;
    private bool hasPrinted = false;
    private void Awake()
    {
        if(password == null)
        {
            password = GameObject.Find("computerPassword")?.GetComponent<TMP_InputField>();
        }
        if(passwordText == null)
        {
            passwordText = GameObject.Find("Text")?.GetComponent<TextMeshProUGUI>();
            passwordText.text = "";
        }
        GenerateRandomNo();
    }
   
    public bool correctPasswordEntered()
    {
        if(passwordText.text == randNum)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void GenerateRandomNo()
    {
        uint rand = (uint) Mathf.Abs(Random.Range(0000,9999));
        randNum = rand.ToString("D4");
         
    }
    private void Update()
    {
        password.characterLimit = 4;

        if (!hasPrinted)
        {
            Debug.Log(randNum);
            hasPrinted = true;
        }

    }
    public string GetRandNum()
    {
        return randNum;
    }
}
