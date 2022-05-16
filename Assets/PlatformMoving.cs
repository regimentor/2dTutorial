using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{

    [SerializeField] GameObject start;
    [SerializeField] GameObject end;

    private int direction = -1;


    // Start is called before the first frame update
    void Start()
    {
    }


    void FixedUpdate()
    {
        if (direction < 0)
        {
            if (transform.position.x > start.transform.position.x)
            {
                transform.position = new Vector3(transform.position.x - .1f,
                    transform.position.y, transform.position.z);
            }
            else
            {
                direction = 1;
            }
        }
        else
        {
            if (transform.position.x < end.transform.position.x)
            {
                transform.position = new Vector3(transform.position.x + .1f,
                    transform.position.y, transform.position.z);
            }
            else
            {
                direction = -1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
