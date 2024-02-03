using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThemeManager : MonoBehaviour
{
    public Button themeButton;
    public TextMeshProUGUI themeText;
    private string[] themes = { "Fantasy", "Elegant", "Spooky", "Farm", "Cozy", "Natural" };

    public GameObject[] elegantSet;
    public GameObject[] fantasySet;
    public GameObject[] spookySet;
    public GameObject[] farmSet;
    public GameObject[] cozySet;
    public GameObject[] naturalSet;
    
    private Dictionary<string, GameObject[]> themeSets;

    void Start()
    {
        InitializeThemeSets();
        SetRandomTheme();
    }

    void InitializeThemeSets()
    {
        themeSets = new Dictionary<string, GameObject[]>
        {
            { "Fantasy", fantasySet },
            { "Elegant", elegantSet },
            { "Spooky", spookySet },
            { "Natural", naturalSet },
            { "Cozy", cozySet },
            { "Farm", farmSet }
        };
    }

    void SetRandomTheme() {
        int randomIndex = Random.Range(0, themes.Length);
        string randomTheme = themes[randomIndex];

        themeText.text = randomTheme;
    }

    public string GetCurrentTheme()
    {
        return themeText.text;

    }

    public Dictionary<string, GameObject[]> GetThemeSets()
    {
        return themeSets;
    }

}
