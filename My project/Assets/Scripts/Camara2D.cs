using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camara2D : MonoBehaviour
{
    public Transform targetPlayer; // El objetivo que la cámara seguirá
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetPlayer.position.x + 6f,0,-10);
    }
}
