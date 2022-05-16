using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    [SerializeField] GameObject folowingObject;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(folowingObject.transform);
    }

}
