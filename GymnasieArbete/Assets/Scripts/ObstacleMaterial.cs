using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMaterial : MonoBehaviour
{
    public Material white;
    public Material light;
    public Material dark;

    


    void Start()
    {       
        if (gameObject.tag== "Destructible")
        {
            gameObject.GetComponent<MeshRenderer>().material = light;
        }
        else if (gameObject.tag == "Through")
        {

        }
        else if (gameObject.tag == "Falling")
        {
            gameObject.GetComponent<MeshRenderer>().material = dark;
        }
        else if (gameObject.tag == null)
        {
            gameObject.GetComponent<MeshRenderer>().material = white;
        }
    }

    
    
}
