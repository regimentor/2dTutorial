using UnityEngine;

public class MovingBetweenWaypoints : MonoBehaviour
{

    [SerializeField] GameObject start;
    [SerializeField] GameObject end;
    [SerializeField] float speed = 1f;

    private int direction = -1;


    // Start is called before the first frame update
    void Start()
    {
    }


    void FixedUpdate()
    {


        if (direction < 0)
            if (Vector2.Distance(start.transform.position, transform.position) > 0.1f)
                transform.position = Vector2.MoveTowards(transform.position, start.transform.position, speed * Time.fixedDeltaTime);                
            else
                direction = 1;
        else   
            if (Vector2.Distance(end.transform.position, transform.position) > 0.1f)          
                transform.position = Vector2.MoveTowards(transform.position, end.transform.position, speed * Time.fixedDeltaTime);           
            else          
                direction = -1;
     
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
