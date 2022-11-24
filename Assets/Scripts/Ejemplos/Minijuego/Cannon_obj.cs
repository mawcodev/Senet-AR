/**********************************************
@name: Cannon_obj
@description 
Script para cargar y lanzar bolas en el cañón
@authors: Matthew Conde Oltra
@date
24/12/2020
@license 
***********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_obj : MonoBehaviour
{
    // This is script to detect objects with raycast
    public RaycastController r;
    public float power = 10f;
    public Camera arCamera;

    // The variables of cannon
    public GameObject referenceBall; //reference cannon ball
    public GameObject prefabBall; // prefab cannon ball
    private Rigidbody rbCannonBall; // rigidbody cannon ball that is instantiate
    public GameObject Cannon; // game object cannon
    private GameObject cannonBall; // to create cannon ball
    private bool isBallThrown; // true or false

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBallThrown)
        {
            isBallThrown = false;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            if (!cannonBall)
            {
                //to create cannon ball
                ChargeCannonBall();
            }else
            {
                Destroy(cannonBall);
                ChargeCannonBall();
            }

        }else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

            if (!isBallThrown)
            {
                //to thrown cannon ball
                ThrowCannonBall();
            }

        }
    }
    /**********************************************
     @description
     Crea la bola en la posición y orientación ideales - su posición es de la bola de referencia y la rotación la de la 
     camara
     @design ChargeCannonBall()
     @author
     Matthew Conde Oltra
     @date
     25/11/2020
     ***********************************************/

    public void ChargeCannonBall()
    {
        
        //To create cannon ball object
        cannonBall = (GameObject)Instantiate(prefabBall);
        
        cannonBall.transform.SetParent(Cannon.transform, true);
        cannonBall.SetActive(false);
        rbCannonBall = cannonBall.GetComponent<Rigidbody>();
        rbCannonBall.useGravity = false;
        //Take position and scale the reference ball
        cannonBall.transform.position = referenceBall.transform.position;
        cannonBall.transform.localScale = referenceBall.transform.localScale;

        //Take rotation the arCamera
        cannonBall.transform.rotation = arCamera.transform.rotation;
        
        //Debug.Log("Message: -------->"+" Create cannon ball");
        //Call raycast and setting values
        r.activeRaycast();

    }

    /**********************************************
     @description
     Lanza la bola añadiendole una fuerza respecto al eje horizontal con la posición actual y la nueva posición
     @design ThrowCannonBall()
     @author
     Matthew Conde Oltra
     @date
     25/12/2020
     ***********************************************/

    public void ThrowCannonBall()
    {

        cannonBall.SetActive(true);
        // And cannon ball is throw
        // Add force 
        //Debug.Log("Message: -------->"+"information destiny "+r.GetDestiny());

        rbCannonBall.useGravity = true;
        //rbCannonBall.AddForce(cannonBall.transform.forward*power, ForceMode.Impulse); //Functional

        //The AddForceAtPosition is better than AddForce
        rbCannonBall.AddForceAtPosition(cannonBall.transform.forward * power, r.GetDestiny(), ForceMode.Impulse); //Functional
        isBallThrown = true;
        //Debug.Log("Message: -------->"+" Throw cannon ball");

    }
}
