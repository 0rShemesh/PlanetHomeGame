using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World : MonoBehaviour
{

    public GameObject DirtTile;
    public GameObject GrassTile;
    public GameObject StoneTile;
    public GameObject GrassTile_Edge;
    public PhysicsMaterial2D GrassTile_Edge_Material;
    public GameObject WorldWallTile;
    public static int width;
    public GameObject enemy;
    private float heightMultiplier;
    private int heightAddition;
    public Vector2 enemyRange;
    private float smoothness;
    private int enemyAmount;
    float seed;

    public LootManager Loot;
    

    // Use this for initialization
    void Start()
    {
        seed = Random.Range(-10000, 10000);
        width = Random.Range(500, 1000);
        heightMultiplier = Random.Range(5, 10);
        heightAddition = Random.Range(10, 11);
        smoothness = Random.Range(5, 50);
        enemyAmount = Random.Range((int)enemyRange.x, (int)enemyRange.y);
        Generate();
        SpawnEnemies();
        SpawnLoot();
    }

    void SpawnEnemies()
    {
        List<int> alreadyExisting = new List<int>(); ;
        bool canPass = false;
        int x = 0;
        for (int i = 0; i < enemyAmount; i++)
        {

            canPass = false;
            while (!canPass)
            {
                x = Random.Range(0, width - 10);
       
                if (!alreadyExisting.Contains(x)) canPass = true;
            }
            Instantiate(enemy, (Vector3)new Vector2(x, 20), Quaternion.identity);
        }
    }

    void SpawnLoot()
    {
        InventoryTypes lootitem =(InventoryTypes) Random.Range(0, 4);
        Loot.mytype = lootitem;
        switch (lootitem)
        {
            case InventoryTypes.sapling:
                Loot.image.sprite = Resources.Load<Sprite>("InventoryItems/Oak_Sapling");
                Loot.image.color = Color.white;
                break;
            case InventoryTypes.wood:
                Loot.image.sprite = Resources.Load<Sprite>("InventoryItems/Wood");
                Loot.image.color = Color.white;
                break;
            case InventoryTypes.shovel:
                Loot.image.sprite = Resources.Load<Sprite>("InventoryItems/Shovel");
                Loot.image.color = Color.white;
                break;
            case InventoryTypes.bricks:
                
                Loot.image.sprite = Resources.Load<Sprite>("InventoryItems/Bricks");
                Loot.image.color = Color.white;
                break;
            case InventoryTypes.nothing:
                Loot.image.color = Color.clear;
                Loot.image.sprite = null;
                break;
            default:
                break;
        }
        //Loot.image.size = new Vector2(1,1);
        Loot.rb.position = new Vector2(width - 40, 1000);
    }
    void Generate()
    {
        Vector3 recentTop = Vector3.zero;
        GameObject lastGameObject = null;
        bool topValue = false;
        for (int i = 0; i < width; i++)
        {
            if (i % 20 == 0)
            {
                seed = Random.Range(0, 20000);
            }
            int h = Mathf.RoundToInt(Mathf.PerlinNoise(seed, i / smoothness) * heightMultiplier) + heightAddition;
            for (int j = 0; j < h; j++)
            {
                GameObject selectedTile;
                GameObject temp;
                if (j < h - 4)
                {
                    selectedTile = StoneTile;
                }
                else if (j < h - 1)
                {
                    selectedTile = DirtTile;
                }
                else
                {
                    topValue = true;
                    selectedTile = GrassTile;
                    if (lastGameObject != null)
                    {
                        Debug.Log("LGO: {0}" + lastGameObject.transform.position.ToString() + " CurrentH: " + h);

                        if (lastGameObject.transform.position.y + 1 < h)
                        {
                            Debug.Log("the new tile is higher! I should make it an edge tile!");
                            selectedTile = GrassTile_Edge;

                        }
                        else if (lastGameObject.transform.position.y + 1 > h)
                        {
                            Debug.Log("the new tile is lower! modifying the last one");
                            lastGameObject.GetComponent<BoxCollider2D>().sharedMaterial = GrassTile_Edge_Material;
                        }

                    }

                }

                if (topValue)
                {
                    lastGameObject = Instantiate(selectedTile, new Vector3(i, j), Quaternion.identity);

                    topValue = false;
                    if (i == 12 || i == width - 12)
                        for (int k = h; k < 20; k++)
                        {
                            temp = Instantiate(WorldWallTile, new Vector3(i, k), Quaternion.identity);
                            if (temp != null)
                                temp.transform.SetParent(GameObject.FindGameObjectWithTag("Ground").transform);
                        }
                    lastGameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Ground").transform);
                }

                else
                {
                    temp = Instantiate(selectedTile, new Vector3(i, j), Quaternion.identity);
                    if (temp != null)
                        temp.transform.SetParent(GameObject.FindGameObjectWithTag("Ground").transform);
                }

            }
        }
    }


    
}
