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
    public Sprite[] mySprites;      // Tus sprites de caminar
    public Sprite shootSprite;      // <--- EL NUEVO SPRITE DE DISPARO
    private int index = 0;
    
    // Variables de estado
    private bool isShooting = false; // Bandera para saber si estamos disparando

    private Rigidbody2D myRigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    public GameManager myGameManager;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRutine());
        // myGameManager = FindObjectOfType<GameManager>(); 
        myRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // 1. Movimiento Horizontal
        float inputX = Input.GetAxisRaw("Horizontal");
        myRigidbody2D.linearVelocity = new Vector2(inputX * playerSpeed, myRigidbody2D.linearVelocity.y);

        // 2. Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody2D.linearVelocity = new Vector2(myRigidbody2D.linearVelocity.x, playerJumpForce);
        }

        // 3. DETECTAR LA TECLA F PARA LA ANIMACIÓN
        // Importante: Usamos KeyCode.F
        if (Input.GetKeyDown(KeyCode.F) && !isShooting) 
        {
            StartCoroutine(ShootCoRutine());
        }
    }

    // Corrutina para manejar la animación de disparo
    IEnumerator ShootCoRutine()
    {
        isShooting = true; // Pausamos la animación de caminar
        
        // Cambiamos al sprite de disparo
        mySpriteRenderer.sprite = shootSprite;
        yield return new WaitForSeconds(0.2f);

        isShooting = false; // Reanudamos la animación de caminar
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GoodItem"))
        {
            Destroy(collision.gameObject);
            myGameManager.AddScore();
        }
        else if (collision.CompareTag("BadItem"))
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



 
