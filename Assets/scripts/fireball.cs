using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public GameObject enemy;
    public enemy enemyScript;
    public GameObject player;
    public PlayerController playerScript;
    public Vector2 fireballStart;
    public GameObject clone;
    public Rigidbody2D rb;
    public GameObject playerHitbox;
    public float fireballDamage = 1;
    public TextMeshProUGUI playerHealthTxt;
    public AudioSource swoosh;

    // Start is called before the first frame update
    void Start()
    {
        enemyScript = enemy.GetComponent<enemy>();
        playerScript = player.GetComponent<PlayerController>();
        InvokeRepeating("Spawn", 3f, 3f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fireballStart = new Vector2(player.transform.position.x, .75f);
    }

    void Spawn()
    {
        gameObject.transform.position = fireballStart;
        playerScript.fireballDamageTaken = 0;
        Debug.Log("spawned");
        rb.velocity = new Vector2 (0, 0);
        StartCoroutine(fireballTimer());
    }
    IEnumerator fireballTimer()
    {
        yield return new WaitForSeconds(.5f);
        rb.velocity = new Vector2(0, -2f);
        swoosh.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject == playerHitbox)
        {
            if (playerScript.fireballDamageTaken == 0)
            {
                playerScript.health -= fireballDamage;
                playerHealthTxt.text = playerScript.health.ToString();
                playerScript.animator.SetBool("isDamaged", true);
                Debug.Log(playerScript.animator.GetBool("isDamaged"));
                Debug.Log(playerScript.health);
                playerScript.fireballDamageTaken = 1;
                Debug.Log(playerScript.fireballDamageTaken);
                StartCoroutine(endHurty());
            }
        }
    }

    IEnumerator endHurty()
    {
        yield return new WaitForSeconds(.5f);
        playerScript.animator.SetBool("isDamaged", false);
        Debug.Log("no more damaged");
    }
}
