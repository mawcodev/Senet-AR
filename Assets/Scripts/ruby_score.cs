using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ruby_score : MonoBehaviour
{
    public Sprite colored_ruby;
    public List<GameObject> ruby_list;
    public int score = 0;
    public int RUBYSTOWIN = 3;


    private Animator canvas_anim;
    private AnimatorStateInfo canvas_info;



    void Start()
    {
        canvas_anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        canvas_anim.SetInteger("ruby_condition", 3);
        canvas_info = canvas_anim.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Has llamado a Score");
            Score();
        }
    }

    /// <summary>
    /// Al llamar esta función se añade consigue una gema de la UI
    /// </summary>
    public void Score() {
        if (score<=2)
        {
            canvas_anim.SetInteger("ruby_condition" ,score);
            ruby_list[score].GetComponent<Image>().sprite = colored_ruby;
            score++;
        }
    }
}
