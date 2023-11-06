using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullletController : MonoBehaviour
{
    [SerializeField] private GameObject spaceShip;
    [SerializeField] private GameObject bulletPrefab;
    private Transform spaceshipTransform;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private float speed = 5f;
    private bool shooting = false;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spaceshipTransform = spaceShip.GetComponent<Transform>();
        coll = GetComponent<BoxCollider2D>();
        transform.position = spaceshipTransform.position;
    }


    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {   
            shooting = true;
            rb.velocity = new Vector2(0f, speed);
        }
        if (!shooting) {
            spaceshipTransform = spaceShip.GetComponent<Transform>();
            transform.position = spaceshipTransform.position;
        }

        if(transform.position.y >= 5) {
            shooting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
      if (collision.gameObject.CompareTag("Asteroid")) {
            shooting = false;
        }
    }


       
}
