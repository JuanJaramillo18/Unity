using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CoinScore : MonoBehaviour
{   
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Score score;

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("GoodItem"))
        {
            score.SumarPuntos(cantidadPuntos);
            Destroy(collision.gameObject);
        }
    }
}
