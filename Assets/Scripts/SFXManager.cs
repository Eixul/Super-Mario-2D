using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip goombaDeath;
    public AudioClip marioDeath;
    public AudioClip pickCoin;
    public AudioClip Bandera;
    public AudioClip Final;

    private AudioSource source;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void GoombaDeath()
    {
        source.PlayOneShot(goombaDeath);
    }

    public void MarioDeath()
    {
        source.PlayOneShot(marioDeath);
    }

    public void PickCoin()
    {
        source.PlayOneShot(pickCoin);
    }
    
    public void Flag()
    {
        source.PlayOneShot(Bandera);
    }

    public void Done()
    {
        source.PlayOneShot(Final);
    }

}
