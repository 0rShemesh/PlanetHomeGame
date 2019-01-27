using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerCanvasManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI speedText;


    public DataHandler dataHandler;
    public List<ButtonManager> buttonManagers;

    bool once = false;
    public void ChangeSpeedText(string speed)
    {
        if (speedText != null)
        {
            speedText.text = speed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (buttonManagers.Count > 0)
        {
            foreach (ButtonManager button in buttonManagers)
            {
                button.SetType(InventoryTypes.nothing);
                Destroy(button.button.gameObject.GetComponent<UnityEngine.UI.Image>());
                Destroy(button.button);
            }
            for (int i = 0; i < buttonManagers.Count && i < dataHandler.inventoryItems.Count; i++)
            {
                buttonManagers[i].SetType(dataHandler.inventoryItems[i]);


            }
        }
        
    }

    // Update is called once per frame
    float counter = 0;
    void Update()
    {
        if (dataHandler != null && counter>2f && buttonManagers != null && buttonManagers.Count>0) 
        {
            once = true;
            Debug.Log("enter!");
            for (int i = 0; i < buttonManagers.Count && i < dataHandler.inventoryItems.Count; i++)
            {
                buttonManagers[i].SetType(dataHandler.inventoryItems[i]);

                counter = 0;
            }
            
            
            
        }
        counter += Time.deltaTime;
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
