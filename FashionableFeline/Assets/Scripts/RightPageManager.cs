using UnityEngine;

public class RightPageManager : MonoBehaviour
{
    public GameObject[] pages;
    private int currentPageIndex = 0;
    
    public UnityEngine.UI.Button rightArrowButton;

    void Start()
    {
        rightArrowButton = GetComponent<UnityEngine.UI.Button>();

        ShowCurrentPage();  
    }

    void ShowCurrentPage() 
    {
        foreach (GameObject page in pages)
        {
            page.SetActive(false);
        }

        pages[currentPageIndex].SetActive(true);

        if (rightArrowButton != null)
        {
            rightArrowButton.interactable = true; // Always make the right arrow button interactable

            // Check if the next page is the first page
            if (currentPageIndex == pages.Length - 1)
            {
                // If the next page is the first page, set interactable to false
                rightArrowButton.interactable = false;
            }
        }
    }

    public void OnArrowClicked()
    {
        currentPageIndex++;

        if (currentPageIndex >= pages.Length)
        {
            // Wrap around to the first page
            currentPageIndex = 0;
        }

        ShowCurrentPage();

    }

}
