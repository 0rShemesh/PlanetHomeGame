using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public enum InventoryTypes
{
    sapling,wood,shovel,bricks,nothing
}

public class IslandCanvasManager : MonoBehaviour
{
    [SerializeField]
    List<ButtonManager> slots;

    List<InventoryTypes> createdItemds;// = new List<InventoryTypes>();
    List<InventoryTypes> Inventory;// = new List<InventoryTypes>();

    #region boolean has make region
    public bool Sapling { get; private set; }
    public bool Wood { get; private set; }
    public bool Shovel { get; private set; }
    public bool Bricks { get; private set; }

    #endregion

    public void putthecreatedObject(ref List<InventoryTypes> items)
    {
        createdItemds = items;
        foreach (var item in items)
        {
            enableObjects(item);
        }
    }
    public void putThingsOnInventory(ref List<InventoryTypes> items)
    {
        Inventory = items;

    }


    public void changeSlotItem(int index,InventoryTypes types)
    {
        if (slots.Count < index)
            Debug.LogError("Out Of Range!");
        else
        {
            slots[index].SetType(types);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Wood = false;
        Bricks = false;
        Shovel = false;
        Sapling = false;


       
        
        //slots[0].SetType(InventoryTypes.shovel);
        //slots[1].SetType(InventoryTypes.sapling);
        //slots[2].SetType(InventoryTypes.wood);
        //slots[3].SetType(InventoryTypes.bricks);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (ButtonManager slot in slots)
        {
            if(slot.hasClicked)
            {
                enableObjects(slot.GetObjectType());

                Inventory.Remove(slot.GetObjectType());

                createdItemds.Add(slot.GetObjectType());

                slot.SetType(InventoryTypes.nothing);
                
                slot.Notified();
            }
        }
    }

    


    public void enableObjects(InventoryTypes inventoryType)
    {
        switch (inventoryType)
        {
            case InventoryTypes.sapling:
                Sapling = true;
                break;
            case InventoryTypes.wood:
                Wood = true;
                break;
            case InventoryTypes.shovel:
                Shovel = true;
                break;
            case InventoryTypes.bricks:
                Bricks = true;
                break;
            case InventoryTypes.nothing:
                break;
            default:
                break;
        }

    }


    

}
