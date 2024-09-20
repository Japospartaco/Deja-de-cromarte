using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Vector3 _cameraPosition;

    private void Start()
	{


	}

    private void LateUpdate()
    {
        _cameraPosition = transform.position;
        _cameraPosition.x = _player.transform.position.x;
        _cameraPosition.y = _player.transform.position.y;
        transform.position = _cameraPosition;
    }
}