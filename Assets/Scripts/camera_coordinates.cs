using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_coordinates : MonoBehaviour
{
    // Start is called before the first frame update

    Transform camara;
    void Start()
    {
        camara = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("position: " + camara.position);
        Debug.Log("rotation: " + camara.rotation);
    }
}
