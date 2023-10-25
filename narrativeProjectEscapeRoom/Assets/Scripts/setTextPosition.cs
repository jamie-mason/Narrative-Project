using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class setTextPosition : MonoBehaviour
{
    GameObject paper;
    GameObject message;
    void Start()
    {
        paper = GameObject.Find("paper");
        message = GameObject.Find("Message");
    }

    void Update()
    {
        message.GetComponent<TextMeshPro>().margin = new Vector4 (-paper.GetComponent<MeshFilter>().mesh.bounds.extents.x, paper.GetComponent<MeshFilter>().mesh.bounds.extents.z, paper.GetComponent<MeshFilter>().mesh.bounds.extents.x, -paper.GetComponent<MeshFilter>().mesh.bounds.extents.z);
    }
}
