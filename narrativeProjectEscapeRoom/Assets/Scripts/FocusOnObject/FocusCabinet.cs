using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCabinet : MonoBehaviour
{
    private bool isFocused;
    GameObject SPuzzle;
    SafePuzzle safePuzzle;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject cabLeft, CabCentreLeft, CabCentreRight, CabRight;
    [SerializeField] private Vector3 cabLeftOriginPos, CabCentreLeftOriginPos, CabCentreRightOriginPos, CabRightOriginPos;
    [SerializeField] private Vector3 cabLeftOpenPos, CabCentreLeftOpenPos, CabCentreRightOpenPos, CabRightOpenPos;
    private Vector3 camPos;
    private bool cabinetLeftIsOpen, cabinetCentreLeftIsOpen, cabinetRightIsOpen, cabinetCentreRightIsOpen;
    private void Start()
    {
        cabinetCentreLeftIsOpen = false;
        cabinetCentreRightIsOpen = false;
        cabinetLeftIsOpen = false;
        cabinetRightIsOpen = false;
        if (cam == null)
        {
            cam = GameObject.FindWithTag("MainCamera");
        }
        SPuzzle = GameObject.Find("SafePuzzle");

        safePuzzle = GameObject.Find("SafePuzzleManager").GetComponent<SafePuzzle>();

        cabLeftOriginPos = cabLeft.transform.localPosition;
        CabCentreLeftOriginPos = CabCentreLeft.transform.localPosition;
        CabCentreRightOriginPos = CabCentreRight.transform.localPosition;
        CabRightOriginPos = CabRight.transform.localPosition;

    }
    public void getClickedCabinet()
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
                if (SPuzzle.activeSelf)
                {
                    SPuzzle.SetActive(false);
                }
                else
                {
                    isFocused = false;
                    cam.transform.position = camPos;
                }
            }
        }
        else
        {
            camPos = cam.transform.position;


        }
    }
    private void closeCabinet(GameObject cabinet)
    {

        cabinet.transform.eulerAngles = new Vector3(0, -90, 0);


    }
    private void openCabinet(GameObject cabinet, bool rotate180)
    {
        if (rotate180)
        {
            cabinet.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            cabinet.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    private bool checkOpenCabinet(bool CabinetIsOpen, GameObject cabinet, Vector3 originPos, Vector3 openPos, bool rotate180)
    {
        if (CabinetIsOpen)
        {
            closeCabinet(cabinet);
            cabinet.transform.localPosition = originPos;
            CabinetIsOpen = false;
        }
        else
        {
            openCabinet(cabinet, rotate180);
            cabinet.transform.localPosition = openPos;
            CabinetIsOpen = true;
        }
        return CabinetIsOpen;
    }
    public bool getIsFocused()
    {
        return isFocused;
    }
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.tag == "cabinet" || gameObject.tag == "BookSafe" && !isFocused)
        {
            cam.transform.position = new Vector3(-1551, 161, 2066);
            isFocused = true;

        }
        else if (gameObject.tag == "BookSafe" && isFocused && !safePuzzle.checkSafe())
        {
            SPuzzle.SetActive(true);

        }
        else if (gameObject.tag == "BookSafe" && isFocused && safePuzzle.checkSafe())
        {
            GameObject safeDoor = GameObject.Find("Safe1Door");
            safeDoor.transform.localPosition = new Vector3(-1.77f,0f,1.91f);
            safeDoor.transform.eulerAngles = new Vector3(90f,90f,180f);
        }
        else if (gameObject.name == "CabnietDoorLeft" && isFocused && SPuzzle.activeSelf == false)
        {
            cabinetLeftIsOpen = checkOpenCabinet(cabinetLeftIsOpen, cabLeft, cabLeftOriginPos, cabLeftOpenPos, false);
        }
        else if (gameObject.name == "CabinetDoorCentreLeft" && isFocused && SPuzzle.activeSelf == false)
        {
            cabinetCentreLeftIsOpen = checkOpenCabinet(cabinetCentreLeftIsOpen, CabCentreLeft, CabCentreLeftOriginPos, CabCentreLeftOpenPos, false);

        }
        else if (gameObject.name == "CabinetDoorCentreRight" && isFocused && SPuzzle.activeSelf == false)
        {
            cabinetCentreRightIsOpen = checkOpenCabinet(cabinetCentreRightIsOpen, CabCentreRight, CabCentreRightOriginPos, CabCentreRightOpenPos,false);

        }
        else if (gameObject.name == "CabinetDoorRight" && isFocused && SPuzzle.activeSelf == false)
        {
            cabinetRightIsOpen = checkOpenCabinet(cabinetRightIsOpen, CabRight, CabRightOriginPos, CabRightOpenPos,true);

        }




    }
}
