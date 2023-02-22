using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    Animator anim;
    BoxCollider2D boxCollider;
    SFXManager sfxManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();

    }

    // Update is called once per frame
    public void Pick()
    {
        boxCollider.enabled = false;
        Destroy(this.gameObject);
        sfxManager.PickCoin();
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "CollisionCoin")
        {
            Debug.Log("Coin Picked");
            Destroy(collision.gameObject);
            sfxManager.PickCoin();
        }
    }


}
