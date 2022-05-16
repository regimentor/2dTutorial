using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{

    [SerializeField] private Text playerScoreUIText;
    private int collectableItemsCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            collectableItemsCount++;


            Animator collisionAnimator = collision.gameObject.GetComponent<Animator>();
            collisionAnimator.SetTrigger("destroy");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreUIText.text = "Score: " + collectableItemsCount;
    }
}
