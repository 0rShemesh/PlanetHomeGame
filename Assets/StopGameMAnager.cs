using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class StopGameMAnager : MonoBehaviour
{
    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if (Input.GetKey(KeyCode.Escape) && counter > 1)
        {
            
            counter = 0;
        }

        counter += Time.fixedDeltaTime;

    }
}
