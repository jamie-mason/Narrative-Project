using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPencup : MonoBehaviour
{
    private bool isFocused;
    [SerializeField] private GameObject cam;
    private Vector3 camPos;
    [SerializeField] private GameObject[] pens;
    [SerializeField] private Vector3[] penPos;
    private void Start()
    {
        Vector3[] penPs = new Vector3[pens.Length];
        if (cam == null)
        {
            cam = GameObject.FindWithTag("MainCamera");
        }
        
        for(int i = 0; i < pens.Length; i++)
        {
            penPs[i] = pens[i].transform.position;
        }
        penPos = penPs;
    }
    public void getClickedPencup()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 1000f))
            {
                if (raycastHit.transform != null)
                {
                    cam.transform.position = camPos;
                    CurrentClickedGameObject(raycastHit.transform.gameObject);

                }
            }
        }
        if (isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cam.transform.position = camPos;
                isFocused = false;

            }
        }
        else
        {
            camPos = cam.transform.position;

            for (int i = 0; i < pens.Length; i++)
            {
                pens[i].transform.position = penPos[i];
            }

        }
    }
    public bool getIsFocused()
    {
        return isFocused;
    }
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.name == "PenCup" && !isFocused)
        {
            isFocused = true;
            cam.transform.position = new Vector3(-1880, cam.transform.position.y, cam.transform.position.z);
           
        }
        else if (gameObject.name == "PenCup" && isFocused)
        {
            pens[0].transform.localPosition = new Vector3(-4.763501f, -0.2747f, 3.9362f);//green
            pens[1].transform.localPosition = new Vector3(-4.763501f, -0.2747f, 3.9463f);//yellow
            pens[2].transform.localPosition = new Vector3(-4.763501f, -0.2747f, 3.9499f);//blue
            pens[3].transform.localPosition = new Vector3(-4.763501f, -0.2747f, 3.9797f);//red
            pens[4].transform.localPosition = new Vector3(-4.763501f, -0.2747f, 3.985642f);//green
            pens[5].transform.localPosition = new Vector3(-4.763501f, -0.2747f, 4.012004f);//red
            pens[6].transform.localPosition = new Vector3(-4.763501f, -0.2747f, 4.013707f);//green
            pens[7].transform.localPosition = new Vector3(-4.763501f, -0.2747f, 4.028283f);//green
            pens[8].transform.localPosition = new Vector3(-4.7485f, -0.2747f, 4.0472f); //yellow
            pens[9].transform.localPosition = new Vector3(-4.763499f, -0.2747f, 4.098f);//blue
            pens[10].transform.localPosition = new Vector3(-4.763501f, -0.2747f, 4.0967f);//red
            pens[11].transform.localPosition = new Vector3(-4.763501f, -0.2747f, 4.068f);//green
            pens[12].transform.localPosition = new Vector3(-4.763501f, -0.2747f, 4.028283f);//green


            
        }
       
    }

}
