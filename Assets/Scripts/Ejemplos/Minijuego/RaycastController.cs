/**********************************************
@name: RaycastController
@description 
Rayo que intercepta entre los distintos objetos del escenario y recoge el punto destino de la bola
@authors: Matthew Conde Oltra
@date
23/12/2020
@license 
***********************************************/
using UnityEngine;
public class RaycastController : MonoBehaviour
{
    
    public Camera arCamera;
    
    private Ray ray;

    //Variable destino, es un vector3 de posición
    private Vector3 destino;
    private float distancia;

    private RaycastHit hitObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

    }
    /**********************************************
     @description
     Función que activa el rayo y recoge los parametros que nos interesan, destino y distancia del objeto interceptado.
     @design activeRaycast()
     @author
     Matthew Conde Oltra
     @date
     24/12/2020
     ***********************************************/
    public void activeRaycast()
    {
        //El rayo debe salir desde sphere hasta el infinito
        ray = new Ray(arCamera.transform.position, arCamera.transform.forward);

        if (Physics.Raycast(ray, out hitObject, 30f))
        {
            //Debug.Log("Debug: objeto encontrado -->" + hitObject.collider.name);

            if (hitObject.collider.name == "diana")
            {

                //Debug.Log("Debug:  distancia -->" + hitObject.distance);
                destino = hitObject.point;
                distancia = hitObject.distance;
            }


        }

    }
    /**********************************************
      @description
      Función que devuelve el valor de la distancia del rayo al punto encontrado
      @design GetDistance()
      @author
      Matthew Conde Oltra
      @date
      25/12/2020
      ***********************************************/
    public float GetDistancia()
    {
        return distancia;
    }
    /**********************************************
      @description
      Función que devuelve el valor del punto destino
      @design GetDestiny()
      @author
      Matthew Conde Oltra
      @date
      25/12/2020
      ***********************************************/
    public Vector3 GetDestiny()
    {
        return destino;
    }
}
