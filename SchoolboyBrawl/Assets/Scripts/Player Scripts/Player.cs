using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private Animator _animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        
    }
}
