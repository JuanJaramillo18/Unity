using UnityEngine;

public class Lifespan : MonoBehaviour
{
    [SerializeField] private float lifespan;

    private void Start()
    {
        Destroy(gameObject, lifespan);
    }
}
