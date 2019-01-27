using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class MyExtensionMethods
{
    public static Vector3 MyScreenToWorldPosition(this Camera camera,Vector3 vector)
    {
        
        Vector3 newVector = vector;
        
        newVector.z = Camera.main.transform.position.z;


        return camera.ScreenToWorldPoint(newVector);
    }

}


public class SetMousePointer : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.MyScreenToWorldPosition(Input.mousePosition);

    }

}
