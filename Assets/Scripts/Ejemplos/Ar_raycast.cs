using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Ar_raycast : MonoBehaviour
{

    public GameObject escenario_prefab;
    public ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> arRaycastHits = new List<ARRaycastHit>();

    void Start()
    {

    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {
                    if (arRaycastManager.Raycast(touch.position, arRaycastHits))
                    {
                        var pose = arRaycastHits[0].pose;
                        SpawnGameZone(pose.position);
                        return;
                    }
                }
            }
        }
    }

    private void SpawnGameZone(Vector3 position)
    {
        Instantiate(escenario_prefab, position, Quaternion.identity);
    }
}
