using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPinpadSafe : MonoBehaviour
{
    private bool isFocused;
    [SerializeField] private GameObject cam;
    private Vector3 camPos;
    private void Start()
    {

        if (cam == null)
        {
            cam = GameObject.FindWithTag("MainCamera");
        }


    }
    public void getClickedPinpadSafe()
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
    public bool getIsFocused()
    {
        return isFocused;
    }
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.tag == "PinpadSafe" && !isFocused)
        {
            cam.transform.position = new Vector3(-1168.54f, -213, 2329);
            isFocused = true;

        }


    }
}
