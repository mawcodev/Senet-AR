using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class auto_game_creator : MonoBehaviour
{
    public ARPlaneManager plane_manager;
    public GameObject escenario_prefab;
    public Camera arCamara;
    private GameObject escenario_puesto;
    public bool escenario_cargado = false;

    void Update()
    {
        foreach (var plane in plane_manager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }

    void Awake()
    {
        plane_manager = GetComponent<ARPlaneManager>();
        plane_manager.planesChanged += PlaneChanged;
    }

    private void PlaneChanged(ARPlanesChangedEventArgs plane)
    {
        if (plane.added != null && escenario_puesto == null)
        {
            ARPlane arPlane = plane.added[0];
            escenario_puesto = Instantiate(escenario_prefab, new Vector3(arPlane.transform.position.x, arPlane.transform.position.y-6, arPlane.transform.position.z+6), Quaternion.identity);
            escenario_cargado = true;
        }
    }
}
