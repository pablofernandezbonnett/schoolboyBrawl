using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject backgroundTemplate;

    private float _startPosition;
    // con boxcollider 2D
    private BoxCollider2D _boxCollider2D;
    private Camera _camera;
    
    void Start()
    {
        _startPosition = transform.position.x;
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _camera = camera.GetComponent<Camera>();
    }

    void Update()
    {
        EndlessBackground();
    }

    private void EndlessBackground()
    {
        float cameraPositionX = camera.transform.position.x;
        float boxCollider2DLengthX = _boxCollider2D.size.x;
        float limit = _startPosition + boxCollider2DLengthX;
        float offset = _camera.orthographicSize;

        if (cameraPositionX >= limit - offset * 2)
        {
            Debug.Log("cameraPositionX => " + cameraPositionX);
            var position = new Vector3(limit, transform.position.y, transform.position.z);
            var newInstance = Instantiate(backgroundTemplate, position, transform.rotation);
            Debug.Log("newInstance name => " + newInstance.name);
            Debug.Log("this objetc name => " + this.name);
            Destroy(gameObject);
        }
    }
}
