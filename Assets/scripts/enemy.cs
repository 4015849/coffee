using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health = 100;
    public GameObject virtualCamera;
    public CinemachineVirtualCamera cam;
    public GameObject player;
    public Animator animator;
    public GameObject areaAttack;
    CircleCollider2D attackRange;
    public float areaDamage = 1;
    public GameObject playerHitbox;
    public PlayerController playerScript;
    public TextMeshProUGUI playerHealthTxt;
    public GameObject winMenu;
    public AudioSource prowler;
    public float healthDrop = 0;
    public bool canAreaAttack = false;
    public GameObject playerDetector;
    public Vector2 minX = new Vector2 (-1.2f, 0.5f);
    public Vector2 maxX = new Vector2 (1.2f, 0.5f);
    public bool canMove = true;
    public float moveSpeed = .5f;
    public Rigidbody2D rb;
    private float direction = 1;
    private float currentPosition = 0.5f;
    public GameObject fireball;
    public Vector2 fireballStart;


    // Start is called before the first frame update
    void Start()
    {
        cam = virtualCamera.GetComponent<CinemachineVirtualCamera>();
        animator = GetComponent<Animator>();
        attackRange = areaAttack.GetComponent<CircleCollider2D>();
        attackRange.enabled = false;
        Debug.Log(health);
        playerScript = player.GetComponent<PlayerController>();
        prowler = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("isDamaged", false);
        animator.SetBool("isAngry", false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    areaAttackStart();
        //}

        //movement setup

        if (canMove == true)
        {
            currentPosition = Mathf.Clamp01(currentPosition + moveSpeed * Time.deltaTime * direction);
            if(direction == 1 && currentPosition > 0.99) direction = -1;
            if(direction == -1 && currentPosition < 0.01) direction = 1;

            transform.position = Vector3.Lerp(maxX, minX, currentPosition);
        }
        fireballStart = new Vector2(player.transform.position.x, 1.5f);
    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            Defeated();
        }
        if (healthDrop >= 5 && canAreaAttack == true)
        {
            StartCoroutine(attackWait());
            healthDrop = 0;
            Debug.Log(healthDrop);
        }
    }
    public void Defeated()
    {
        gameObject.SetActive(false);
        winMenu.SetActive(true);
        Time.timeScale = 0;
        //cam.m_Priority = 2;
        Debug.Log("defeated");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject == playerHitbox)
        {
            if(playerScript.damageTaken == 0)
            {
                playerScript.health -= areaDamage;
                playerHealthTxt.text = playerScript.health.ToString();
                playerScript.animator.SetBool("isDamaged", true);
                Debug.Log(playerScript.animator.GetBool("isDamaged"));
                Debug.Log(playerScript.health);
                playerScript.damageTaken = 1;
                Debug.Log(playerScript.damageTaken);
            }
        }
    }

    public void areaAttackStart()
    {
        animator.SetBool("isAngry", false);
        attackRange.enabled = true;
        animator.SetTrigger("areaAttack");
        prowler.Play();
        Debug.Log("poltergeist areaAttack");
    }

    public void areaAttackEnd()
    {
        attackRange.enabled = false;
        canAreaAttack = false;
        canMove = true;
        playerScript.animator.SetBool("isDamaged", false);
        playerScript.damageTaken = 0;
        Debug.Log(playerScript.animator.GetBool("isDamaged"));
        Debug.Log("areaAttack ended");
        Debug.Log(playerScript.damageTaken);
    }

    IEnumerator attackWait()
    {
        canMove = false;
        animator.SetBool("isAngry", true);
        yield return new WaitForSeconds(1f);
        areaAttackStart();
    }

    IEnumerator fireballTimer()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(fireballAttack());
    }

    IEnumerator fireballAttack()
    {
        GameObject clone;
        clone = Instantiate(fireball);
        clone.transform.position = fireballStart;
        yield return new WaitForSeconds(1);
        Destroy(clone);
    }
}
