using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveStations : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private bool[] isLeft, isRight, isFront, isBack;
    [SerializeField] private Vector3[] camPositions;
    private FocusPencup focusPencup;
    private FocusBoard focusBoard;
    private FocusOnComputer focusOnComputer;
    private FocusCabinet focusCabinet;
    private PlayMorseCode playMorseCode;
    private FocusClock focusClock;
    private FocusCalendar focusCalendar;
    private FocusPinpadSafe focusPinpadSafe;
    private FocusPToE focusPToE;
    private FocusDoor focusDoor;



    [SerializeField] private Vector3[] camRotations = new Vector3[10];
    [SerializeField] private Vector3 camStart = new Vector3 (-1157, 74.1f, 1197f);
    private GameObject MainCam;
    private bool allListsHaveNotwoSameTrues = false;
    private bool Onstart = true;
    int activeCam;

    private void Awake()
    {
        Onstart = true;
        camRotations = new Vector3[10];
        camStart = new Vector3(-1157, 74.1f, 1197f);
        if (MainCam == null)
        {
            MainCam = GameObject.FindWithTag("MainCamera");
        }
        focusPencup = GameObject.Find("FocusPencup").GetComponent<FocusPencup>();
        focusBoard = GameObject.Find("FocusOnUnscrablePuzzle").GetComponent<FocusBoard>();
        focusOnComputer = GameObject.Find("FocusComputer").GetComponent<FocusOnComputer>();
        focusCabinet = GameObject.Find("FocusCabinet").GetComponent<FocusCabinet>();
        playMorseCode = GameObject.Find("MorseCode").GetComponent<PlayMorseCode>();
        focusClock = GameObject.Find("FocusClock").GetComponent<FocusClock>();
        focusCalendar = GameObject.Find("FocusCalendar").GetComponent<FocusCalendar>();
        focusPToE = GameObject.Find("FocusPToE").GetComponent<FocusPToE>();
        focusDoor = GameObject.Find("FocusDoor").GetComponent<FocusDoor>();
        focusPinpadSafe = GameObject.Find("FocusPinpadSafe").GetComponent<FocusPinpadSafe>();

        MainCam.transform.position = camStart;
        MainCam.transform.eulerAngles = Vector3.zero;
    }
    private void Start()
    {

        checkBoolListRotationValues();
        if (!allListsHaveNotwoSameTrues)
        {
            for (int i = 0; i < isFront.Length; i++)
            {
                if (isFront[i])
                {
                    camRotations[i] = new Vector3(0f,180f, 0f);
                }
                else if (isLeft[i]){
                    camRotations[i] = new Vector3(0f, 90f, 0f);
                }
                else if (isRight[i])
                {
                    camRotations[i] = new Vector3(0f, -90f, 0f);
                }
                else if (isBack[i])
                {
                    camRotations[i] = new Vector3(0f, 0f, 0f);
                }
                else
                {
                    Debug.LogError("Set direction bool");
                }
            }
        }


        
    }

    private void checkBoolListRotationValues()
    {
        if (isFront.Length == isBack.Length && isFront.Length == isRight.Length && isFront.Length == isLeft.Length)
        {
            for (int i = 0; i < isFront.Length; i++)
            {
                if (isFront[i] == isLeft[i] && isFront[i])
                {
                    allListsHaveNotwoSameTrues = true;
                    Debug.Log("cannot be both front and left");
                }
                else if (isFront[i] == isRight[i] && isFront[i])
                {
                    allListsHaveNotwoSameTrues = true;

                    Debug.Log("cannot be both front and right");
                }
                else if (isFront[i] == isBack[i] && isFront[i])
                {
                    allListsHaveNotwoSameTrues = true;

                    Debug.Log("cannot be both front and back");
                }
                else if (isBack[i] == isLeft[i] && isBack[i])
                {
                    allListsHaveNotwoSameTrues = true;

                    Debug.Log("cannot be both back and left");
                }
                else if (isBack[i] == isRight[i] && isBack[i])
                {
                    allListsHaveNotwoSameTrues = true;

                    Debug.Log("cannot be both back and right");
                }
                else if (isRight[i] == isLeft[i] && isRight[i])
                {
                    allListsHaveNotwoSameTrues = true;

                    Debug.Log("cannot be left and right");
                }
                else
                {
                    allListsHaveNotwoSameTrues = false;
                }

            }
        }
        else
        {

            Debug.LogError("bool lists are not the same length.");


        }

    }

    private void CycleLeft()
    {
        if (Onstart)
        {
            MainCam.transform.eulerAngles = camRotations[camRotations.Length -1];
            MainCam.transform.position = camPositions[camRotations.Length - 1];
            activeCam = camRotations.Length - 1;
            Onstart = false;
        }
        else
        {
            for(int i = 0; i < camRotations.Length; i++)
            {
                if(i == 0 && activeCam == 0)
                {
                    MainCam.transform.eulerAngles = camRotations[camRotations.Length - 1];
                    MainCam.transform.position = camPositions[camRotations.Length - 1];
                    activeCam = camRotations.Length - 1;
                    break;
                }
                else
                {
                    activeCam = activeCam - 1;
                    MainCam.transform.eulerAngles = camRotations[activeCam];
                    MainCam.transform.position = camPositions[activeCam];
                    break;
                }
            }
        }
        


    }
    private void cycleRight()
    {
        if (Onstart)
        {
            MainCam.transform.eulerAngles = camRotations[0];
            MainCam.transform.position = camPositions[0];
            Onstart = false;
            activeCam = 0;
        }
        else
        {
            for (int i = 0; i < camRotations.Length; i++)
            {
                if (i == 0 && activeCam == camRotations.Length-1)
                {
                    MainCam.transform.eulerAngles = camRotations[0];
                    MainCam.transform.position = camPositions[0];
                    activeCam = 0;
                    break;
                }
                else
                {
                    activeCam = activeCam + 1;
                    MainCam.transform.eulerAngles = camRotations[activeCam];
                    MainCam.transform.position = camPositions[activeCam];
                    break;
                }
            }
        }

        if (camRotations.Length == camPositions.Length && camPositions.Length == objects.Length)
        {
           
        }
        else
        {
            //Debug.LogError("lists are not the same length.");
        }
    }

    private void Update()
    {
        focusPencup.getClickedPencup();
        focusBoard.getClickedBoard();
        focusOnComputer.getClickedComputer();
        playMorseCode.getClickedRadio();
        focusCabinet.getClickedCabinet();
        focusClock.getClickedClock();
        focusCalendar.getClickedCalendar();
        focusPToE.getClickedPToE();
        focusPinpadSafe.getClickedPinpadSafe();
        focusDoor.getClickedDoor();

        if (!focusPencup.getIsFocused() && !focusBoard.getIsFocused() && !focusOnComputer.getIsFocused() &&
            !playMorseCode.getIsFocused() && !focusCabinet.getIsFocused() && !focusClock.getIsFocused()
            && !focusCalendar.getIsFocused() && !focusPToE.getIsFocused() && !focusPinpadSafe.getIsFocused() && !focusDoor.getIsFocused())
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S))
            {
                CycleLeft();
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
            {
                cycleRight();
            }
        }

    }
}
