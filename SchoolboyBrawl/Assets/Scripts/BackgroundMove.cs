using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BackgroundMove : MonoBehaviour
{

    [SerializeField] private float speed = 20.0f;

    private BoxCollider _boxCollider;
    private Vector3 _startPosition;
    
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _startPosition = _boxCollider.transform.position;
    }

   
    void Update()
    {
        if (_startPosition.x  - transform.position.x > 50) { 
            // donde 50 es el numero donde se acaba la imagen y habra q empezar a repetir
            transform.position = _startPosition;
        } // mejora, añadir un box collider y consultar su tamaño y dividir by 2
    }
}
