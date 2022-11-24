using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ficha_animation_script : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        AnimatorStateInfo anim_info = anim.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("space");

            if (anim_info.IsName("idle"))
            {
                Debug.Log("aparece");

                anim.SetTrigger("appear_trigger");
            }

            if (anim_info.IsName("girar_360"))
            {
                Debug.Log("desaparece");

                anim.SetTrigger("disappear_trigger");
            }
        }
        

    }
}

