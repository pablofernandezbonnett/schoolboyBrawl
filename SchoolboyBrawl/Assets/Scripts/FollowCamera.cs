using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    void Update()
    {
        var position = player.transform.position;
        Vector3 newCameraPosition = new Vector2(position.x, position.z);
        transform.position = new Vector3(newCameraPosition.x, newCameraPosition.y, transform.position.z);
    }
    
}
