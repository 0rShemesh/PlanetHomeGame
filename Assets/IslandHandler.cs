using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class IslandHandler : MonoBehaviour
{
    [SerializeField]
    IslandCanvasManager canvasManager;

    List<GameObject> trees;
    List<GameObject> bhouses;
    List<GameObject> whouses;
    List<GameObject> roads;

    DataHandler data;
    
    // Start is called before the first frame update
    void Start()
    {
        trees = GameObject.FindGameObjectsWithTag("Trees").ToList();
        bhouses = GameObject.FindGameObjectsWithTag("BricksHouse").ToList();
        whouses = GameObject.FindGameObjectsWithTag("WoodsHouse").ToList();
        roads = GameObject.FindGameObjectsWithTag("Road").ToList();

        foreach (GameObject tree in trees)
        {
            tree.gameObject.SetActive(false);
        }
        foreach (GameObject house in bhouses)
        {
            house.gameObject.SetActive(false);
        }
        foreach (GameObject house in whouses)
        {
            house.gameObject.SetActive(false);
        }
        foreach (GameObject road in roads)
        {
            road.gameObject.SetActive(false);
        }

    }

    void InputManager()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);

            if (hit.transform.tag == "SpaceShip")
            {
                SceneManager.LoadScene("Scenes/map_scene");
            }
        }
        if(Input.GetKey(KeyCode.V))
        {
            SceneManager.LoadScene("Scenes/map_scene");
        }
    }

    bool once = false;

    // Update is called once per frame
    void Update()
    {
        InputManager();
        if(data == null)
        {
           List<GameObject> objects = GetDontDestroyOnLoadObjects();
            foreach (var gmobject in objects)
            {
                DataHandler temp=null;
                try
                {
                        temp = gmobject.GetComponent<DataHandler>();

                
                }
                catch (System.Exception e)
                {
                    Debug.Log("Ithinkg thats not work");
                    
                }

                if(temp != null)
                {
                    data = temp;
                    once = false;
                }

            }


        }
        if(data !=null && !once)
        {
            once = true;
            int counter = 0;
            foreach (InventoryTypes item in data.inventoryItems.ToArray())
            {
                canvasManager.changeSlotItem(counter, item);
                

                
                counter += 1;
            }
            canvasManager.putThingsOnInventory(ref data.inventoryItems);
            canvasManager.putthecreatedObject(ref data.createdItems);
        }

        if(canvasManager.Bricks)
        {
            onBricks();
        }
        if(canvasManager.Wood)
        {
            onWood();
        }
        if(canvasManager.Shovel)
        {
            onShovel();
        }
        if(canvasManager.Sapling)
        {
            onSappling();
        }
    }

    /// <summary>
    /// Grow a trees by active it.
    /// </summary>
    void onSappling()
    {
        foreach (GameObject tree in trees)
        {
            tree.gameObject.SetActive(true);
        }

    }

    /// <summary>
    /// Make houses
    /// </summary>
    void onWood()
    {
        foreach (GameObject house in whouses)
        {
            house.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// make roads
    /// </summary>
    void onShovel()
    {
        foreach (GameObject road in roads)
        {
            road.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// make S-Mart (I Think super)
    /// </summary>
    void onBricks()
    {
        foreach (GameObject house in bhouses)
        {
            house.gameObject.SetActive(true);
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
