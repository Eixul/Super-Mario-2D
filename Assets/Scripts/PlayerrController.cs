using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerrController : MonoBehaviour
{
    int playerHealth = 3;
    public float playerSpeed = 6f;
    public float jumpforce = 8f;
    public Text contador;
    string texto = "Hello World";
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody;
    private GroundSensor sensor;
    public Animator anim;
    private Coins coin;
    float horizontal;
    public SFXManager sfxManager;
    private BanderaFinish Flag;
    int ContadorMonedas;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        coin = GameObject.Find("Coins").GetComponent<Coins>();
        ContadorMonedas = 0;

        playerHealth = 10;
        Debug.Log(texto);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        //transform.position += new Vector3(horizontal, 0, 0) * playerSpeed * Time.deltaTime;

        if(horizontal < 0)
        {
            spriteRenderer.flipX = true;
            anim.SetBool("IsRunning", true);
        }
        else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if(Input.GetButtonDown("Jump") && sensor.isGrounded)
        {
            rBody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            anim.SetBool("IsRunning", true);
        }
    }
    void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "CollisionCoin")
        {
            Debug.Log("Coin Picked");
            Coins coin = collision.gameObject.GetComponent<Coins>();
            coin.Pick();
            ContadorMonedas++;
            Debug.Log(ContadorMonedas);
            contador.text = "Coiners " + ContadorMonedas;
        }

        if(collision.gameObject.tag == "CollisionFlag")
        {
            Debug.Log("Finished");
            BanderaFinish Flag = collision.gameObject.GetComponent<BanderaFinish>();
        }
    }
}

