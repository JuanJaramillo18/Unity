using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;

    [Header("Configuración de Sprites")]
    public Sprite[] mySprites;
    public Sprite shootSprite;
    private int index = 0;
    private bool isShooting = false;

    private Rigidbody2D myRigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    public GameManager myGameManager;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRutine());
        myRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        myRigidbody2D.linearVelocity = new Vector2(inputX * playerSpeed, myRigidbody2D.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody2D.linearVelocity = new Vector2(myRigidbody2D.linearVelocity.x, playerJumpForce);
        }
        if (Input.GetKeyDown(KeyCode.F) && !isShooting) 
        {
            StartCoroutine(ShootCoRutine());
        }
    }

    IEnumerator ShootCoRutine()
    {
        isShooting = true;
        
        mySpriteRenderer.sprite = shootSprite;
        yield return new WaitForSeconds(0.2f);

        isShooting = false;
    }

    IEnumerator WalkCoRutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (isShooting == false) 
            {
                mySpriteRenderer.sprite = mySprites[index];
                index++;

                if (index >= mySprites.Length)
                {
                    index = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GoodItem"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("BadItem"))
        {
            Destroy(collision.gameObject);
            PlayerDeath();
        }
        else if (collision.CompareTag("Enemy"))
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        SceneManager.LoadScene("Level1");
    }
}