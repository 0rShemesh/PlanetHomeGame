using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LootManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D collider;
    public SpriteRenderer image;
    public DataHandler data;
    public InventoryTypes mytype;


    // Start is called before the first frame update

    private void Awake()
    {
        mytype = InventoryTypes.nothing;
        if (data == null)
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
                    data = temp;

                }

            }


        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Good Good");
            data.inventoryItems.Add(mytype);
            Destroy(gameObject);
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
