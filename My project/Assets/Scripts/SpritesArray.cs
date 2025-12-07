    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.SceneManagement;

    public class SpritesArray : MonoBehaviour
    {

        public Sprite[] mySprites;
        private int index = 0;
        private SpriteRenderer mySpriteRenderer;
        //public GameObject Bullet;
        //public GameManager myGameManager;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            mySpriteRenderer = GetComponent<SpriteRenderer>();
            StartCoroutine(WalkCoRutine());
            //myGameManager = FindObjectOfType<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }

       IEnumerator WalkCoRutine()
    {
        while (true) 
        {
            yield return new WaitForSeconds(0.05f);
            if (mySprites.Length == 0)
            {
                continue; 
            }
            mySpriteRenderer.sprite = mySprites[index];
            index++;
            if (index >= mySprites.Length)
            {
                index = 0;
            }
        }
    }
}
