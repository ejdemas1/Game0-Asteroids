using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private Sprite asteroidSprite;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private SpriteRenderer asteroidSpriteRenderer;

    public TextMeshProUGUI scoreText;

    private int score;

    private void Start()
    {
        asteroidSpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        StartCoroutine(CloneDelay());

    }

    void Update()
    {
        rb.velocity = new Vector2(0f, -3.0f);


        if (transform.position.y <= -4) {
            Destroy(gameObject);
            GameOver();
        }
        score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "Score: " + score;
    }
    private IEnumerator CloneDelay() {
        while(true) {
            yield return new WaitForSeconds(2.0f);
            float randomX = Random.Range(-4, 4);
            GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(randomX, 10, transform.position.z), Quaternion.identity);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Bullet")) {
            Destroy(gameObject);
            PlayerPrefs.SetInt("Score", score + 1); 

        }
        if (collision.gameObject.CompareTag("Spaceship")) {
            Destroy(gameObject);
            GameOver();
        }
    }

    private void GameOver() {
        SceneManager.LoadScene("Menu");
    }
    
}
