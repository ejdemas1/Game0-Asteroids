using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;

    [SerializeField] private float moveSpeed = 7f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        PlayerPrefs.SetInt("Score", 0);
    }
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        sprite = GetComponent<SpriteRenderer>();
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }
}
