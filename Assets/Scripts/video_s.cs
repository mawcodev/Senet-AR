using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

/**********************************************
@name: video_s
@description 
 Script asignado al videoplayer para el control de este y de distintos objetos emergentes (como el libro)
@author
 Matthew Conde Oltra, Diana Hernández
@date
 17/11/2020
@license 
***********************************************/

public class video_s : MonoBehaviour
{

    public UnityEngine.Video.VideoPlayer video;
    public GameObject libro;
    public GameObject rawImage;
    public GameObject skipIntro;
    public Vuforia.ImageTargetBehaviour image;

    public Animator libro_anim;
    private AnimatorStateInfo libro_anim_info;
    public GameObject particle_system_object;
    public ParticleSystem particle_system;
    public GameObject ui;

    void Start()
    {
        video = gameObject.GetComponent<UnityEngine.Video.VideoPlayer>();
        libro.SetActive(false);
        ui.SetActive(false);
        
    }



    void Update()
    {
        //Llamamos a la función que nos dice si detecta o no la marca
        update_imageTarget();
        
    }

    /**********************************************
     @description
     Activa la animación del libro, cuando termina el video
     @design abrirLibro()
     @author
     Matthew Conde Oltra
     @date
     22/11/2020
     ***********************************************/

    public void abrirLibro()
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

    }

    /**********************************************
    @description
    Desactiva en canvas de ayuda y ejecuta el video, esta función es llamada en On target found del IMAGETARGET de
    la marca que inicia el video
    @design GameObject AyudaInicial -> init_video()
    @author
    Matthew Conde Oltra, Diana Hernández
    @date
    20/11/2020
    ***********************************************/

    public void init_video(GameObject CanvasAyudaInicial)
    {
 
        video.Play();
        CanvasAyudaInicial.SetActive(false);

    }

    /**********************************************
    @description
    Finaliza el video, de forma que empezamos con la AR
    @design skip_video()
    @author
    Matthew Conde Oltra
    @date
    21/11/2020
    ***********************************************/

    public void skip_video()
    {
        video.Stop();
    }

    /**********************************************
    @description
    Se ejecuta en Update, durante toda la ejecución del proyecto
    Sirve para activar y/o desactivar los elementos de video y libro respecto a la detección de la marca
    @design update_imageTarget()
    @author
    Matthew Conde Oltra
    @date
    20/11/2020
    ***********************************************/
    public void update_imageTarget()
    {
        //Debug.Log("State image: " + image.CurrentStatusInfo);
        //Convertimos a string la información del estado de la ImageTarget, 
        // solo pueden ser dos --- NO_POSE y TRACKED

        string state_imageTarget = Convert.ToString(image.CurrentStatus);
        // si no está detectada la marca, el libro no aparecerá, a no ser que el video se haya
        //reproducido
        if (state_imageTarget == "NO_POSE")
        {
            //No hace nada
            //ui.SetActive(false);
        }
        // si la marca ha sido detectada se observará el video y el libro estara desactivado
        else if (state_imageTarget == "TRACKED")
        {
            if (!video.isPlaying)
            {
                rawImage.SetActive(false);
                skipIntro.SetActive(false);
                libro.SetActive(true);
                abrirLibro();
                ui.SetActive(true);
                gameObject.SetActive(false);

            }
            else
            {
                skipIntro.SetActive(true);
            }
        }
    }
    
}
