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

public class bomba_script : MonoBehaviour
{

    Animator diana_anim;
    AnimatorStateInfo diana_anim_info;
    public GameObject diana;
    public ParticleSystem CorePS;
    public ParticleSystem DustRingPS;
    public ParticleSystem ShardsPS;
    public Material diana_rota;

    void Start()
    {

        diana_anim = gameObject.GetComponent<Animator>();

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

   
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Rock")
        {
            //Animation is executed
            Debug.Log("Se detecto la piedra");
            if (diana_anim_info.IsName("diana_levantada"))
            {
                // Tumbo la dinana
                diana_anim.SetTrigger("tumbar_diana_trigger");
                // Cambiar la textura de la diana a la diana rota
                diana.GetComponent<MeshRenderer>().material = diana_rota;
                // Activo los sistemas de particulas de la explosión
                CorePS.Play();
                DustRingPS.Play();
                ShardsPS.Play();

            }
        }
    }
}