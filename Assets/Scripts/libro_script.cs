using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

/**********************************************
@name: libro_script
@description 
 Script asignado al libro para el control de sus animaciones
@authors: Manuel Mouzo, Diana Hernandez

@date
 17/11/2020
@license 
***********************************************/

public class libro_script : MonoBehaviour
{
    private Renderer m_Renderer;
    public GameObject paginaMenu;
    public GameObject otraPagina;
    public Animator libro_anim;
    private AnimatorStateInfo libro_anim_info;
    public GameObject particle_system_object;
    public ParticleSystem particle_system;
    public GameObject visagra;
    public GameObject Instrucciones;
    public GameObject Ajustes;
    public GameObject Fichas;
    public GameObject cono;
    public GameObject diabolo;
    private Animator cono_anim;
    private Animator diabolo_anim;
    private AnimatorStateInfo cono_anim_info;
    private AnimatorStateInfo diabolo_anim_info;


    void Start()
    {
        libro_anim = gameObject.GetComponent<Animator>();
        Instrucciones.SetActive(false);
        Ajustes.SetActive(false);
        Fichas.SetActive(false);

        //cono_anim = cono.GetComponent<Animator>();
        diabolo_anim = diabolo.GetComponent<Animator>();

    }

    void Update()
    {
        libro_anim_info = libro_anim.GetCurrentAnimatorStateInfo(0);
        //cono_anim_info = cono_anim.GetCurrentAnimatorStateInfo(0);
    }
    /**********************************************
     @description
     Activa la animación del libro, abrimos el menú y lo cerramos, dependiendo de como esté
     @design abrirLibro()
     @author
     Matthew Conde Oltra
     @date
     22/11/2020
     ***********************************************/
    public void actionMenu()
    {
        //Debug.Log(libro_anim_info.IsName("idle"));
        //Debug.Log(libro_anim.);
        if (libro_anim_info.IsName("idle"))
        {
            visagra.SetActive(true);
            cono.SetActive(true);
            diabolo.SetActive(true);
            libro_anim.SetTrigger("transform_to_camera_trigger");
        }else
        {
            particle_system.Play();
            visagra.SetActive(false);
            cono.SetActive(false);
            diabolo.SetActive(false);
            libro_anim.SetTrigger("idle_open_to_idle");
        }
    }

    /**********************************************
     @description
     Inicia la animación para passar la página del libro
     @design Animator -> pasarPagina()
     @author
     
     @date
     20/11/2020
    ***********************************************/
    public void pasarPagina(Animator anim) {
        
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

    /**********************************************
     @description
     Activa animación y visualiza las Instrucciones 
     @design Anmator -> irPaginaInstrucciones()
     @author
     Matthew Conde
     @date
     22/11/2020
    ***********************************************/
    public void irPaginaInstrucciones(Animator anim)
    {
        pasarPagina(anim);
        Instrucciones.SetActive(true);
    }

    /**********************************************
     @description
     Activa animación y visualiza las Ajustes
     @design Anmator -> irPaginaAjustes()
     @author
     Matthew Conde
     @date
     22/11/2020
    ***********************************************/
    public void irPaginaAjustes(Animator anim)
    {

        pasarPagina(anim);
        Ajustes.SetActive(true);
    }

    /**********************************************
     @description
     Activa animación y visualiza las Fichas 
     @design Anmator -> irPaginaFichas()
     @author
     Matthew Conde
     @date
     22/11/2020
    ***********************************************/
    public void irPaginaFichas(Animator anim)
    {

        pasarPagina(anim);
        Fichas.SetActive(true);


        if (cono_anim_info.IsName("idle"))
        {
            Debug.Log("APPEAR");
            diabolo_anim.SetTrigger("appear_trigger");
            cono_anim.SetTrigger("appear_trigger");
        }

    }
    /**********************************************
     @description
     Inicia la animación para passar la página del libro al contrario y desactiva todos los canvas de la HOJA 4
     @design  volverAmenu()
     @author
     Diana Hernández, Matthew Conde
     @date
     22/11/2020
    ***********************************************/
    public void volverAmenu()
    {
        if (libro_anim_info.IsName("pasar_hoja_animation"))
        {
            Debug.Log("Estoy en idle");
            libro_anim.SetTrigger("pasar_to_idle_trigger");
        }

        Instrucciones.SetActive(false);
        Ajustes.SetActive(false);
        Fichas.SetActive(false);

        if (cono_anim_info.IsName("girar_360"))
        {
            Debug.Log("DISAPPEAR");
            cono_anim.SetTrigger("disappear_trigger");
            diabolo_anim.SetTrigger("disappear_trigger");
        }

    }


    /**********************************************
      @description
      Inicio de la coroutina, observa la información de la animación para 
      activar el trigger
      @design  AnimationCoroutine()
      @author

      @date
      20/11/2020
     ***********************************************/
    /*IEnumerator AnimationCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        AnimatorStateInfo anim_info = libro_anim.GetCurrentAnimatorStateInfo(0);

        if (anim_info.IsName("idle"))
        {
            libro_anim.SetTrigger("appear_trigger");
        }
    }*/


    /**********************************************
      @description
      Cambio de la textura a mostrar en el libro
      @design paginaSeccions(GameObject) -> changeTexture()
      @author

      @date
      20/11/2020
     ***********************************************/

    /*public void changeTexture(GameObject paginaSecciones) 
    
    {
        Debug.Log("changeTexture");
        MeshRenderer meshRenderer = paginaSecciones.GetComponent<MeshRenderer>();
        // Get the current material applied on this GameObject
        Material oldMaterial = meshRenderer.material;
        //print the material name in the console
        Debug.Log("Applied Material: " + oldMaterial.name);
        // Set the new material on the GameObject
        meshRenderer.material = manualTexture;
    }*/



    /**********************************************
      @description
      Cambio de la página a página fichas
      @design  paginaSecciones (GameObject) -> changeFichas()
      @author

      @date
      20/11/2020
     ***********************************************/

    /*public void changeFichas(GameObject paginaSecciones)

    {
        //StartCoroutine(WaitToChangeTexture(paginaSecciones));
    }*/

    /**********************************************
      @description
      Corutina que espera a que se cambie la textura de la página
      @design  WaitToChangeTexture()
      @author

      @date
      20/11/2020
     ***********************************************/

    /*IEnumerator WaitToChangeTexture(GameObject paginaSecciones)
    {
        yield return new WaitForSeconds(3);

        Debug.Log("changeTexture");
        MeshRenderer meshRenderer = paginaSecciones.GetComponent<MeshRenderer>();
        // Get the current material applied on this GameObject
        Material oldMaterial = meshRenderer.material;
        //print the material name in the console
        Debug.Log("Applied Material: " + oldMaterial.name);
        // Set the new material on the GameObject
        meshRenderer.material = fichasTexture;
    }*/

     /**********************************************
      @description
      Inicia el juego de RA, desactivando el libro. Es llamado en el boton jugar del menú
      @design  jugar()
      @author
      Matthew Conde Oltra
      @date
      20/11/2020
     ***********************************************/
    public void jugar()
    {
        //Debug.Log("Go to play!");

        particle_system.Play();
        visagra.SetActive(false);
        libro_anim.SetTrigger("idle_open_to_idle");
        SceneManager.LoadScene("Minijuego");
    }
}