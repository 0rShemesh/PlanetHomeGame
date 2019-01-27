using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    //[HideInInspector] public Transform prefab;
    public int starsNumber;
    public int mapSize;

    [SerializeField]
    PlanetManager ClonePlanet;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < starsNumber; i++)
        {
            //TextAsset imageAsset;

            /*
            Texture2D tex = null;
            byte[] fileData;

            if (File.Exists(filePath))
            {
                fileData = File.ReadAllBytes(filePath);
                tex = new Texture2D(2, 2);
                tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            }
            
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(imageAsset.bytes);
            GetComponent<Renderer>().material.mainTexture = tex;
            var texture = Resources.Load<Texture2D>("PlanetsTexturs/1");
            */
            /*
            var myTexture = Resources.Load("Images/SampleImage") as Texture2D;

            GameObject rawImage = GameObject.Find("RawImage");

            Debug.Log(texture);*/
            //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //sphere.transform.position = new Vector3(Random.Range(-mapSize, mapSize), Random.Range(-mapSize, mapSize), 0);
           // Material material = new Material(Shader.Find("S"));
            //PlanetManager planet = Instantiate(ClonePlanet);
            float scale = Random.Range(10, 15);
            //planet.Init(material,"GoodNiceName",new Vector3(scale,scale,scale), new Vector3(Random.Range(-mapSize, mapSize), Random.Range(-mapSize, mapSize), 0));


            //Instantiate(prefab, new Vector3(Random.Range(-mapSize, mapSize), Random.Range(-mapSize, mapSize), 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
