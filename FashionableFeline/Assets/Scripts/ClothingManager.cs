using UnityEngine;
using System.Collections.Generic;
using System;

public class ClothingManager : MonoBehaviour
{
    // Clothing items array
    public GameObject[] clothingItems;

    // currently equipped item
    private List<GameObject> currentEquippedItems;

    private GameObject[] clothingSelected = new GameObject[5];
    // hat shirt pants shoes accessory 
    // hat dress null  shoes accessory
    // 0   1     2     3     4

    // to dress up the character

    private int tagToArrayPos(String tag) {
        Debug.Log(tag);
        switch (tag) {
            case "Hat":
                return 0;
            case "Shirt":
                return 1;
            case "Dress":
                return 1;
            case "Pants":
                return 2;
            case "Shoes":
                return 3;
            case "Accessory":
                return 4;
        }
        return -1;
    }

    public GameObject[] getClothingSelected() {
        return clothingSelected;
    }


    public void DressUpCharacter(GameObject selectedClothingItem)
    {
        int clothingSelectedPos = tagToArrayPos(selectedClothingItem.tag);

        // checks if clothing is being worn and takes it off
        if (clothingSelected[clothingSelectedPos] == selectedClothingItem) {
            selectedClothingItem.SetActive(false);
            clothingSelected[clothingSelectedPos] = null;
            return;
        }

        if (clothingSelected[clothingSelectedPos] != null) {
            clothingSelected[clothingSelectedPos].SetActive(false);
        }

        // if putting on dress take off pants
        if (selectedClothingItem.tag == "Dress" && clothingSelected[2] != null) {
            clothingSelected[2].SetActive(false);
            clothingSelected[2] = null;
            
        }


        // if putting on pants take off dress if wearing dress
        if (selectedClothingItem.tag == "Pants" && clothingSelected[1] != null && clothingSelected[1].tag == "Dress") {
            clothingSelected[1].SetActive(false);
            clothingSelected[1] = null;
        }

        clothingSelected[clothingSelectedPos] = selectedClothingItem;
        clothingSelected[clothingSelectedPos].SetActive(true);



        // Check if the selected item is already equipped
        /*
        if (currentEquippedItems.Contains(selectedClothingItem))
        {
            // Unequip the item by deactivating it
            DeactivateClothingItem(selectedClothingItem);
        }
        else
        {
            // Equip the selected item
            currentEquippedItems.Append(selectedClothingItem);
            clothingSelected.Append(selectedClothingItem);
            // Check if dress is active
            bool isDressActive = IsTagActive("Dress");

            // Activate the selected clothing item
            ActivateClothingItem(selectedClothingItem);

            // Deactivate other items based on specific tags
            DeactivateOtherItems(selectedClothingItem.tag, isDressActive);
        }*/
    }

    // Helper method to deactivate other clothing items based on specific tags
    private void DeactivateOtherItems(string selectedTag, bool isDressActive)
    {


        /*
        foreach (GameObject item in clothingItems)
        {
            if (item != null && item.CompareTag(selectedTag))
            {
                // Activate the selected item
                ActivateClothingItem(item);

            }
            else
            {
                // Deactivate other items based on specific tags
                if (!isDressActive || !IsTagActive("Shirt") && !IsTagActive("Pants"))
                {
                    DeactivateClothingItem(item);
                }
            }
        }
        */
    }

    // Helper method to check if a specific tag is active
    private bool IsTagActive(string tag)
    {
        GameObject item = System.Array.Find(clothingItems, item => item.CompareTag(tag));
        return item != null && item.activeSelf;    
    }

    // Helper method to deactivate clothing items by tag
    private void DeactivateClothingItemsByTag(string tag)
    {
        foreach (GameObject item in clothingItems)
        {
            if (item != null && item.CompareTag(tag))
            {
                DeactivateClothingItem(item);
            }
        }
    }

    // Helper method to deactivate a clothing item
    private void DeactivateClothingItem(GameObject clothingItem)
    {
        if (clothingItem != null)
        {
            clothingItem.SetActive(false);

        }
        currentEquippedItems.Remove(clothingItem);

    }

    // Helper method to activate a clothing item
    private void ActivateClothingItem(GameObject clothingItem)
    {
        if (clothingItem != null)
        {
            clothingItem.SetActive(true);
            // clothingSelected.Append(clothingItem);
            // foreach (GameObject item in clothingSelected) {
            //     Debug.Log(item.tag);
            // }
        }
    }
}



