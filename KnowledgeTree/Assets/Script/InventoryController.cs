using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    bool inventoryActive=false;
    public GameObject inventory;
    
    void Start()
    {
        inventory.gameObject.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!inventoryActive)
            {
                inventory.gameObject.SetActive(true);
                inventoryActive = true;
            }
            else
            {
                inventory.gameObject.SetActive(false);
                inventoryActive = false;
            }
        }
        
    }
}
