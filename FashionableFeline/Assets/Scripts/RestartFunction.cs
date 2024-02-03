using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartFunction : MonoBehaviour
{
    public void RestartButton() 
    {
        SceneManager.LoadSceneAsync(0);
    }
}
