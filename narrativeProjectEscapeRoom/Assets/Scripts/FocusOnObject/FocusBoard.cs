using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusBoard : MonoBehaviour
{
    private bool isFocused;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject UnscrabledWord;
    private Vector3 camPos;
    private void Start()
    {
        if (UnscrabledWord != null)
        {
            UnscrabledWord.SetActive(false);
        }
    }
    public void getClickedBoard()
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
                cam.transform.position = camPos;
                isFocused = false;
                UnscrabledWord.SetActive(false);
            }
        }
        else
        {
            camPos = cam.transform.position;
        }
    }
    
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.name == "Board" && !isFocused)
        {
            isFocused = true;
            
            UnscrabledWord.SetActive(true);
        }
        
    }
    public bool getIsFocused()
    {
        return isFocused;
    }

}
