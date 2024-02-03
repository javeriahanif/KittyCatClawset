using UnityEngine;

public class ReadyFunction : MonoBehaviour
{
    public GameObject clothingManagerGameObject;
    public void ReadyButton() 
    {
        ClothingManager clothingManager = clothingManagerGameObject.GetComponent<ClothingManager>();
        Debug.Log("testing 1");
        GameObject[] activeClothes = clothingManager.getClothingSelected();
        Debug.Log("testing 2");
        for (int i = 0; i < 5; i++) {
            if (activeClothes[i] != null) {
                DontDestroyOnLoad(activeClothes[i]);
            }
        }

        Debug.Log("testing 3");
    }
}
