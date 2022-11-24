using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected : MonoBehaviour
{
    public bool is_selected = false;
    private Vector3 scale, positionChange;
    private Renderer cubeRenderer;

    private void Start()
    {
        cubeRenderer = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        if (is_selected == true)
        {
            Debug.Log("SELECTED");
            cubeRenderer.material.SetColor("_Color", Color.red);
        }
    }
}
