using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioSource clickSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

    }

    public void onClick()
    {
        clickSound.Play();
    }
}
