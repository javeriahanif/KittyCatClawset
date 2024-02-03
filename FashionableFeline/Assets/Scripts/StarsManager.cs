using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StarsManager : MonoBehaviour
{

    private ClothingManager clothingManager;

    public GameObject clothingManagerGameObject;
    public GameObject[] StarSprites;
    public ThemeManager themeManager;

    public GameObject goodEnding;
    public GameObject mehEnding;
    public GameObject badEnding;
    

    // calculates stars 
    public void CalculateAndDisplayStars()
    {
        clothingManager = clothingManagerGameObject.GetComponent<ClothingManager>();

        // Gets the currently selected theme from ThemeManager
        string currentTheme = themeManager.GetCurrentTheme();

        Debug.Log(currentTheme);

        // Gets the themeSets dictionary from ThemeManager
        Dictionary<string, GameObject[]> allThemeSets = themeManager.GetThemeSets();

        // Gets the associated theme set from the ThemeManager
        if (allThemeSets.TryGetValue(currentTheme, out GameObject[] themeSet))
        {
            int ThemeMatch = CountMatchingClothes(themeSet);

            // Activates stars based on the theme match
            ActivateStars(ThemeMatch);
        }
    }

    private int CountMatchingClothes(GameObject[] themeSet)
    {
        int matchCount = 0;
        int nullCount = 0;

        GameObject[] clothingSelected = clothingManager.getClothingSelected();
        for (int i = 0; i < 5; i++)
        {
            if (clothingSelected == null) {
                nullCount++;
                continue;
            }
            if (themeSet.Contains(clothingSelected[i]))
            {
                matchCount++;
            }
        }
        Debug.Log("matchCount " + matchCount.ToString());
        Debug.Log("nullCount " + nullCount.ToString());


        return matchCount;

    }

    private void giveGoodEnding () {
        goodEnding.SetActive(true);
    }private void giveMehEnding () {
        mehEnding.SetActive(true);
    }private void giveBadEnding () {
        badEnding.SetActive(true);
    }


    // activates stars 
    private void ActivateStars(int ThemeMatch)
    {
        // Deactivate all stars first
        DeactivateAllStars();

        if (ThemeMatch >= 4)
        {
            Invoke("giveGoodEnding", 3f);
            ActivateSpecificStar(2); // activate 3 stars
            ActivateSpecificStar(1);
            ActivateSpecificStar(0);

        }
        else if (ThemeMatch >= 2)
        {
            ActivateSpecificStar(1); // activate 2 stars
            ActivateSpecificStar(0);
            Invoke("giveMehEnding", 3f);
        }
        else if (ThemeMatch >= 0)
        {
            ActivateSpecificStar(0); // activate 1 star

            Invoke("giveBadEnding", 3f);
        }
    }

    // Helper method to activate a specific star
    private void ActivateSpecificStar(int starIndex)
    {
        if (starIndex >= 0 && starIndex < StarSprites.Length)
        {
            StarSprites[starIndex].SetActive(true);
        }
        else
        {
            Debug.LogError($"Invalid starIndex");
        }
    }

    // Helper method to deactivate all stars
    private void DeactivateAllStars()
    {
        foreach (GameObject star in StarSprites)
        {
            star.SetActive(false);
        }
    } 
}
