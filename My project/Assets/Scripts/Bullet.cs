using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float daño; 

    private void Update(){
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")){
            other.GetComponent<Enemy>().RecibirDaño(daño);
            Destroy(gameObject);
        }
    }
}
