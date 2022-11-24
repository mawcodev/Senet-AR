/**********************************************
@name: ejemplo_diana
@description 
Script asignado al objeto Diana que realiza al animación de lenvantarse y tumbarse
@authors: Diana Hernández Soler
@date
27/11/2020
@license 
***********************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ejemplo_diana : MonoBehaviour
{

    public Animator diana_anim;
    AnimatorStateInfo diana_anim_info;
    GameObject particle_system_object;
    ParticleSystem particle_system;
    public Material diana_rota;

    void Start()
    {
        particle_system_object = GameObject.Find("DustRing_2");

        //diana_anim = gameObject.GetComponent<Animator>();
        //diana_anim = GameObject.Find("Diana").GetComponent<Animator>();
        particle_system = particle_system_object.GetComponent<ParticleSystem>();

        diana_anim_info = diana_anim.GetCurrentAnimatorStateInfo(0);

        if (diana_anim_info.IsName("diana_estado_inicial"))
        {
            diana_anim.SetTrigger("levantar_diana_trigger");
        }
    }

    void Update()
    {

        diana_anim_info = diana_anim.GetCurrentAnimatorStateInfo(0);
    }

    /**********************************************
    @description Corrutina para esperar a que acabe la animación para que empiece el sistema de particulas 
    @design AnimatorStateInfo -> waitForAnimationToEnd()
    @author
    Diana Hernández Soler
    @date
    27/11/2020
    ***********************************************/
    private IEnumerator waitForAnimationToEnd(AnimatorStateInfo diana_anim_info)
    {
        /* Fuente => https://answers.unity.com/questions/1208395/animator-wait-until-animation-finishes.html */
        yield return new WaitForSeconds(diana_anim_info.normalizedTime + diana_anim_info.length - 1);
        particle_system.Play();
    }

    /**********************************************
    @description se espera seconds segundos para cambiar la textura de la diana a la diana rota
    @design double seconds -> waitForPull()
    @author
    Diana Hernández Soler
    @date
    27/11/2020
    ***********************************************/
    private IEnumerator waitForPull(double seconds)
    {
        float s = Convert.ToSingle(seconds);
        yield return new WaitForSeconds(s);
        gameObject.GetComponent<MeshRenderer>().material = diana_rota;

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Ball")
        {
            //Animation is executed
            Debug.Log("Se detecto la bola");
            if (diana_anim_info.IsName("diana_levantada"))
            {
                // Espero para cambiar la textura de la diana a la diana rota
                StartCoroutine(waitForPull(0.8));
                // Tumbo la dinana
                diana_anim.SetTrigger("tumbar_diana_trigger");
                // Espero a que se termina la animación tumbar_diana para activar el sistema de particulas
                StartCoroutine(waitForAnimationToEnd(diana_anim_info));

            }

        }
    }
}
