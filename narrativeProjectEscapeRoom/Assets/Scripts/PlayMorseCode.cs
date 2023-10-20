using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMorseCode : MonoBehaviour
{
    private PasswordInput password;
    private MorseCodeTranslator MorseCodeTranslator;
    private GameObject MorseCodeTranslationImage;

    private void Start()
    {
        password = GameObject.Find("InputManager")?.GetComponent<PasswordInput>();
        MorseCodeTranslator = GameObject.Find("MorseCode")?.GetComponent<MorseCodeTranslator>();
        MorseCodeTranslationImage = GameObject.Find("MorseCodeTranslator");
        if (MorseCodeTranslationImage.activeInHierarchy)
        {
            MorseCodeTranslationImage.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
    }
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.name == "Radio" && !MorseCodeTranslator.getCoroutineIsRunning() && MorseCodeTranslationImage.activeInHierarchy)
        {
            MorseCodeTranslator.PlayMorseCodeMessage(password.GetRandNum());
        }
        else
        {

        }
    }
}
