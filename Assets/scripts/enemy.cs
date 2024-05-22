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
    Animator animator;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            areaAttackStart();
        }
    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            Defeated();
        }
        if (healthDrop >= 10 && canAreaAttack == true) //need to find a way to separate the colliders
        {
            areaAttackStart();
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
            playerScript.health -= areaDamage;
            playerHealthTxt.text = playerScript.health.ToString();
            Debug.Log(playerScript.health);
        }
    }

    public void areaAttackStart()
    {
        attackRange.enabled = true;
        animator.SetTrigger("areaAttack");
        prowler.Play();
        Debug.Log("poltergeist areaAttack");
    }

    public void areaAttackEnd()
    {
        attackRange.enabled = false;
        Debug.Log("areaAttack ended");
    }
}
