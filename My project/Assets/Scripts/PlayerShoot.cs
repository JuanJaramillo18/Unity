using UnityEngine;

public class PlayerShoot2D : MonoBehaviour
{
    [SerializeField] private Transform controlladorDisparo;
    [SerializeField] private GameObject bala;

    private void Update(){
        if (Input.GetKeyDown(KeyCode.F))
        {
            Disparar();
        }
    }

    private void Disparar(){
        Instantiate(bala, controlladorDisparo.position, controlladorDisparo.rotation);
    }
}

