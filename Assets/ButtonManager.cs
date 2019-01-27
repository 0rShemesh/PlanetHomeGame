using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    Image image;
    [SerializeField]
    public Button button;

    InventoryTypes inventoryType;

    Image GetImage()
    {
        return image;
    }

    void SetImage(Image image,InventoryTypes type)
    {
        this.image = image;
        this.inventoryType = type;
    }
    bool someWiredThings = false;
    public void SetType(InventoryTypes type)
    {
        someWiredThings = true;
        inventoryType = type;
    }

    public InventoryTypes GetObjectType()
    {
        return this.inventoryType;
    }

    public bool hasClicked { get; private set; }

    void OnButtonClick()
    {
        hasClicked = true;
    }

    public void Notified()
    {
        hasClicked = false;
    }

    void Start()
    {
        
        if(button == null)
        {
            button = GetComponent<Button>();
        }
        if(inventoryType != InventoryTypes.nothing)
        if(!someWiredThings)
        inventoryType = InventoryTypes.nothing;
        hasClicked = false;
        button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    InventoryTypes lastType= InventoryTypes.nothing;
    void Update()
    {
        if (lastType == inventoryType)
        {

            switch (inventoryType)
            {
                case InventoryTypes.sapling:
                    image.color = Color.white;
                    image.sprite = Resources.Load<Sprite>("InventoryItems/Oak_Sapling");
                    break;
                case InventoryTypes.wood:
                    image.color = Color.white;
                    image.sprite = Resources.Load<Sprite>("InventoryItems/Wood");
                    break;
                case InventoryTypes.shovel:
                    image.color = Color.white;
                    image.sprite = Resources.Load<Sprite>("InventoryItems/Shovel");
                    break;
                case InventoryTypes.bricks:
                    image.color = Color.white;
                    image.sprite = Resources.Load<Sprite>("InventoryItems/Bricks");
                    break;
                case InventoryTypes.nothing:
                    image.color = Color.clear;
                    image.sprite = null;
                    break;
                default:
                    break;
            }

        }
        lastType = inventoryType;

    }
}
