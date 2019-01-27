using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    

    public PlanetsHandler planetsHandler;
    public Material material;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    /*void Init()
    {



    }
    */


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {

            Debug.Log("Player is landing!");
            onPlayerCollision();
            
        }
    }

    #region On Player Collision With The Planet

    //public enum InventoryTypes
    //{
    //    sapling, wood, shovel, bricks, nothing
    //}

    float _counter = 0;
    void onPlayerCollision()
    {
        planetsHandler.onEnterPlanet(this);
        if(gameObject.name =="Earth")
        {

        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Home");

        }
       /*    else if(gameObject.name == "planetsV_1")
        {
            planetsHandler.dataHandler.inventoryItems.Add(InventoryTypes.bricks);
        }
        else if(gameObject.name == "planetsV_4")
        {
            planetsHandler.dataHandler.inventoryItems.Add(InventoryTypes.sapling);
        }
        else if(gameObject.name == "planetsV_9")
        {
            planetsHandler.dataHandler.inventoryItems.Add(InventoryTypes.wood);
        }
        else if(gameObject.name == "planetsV_10")
        {
            planetsHandler.dataHandler.inventoryItems.Add(InventoryTypes.shovel);
        }*/
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/generic");
        }
        
    }

    #endregion


}
