using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHandler : MonoBehaviour
{
    [Header("Baiscs things")]
    [SerializeField]
    public Rigidbody2D Rb;





    [Header("Added behavior")]
    [SerializeField]
    Movement ShipMovement; //this do nothing right now 

   

    public float GetSpeed()
    {
        return (Mathf.Abs((Rb.velocity.x))+Mathf.Abs( Rb.velocity.y)/2.0f);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputHandlerManager();
    }

    void InputHandlerManager()
    {
        if(Input.GetKey(KeyCode.W))
        {
            ShipMovement.IncreaseSpeed(0.5f);
        }
        if(Input.GetKey(KeyCode.S))
        {
            ShipMovement.DecreaseSpeed(0.5f);
        }
    }

}
