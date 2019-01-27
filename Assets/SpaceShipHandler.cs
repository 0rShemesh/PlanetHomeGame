using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipHandler : MonoBehaviour
{
    [Header("Space Ship Object")]
    [SerializeField]
    ShipHandler shipHandler;
    [Header("Canvas Overlyer Object")]
    [SerializeField]
    PlayerCanvasManager canvasManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        canvasManager.ChangeSpeedText(String.Format("{0:0.00}", shipHandler.GetSpeed()));
        

    }
}
