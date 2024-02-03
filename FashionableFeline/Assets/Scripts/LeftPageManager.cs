using UnityEngine;

public class LeftPageManager : MonoBehaviour
{
    public GameObject[] pages;
    private int currentPageIndex = 0;

    public UnityEngine.UI.Button leftArrowButton;

    void Start()
    {
        leftArrowButton = GetComponent<UnityEngine.UI.Button>();

        ShowCurrentPage();  
    }

    void ShowCurrentPage() 
    {
        foreach (GameObject page in pages)
        {
            page.SetActive(false);
        }

        pages[currentPageIndex].SetActive(true);
        
        if (leftArrowButton != null)
        {
            leftArrowButton.interactable = (currentPageIndex != 0);
        }
    }

    public void OnArrowClicked()
    {
        currentPageIndex--;

        if (currentPageIndex < 0)
        {
            currentPageIndex = pages.Length - 1;
        }

        ShowCurrentPage();
    }

}