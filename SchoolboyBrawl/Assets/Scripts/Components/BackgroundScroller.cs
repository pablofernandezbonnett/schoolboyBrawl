using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject background;

    private float _startPosition;
    // con boxcollider 2D
    private BoxCollider _boxCollider;
    private Camera _camera;
    
    void Start()
    {
        _startPosition = transform.position.x;
        _boxCollider = GetComponent<BoxCollider>();
        _camera = camera.GetComponent<Camera>();
    }

    void Update()
    {
        EndlessBackground();
    }

    private void EndlessBackground()
    {
        float cameraPositionX = camera.transform.position.x;
        float boxColliderLengthX = _boxCollider.size.x;
        float limit = _startPosition + boxColliderLengthX;
        float offset = _camera.orthographicSize;

        if (cameraPositionX >= limit - offset * 2)
        {
            Debug.Log("cameraPositionX => " + cameraPositionX);
            var position = new Vector3(limit, transform.position.y, transform.position.z);
            var newInstance = Instantiate(background, position, transform.rotation);
            Debug.Log("newInstance name => " + newInstance.name);
            Debug.Log("this objetc name => " + this.name);
            Destroy(gameObject);
        }
    }
}
