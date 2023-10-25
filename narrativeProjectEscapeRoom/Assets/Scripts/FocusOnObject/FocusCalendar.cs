using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FocusCalendar : MonoBehaviour
{
    private bool isFocused;
    [SerializeField] private GameObject cam;
    private Vector3 camPos;
    [SerializeField] private GameObject Calendar;
    [SerializeField] private GameObject Eighth;
    [SerializeField]private GameObject CalendarO;
    private void Start()
    {

        if (cam == null)
        {
            cam = GameObject.FindWithTag("MainCamera");
        }
        if (CalendarO == null)
        {
            CalendarO = GameObject.Find("OParent");
        }
        Calendar = GameObject.FindWithTag("Calendar");
        Eighth = GameObject.Find("Eighth");


        Eighth.GetComponent<BoxCollider>().enabled = false;
        CalendarO.gameObject.SetActive(false);
        


    }
   
    public void getClickedCalendar()
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
                Calendar.GetComponent<BoxCollider>().enabled = true;
            }
        }
        else
        {
            camPos = cam.transform.position;
            Calendar.GetComponent<BoxCollider>().enabled = true;


        }
    }
    public bool getIsFocused()
    {
        return isFocused;
    }
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.tag == "Calendar" && !isFocused)
        {
            cam.transform.position = new Vector3(-1468, 82, 2353);
            isFocused = true;
            Calendar.GetComponent<BoxCollider>().enabled = false;
            Eighth.GetComponent<BoxCollider>().enabled = true;


        }
        else if(gameObject.name == "Eighth" && isFocused)
        {
            Eighth.GetComponent<BoxCollider>().enabled = false;
            CalendarO.gameObject.SetActive(true);

        }


    }
}
