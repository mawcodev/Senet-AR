using UnityEngine;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour
{
    
    public auto_game_creator scriptEscenario;

    public GameObject game_canvas;
    public GameObject surface_canvas;

    public GameObject cuenta_atras;
    private Animator cuenta_atras_anim;
    private AnimatorStateInfo cuenta_atras_anim_info;
    public bool clock_start;
    private bool slingshot_done;
    private bool countdown_done;
    public int RUBYSTOWIN = 3;



    void Start()
    {
        cuenta_atras_anim = cuenta_atras.GetComponent<Animator>();
        slingshot_done = false;

    }

    void Update()
    {

        cuenta_atras_anim_info = cuenta_atras_anim.GetCurrentAnimatorStateInfo(0);

        if (scriptEscenario.escenario_cargado == true)
        {
            surface_canvas.SetActive(false);
            game_canvas.SetActive(true);
            cuenta_atras_anim.SetTrigger("start_animation");

            if (cuenta_atras_anim_info.IsName("end_state"))
            {
                clock_start = true;
            }
        }
    }

    public void tryAgain()
    {
        SceneManager.LoadScene("Minijuego");
    }

    public void CloseApp()
    {
        Application.Quit();
        // SceneManager.LoadScene("Ejemplo-Logotipo");
    }

}
