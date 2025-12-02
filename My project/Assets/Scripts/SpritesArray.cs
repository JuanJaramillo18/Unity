using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SpritesArray : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myRigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    //public GameObject Bullet;
    //public GameManager myGameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRutine());
        //myGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody2D.linearVelocity = new Vector2(myRigidbody2D.linearVelocity.x, playerJumpForce);
        }
        myRigidbody2D.linearVelocity = new Vector2(playerSpeed, myRigidbody2D.linearVelocity.y);
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }

    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if (index == 2)
        {
            index = 0;
        }
        {
            StartCoroutine(WalkCoRutine());
        }
    }

}
