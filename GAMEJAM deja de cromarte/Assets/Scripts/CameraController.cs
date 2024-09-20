
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 cameraPosition;

    private void Start()
    {
        cameraPosition = transform.position;
        cameraPosition.x = player.transform.position.x;
        cameraPosition.y = player.transform.position.y;
        transform.position = cameraPosition;

    }

    private void Update()
    {
        cameraPosition = transform.position;
        cameraPosition.x = player.transform.position.x;
        cameraPosition.y = player.transform.position.y;
        transform.position = cameraPosition;
    }
}