using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMorseCode : MonoBehaviour
{
    private PasswordInput password;
    private MorseCodeTranslator MorseCodeTranslator;
    private GameObject MorseCodeTranslationImage;
    [SerializeField] private GameObject cam;
    private Vector3 camPos;
    private bool isFocused;

    public bool getIsFocused()
    {
        return isFocused;
    }
    private void Awake()
    {
        password = GameObject.Find("InputManager")?.GetComponent<PasswordInput>();
        MorseCodeTranslator = GameObject.Find("MorseCode")?.GetComponent<MorseCodeTranslator>();
        MorseCodeTranslationImage = GameObject.Find("IVMorseCodeTranslator");
        if (cam == null)
        {
            cam = GameObject.FindWithTag("MainCamera");
        }

    }
    private void Start()
    {
        
        if (MorseCodeTranslationImage.activeSelf)
        {
            MorseCodeTranslationImage.SetActive(false);
        }
    }
    public void getClickedRadio()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 1000f))
            {
                if (raycastHit.transform != null)
                {
                    CurrentClickedGameObject(raycastHit.transform.gameObject);

                }
            }
        }
        if (isFocused)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isFocused = false;
                cam.transform.position = camPos;
            }
        }
        else
        {
            camPos = cam.transform.position;


        }
    }


    public void CurrentClickedGameObject(GameObject gameObject)
    {
        
        if (gameObject.tag == "Radio" && !MorseCodeTranslator.getCoroutineIsRunning() && MorseCodeTranslationImage.activeInHierarchy && isFocused)
        {
            MorseCodeTranslator.PlayMorseCodeMessage(password.GetRandNum());
        }
        else if(gameObject.tag == "Radio" && MorseCodeTranslator.getCoroutineIsRunning())
        {
            
        }
        else if (gameObject.tag == "Radio")
        {
            isFocused = true;
            cam.transform.position = new Vector3(-1457, 41, 1788.28f);
        }


    }
}
