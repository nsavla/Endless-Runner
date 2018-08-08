using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed;
    public float increment;
    public float maxY;
    public float minY;

    private Vector2 targetPos;

    public int health;

    public GameObject moveEffect;
    public Animator camAnim;
    public Text healthDisplay;

    public GameObject runningSound;
    public GameObject spawner;
    public GameObject restartDisplay;
    public GameObject highScoreDisplay;
    public GameObject highScoreText;
    public GameObject ScoreManager;

    private void Start()
    {
        targetPos = new Vector2(-3.45f, -2f);
    }

    private void Update()
    {

        if (health <= 0) {
            spawner.SetActive(false);
            restartDisplay.SetActive(true);
            highScoreDisplay.SetActive(true);
            highScoreText.SetActive(true);
            ScoreManager.GetComponent<Score>().setHighScore();
           
            Destroy(gameObject);
        }

        healthDisplay.text = health.ToString();

      
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY) {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            Instantiate(runningSound, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY) {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            Instantiate(runningSound, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
        }
    }
}
