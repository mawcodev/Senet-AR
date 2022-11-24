/**********************************************
@name: start_script
@description 
Script asignado al texto START para que empieza la animación de desaparecer y cambie de escena
@authors: Diana Hernández Soler
@date
8/12/2020
@license 
***********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_script : MonoBehaviour
{
    private Animator logo_anim;
    public GameObject logo;
    private AnimatorStateInfo logo_anim_info;

    private void Start()
    {
        logo_anim = logo.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // Recogemos el estado actual de la animación
        logo_anim_info = logo_anim.GetCurrentAnimatorStateInfo(0);
    }
    void OnMouseDown()
    {

        startGame();
    }

    private void startGame()
    {

        if (logo_anim_info.IsName("logotipo_animacion"))
        {
            logo_anim.SetTrigger("logotipo_start_trigger");
            // TODO: Cuando termine la animación pasar a la siguiente escena
            StartCoroutine(waitForAnimationToEnd(logo_anim_info));
           
        }
    }

   /**********************************************
   @description Corrutina para esperar a que acabe la animación para que pase a la escena Minijuego
   @design AnimatorStateInfo -> waitForAnimationToEnd()
   @author
   Diana Hernández Soler
   @date
   27/11/2020
   ***********************************************/
    private IEnumerator waitForAnimationToEnd(AnimatorStateInfo logo_anim_info)
    {
        /* Fuente => https://answers.unity.com/questions/1208395/animator-wait-until-animation-finishes.html */
        yield return new WaitForSeconds(logo_anim_info.normalizedTime - 1);
        // Cambio de escena
        // StartCoroutine(LoadYourAsyncScene());
        SceneManager.LoadScene("Minijuego");
    }

    /**********************************************
    @description Corrutina para cargar asíncronamente la escena siguiente
    @design LoadYourAsyncScene()
    @Fuente https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html
    @author
    Diana Hernández Soler
    @date
    10/12/2020
    ***********************************************/
    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
     
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Minijuego");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
