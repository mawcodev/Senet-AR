/**********************************************
@name: ejemplo_animaciones_libro
@description: codigo de ejemplo para usar triggers del componente animator
@author: Manuel Mouzo
@date: 21/11/2020
@license GPLv3
***********************************************/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ejemplo_animaciones_libro : MonoBehaviour
{
    Animator libro_anim;
    AnimatorStateInfo libro_anim_info;
    GameObject particle_system_object;
    ParticleSystem particle_system;

    void Start()
    {
        libro_anim = gameObject.GetComponent<Animator>();

        particle_system_object = GameObject.Find("Efecto de desaparecer");
        particle_system = particle_system_object.GetComponent<ParticleSystem>();
    }

    /**********************************************
    @description: en este metodo se ve un funcionamiento básico de como usar las animaciones del libro
    @design N/A
    @author: Manuel Mouzo
    @date: 21/11/2020
    ***********************************************/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            particle_system.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            libro_anim_info = libro_anim.GetCurrentAnimatorStateInfo(0);

            Debug.Log(libro_anim_info.IsName("idle"));


            if (libro_anim_info.IsName("idle"))
            {
                libro_anim.SetTrigger("transform_to_camera_trigger");
            }

            if (libro_anim_info.IsName("idle_open"))
            {
                Debug.Log("Estoy en idle");
                libro_anim.SetTrigger("idle_to_pasar_trigger");
            }

            if (libro_anim_info.IsName("pasar_hoja_animation"))
            {
                libro_anim.SetTrigger("pasar_to_idle_trigger");
            }
        }
    }
}
