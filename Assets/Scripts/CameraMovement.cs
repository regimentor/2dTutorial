using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x,
            playerTransform.position.y, transform.position.z);
    }
}
