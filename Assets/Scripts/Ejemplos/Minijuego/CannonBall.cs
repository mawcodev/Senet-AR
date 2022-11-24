/**********************************************
@name: CannonBall
@description 
Script para determinar si la bola ha tenido alguna colisión con algún objeto, de forma que podamos activar el FX de la piedra romperse.
@authors: Matthew Conde Oltra
@date
24/12/2020
@license 
***********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private GameObject canvasMinijuego;
    public GameObject particle_system_object;
    private ParticleSystem[] particle_system;
    private GameObject countdown;

    // Start is called before the first frame update
    void Start()
    {

        particle_system_object = GameObject.Find("Bola romperse");
        canvasMinijuego = GameObject.Find("Canvas_minijuego");
        particle_system = particle_system_object.GetComponentsInChildren<ParticleSystem>();
        countdown = GameObject.Find("timer");


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        particle_system_object.transform.position = gameObject.transform.position;

        if (other.tag == "Diana")
        {
            //adding ruby
            canvasMinijuego.GetComponent<ruby_score>().Score();
            //Destruction and action animation!!

            particle_system[0].Play();
            particle_system[1].Play();

            Debug.Log("Message: -------->" + "Se ha detectado la Diana");
            Destroy(gameObject);
        }
        else if(other.tag == "Untagged")
        {
            Debug.Log("Message: -------->" + "Se ha detectado un objeto");

        }else if (other.tag == "Bomba")
        {
            // Loss 10 seconds
            countdown.GetComponent<countdown>().lossTime();

            //Destruction only
            particle_system[0].Play();
            particle_system[1].Play();

            Debug.Log("Message: -------->" + "Se ha detectado una bomba");
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 2f);
        }
    }
}
