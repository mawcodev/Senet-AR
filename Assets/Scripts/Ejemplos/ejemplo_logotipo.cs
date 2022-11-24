/**********************************************
@name: ejemplo_logotipo
@description 
Script asignado al objeto logotipo que genera la animacion
@authors: Diana Hernández Soler
@date
27/11/2020
@license 
***********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ejemplo_logotipo : MonoBehaviour
{
    private Animator logo_anim;
    private AnimatorStateInfo logo_anim_info;
    public GameObject startButton;
    void Start()
    {
        logo_anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        logo_anim_info = logo_anim.GetCurrentAnimatorStateInfo(0);

            if (logo_anim_info.IsName("logo_estado_inicial"))
            {
                logo_anim.SetTrigger("logotipo_animacion_trigger");
            }
        
    }
}
