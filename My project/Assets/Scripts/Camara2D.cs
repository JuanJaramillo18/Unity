using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camara2D : MonoBehaviour
{
    public Transform targetPlayer;

    void Update()
    {
        if (targetPlayer == null)
            return;

        transform.position = new Vector3(targetPlayer.position.x + 6f, 0, -10);
    }
}