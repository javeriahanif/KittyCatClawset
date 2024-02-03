using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsOpener : MonoBehaviour
{
    public GameObject Creditsscreen;

    public void OpenCreditsscreen()
    {
        if(Creditsscreen != null)
        {
            bool isActive = Creditsscreen.activeSelf;
            Creditsscreen.SetActive(!isActive);
        }
    }
}
