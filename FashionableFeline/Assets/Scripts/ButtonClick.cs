using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public AudioSource mySounds;
    public AudioClip clickSound;

    public void ClickSound()
    {
        mySounds.PlayOneShot(clickSound);
    }
}
