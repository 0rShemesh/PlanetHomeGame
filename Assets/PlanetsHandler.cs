using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetsHandler : MonoBehaviour
{

   public DataHandler dataHandler;
   public List<PlanetManager> planets;

    public void onEnterPlanet(PlanetManager planet)
    {
        
        dataHandler.SpaceShipLocation = planet.name;
        DontDestroyOnLoad(dataHandler);
    }

    // Start is called before the first frame update
    void Start()
    {
        //foreach (Transform child in transform)
        //{
        //    planets.Add(child.GetComponent<PlanetManager>());
        //}
        foreach (var item in GameObject.FindGameObjectsWithTag("Planet"))
        {
            planets.Add(item.GetComponent<PlanetManager>());
            
        }
        

        dataHandler = GameObject.FindGameObjectWithTag("DataObject").GetComponent<DataHandler>();

        foreach (PlanetManager planet in planets)
        {
            planet.planetsHandler = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        justNiceMethodForGetItemsUnitlItFnished();

    }

    float counter = 0;
    /// <summary>
    /// Method that are me(orshemesh)  using forget items in temp way.
    /// </summary>
    void justNiceMethodForGetItemsUnitlItFnished()
    {
        if(Input.GetKey(KeyCode.K) && counter >1)
        {
            dataHandler.inventoryItems.Add(InventoryTypes.bricks);
            dataHandler.inventoryItems.Add(InventoryTypes.sapling);
            dataHandler.inventoryItems.Add(InventoryTypes.shovel);
            dataHandler.inventoryItems.Add(InventoryTypes.wood);
            counter = 0;
        }
       
        counter += Time.fixedDeltaTime;

    }

    private void Awake()
    {
        
        if (dataHandler == null)
        {
            List<GameObject> objects = GetDontDestroyOnLoadObjects();
            foreach (var gmobject in objects)
            {
                DataHandler temp = null;
                try
                {
                    temp = gmobject.GetComponent<DataHandler>();


                }
                catch (System.Exception e)
                {
                    Debug.Log("Ithinkg thats not work");

                }

                if (temp != null)
                {
                    dataHandler = temp;

                }

            }


        }
    }
    public static List<GameObject> GetDontDestroyOnLoadObjects()
    {
        List<GameObject> result = new List<GameObject>();

        List<GameObject> rootGameObjectsExceptDontDestroyOnLoad = new List<GameObject>();
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            rootGameObjectsExceptDontDestroyOnLoad.AddRange(SceneManager.GetSceneAt(i).GetRootGameObjects());
        }

        List<GameObject> rootGameObjects = new List<GameObject>();
        Transform[] allTransforms = Resources.FindObjectsOfTypeAll<Transform>();
        for (int i = 0; i < allTransforms.Length; i++)
        {
            Transform root = allTransforms[i].root;
            if (root.hideFlags == HideFlags.None && !rootGameObjects.Contains(root.gameObject))
            {
                rootGameObjects.Add(root.gameObject);
            }
        }

        for (int i = 0; i < rootGameObjects.Count; i++)
        {
            if (!rootGameObjectsExceptDontDestroyOnLoad.Contains(rootGameObjects[i]))
                result.Add(rootGameObjects[i]);
        }

        //foreach( GameObject obj in result )
        //    Debug.Log( obj );

        return result;
    }

}
