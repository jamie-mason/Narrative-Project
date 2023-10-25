using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusPToE : MonoBehaviour
{
    private bool isFocused;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject PToE;
    [SerializeField] private GameObject Oxygen;

    private Vector3 camPos;

    private GameObject Reference2;
    private void Start()
    {

        if (cam == null)
        {
            cam = GameObject.FindWithTag("MainCamera");
        }
        Reference2 = GameObject.Find("2Reference");
        PToE = GameObject.Find("PToE");
        Oxygen = GameObject.Find("Oxygen");
        Oxygen.GetComponent<BoxCollider>().enabled = false;
        Reference2.SetActive(false);


    }
    private void ShowBlue2()
    {
        Reference2.SetActive(true);
    }
    public void getClickedPToE()
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
                PToE.GetComponent<BoxCollider>().enabled = true;
                isFocused = false;
                cam.transform.position = camPos;
            }
        }
        else
        {
            camPos = cam.transform.position;
            PToE.GetComponent<BoxCollider>().enabled = true;


        }
    }
    public bool getIsFocused()
    {
        return isFocused;
    }
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.tag == "PToE" && !isFocused)
        {
            cam.transform.position = new Vector3(-1279, 150, 1950);
            
            isFocused = true;
            PToE.GetComponent<BoxCollider>().enabled = false;
            Oxygen.GetComponent<BoxCollider>().enabled = true;


        }
        else if (isFocused && gameObject.name == "Oxygen")
        {
            Reference2.SetActive(true);
            PToE.GetComponent<BoxCollider>().enabled = true;
            Oxygen.GetComponent<BoxCollider>().enabled = false;


        }


    }
}
