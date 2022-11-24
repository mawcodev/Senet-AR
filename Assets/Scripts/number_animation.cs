using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class number_animation : MonoBehaviour
{
    Animator number_anim;
    AnimatorStateInfo number_anim_info;

    // Start is called before the first frame update
    void Start()
    {
        number_anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        number_anim_info = number_anim.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKeyDown(KeyCode.Space)) {
        
        }
    }
}
