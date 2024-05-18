using Cinemachine;
using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        cam = virtualCamera.GetComponent<CinemachineVirtualCamera>();
        animator = GetComponent<Animator>();
        attackRange = areaAttack.GetComponent<CircleCollider2D>();
        attackRange.enabled = false;
        Debug.Log(health);
        playerScript = player.GetComponent<PlayerController>();
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
    }
    public void Defeated()
    {
        gameObject.SetActive(false);
        cam.m_Priority = 2;
        Debug.Log("defeated");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject == playerHitbox)
        {
                playerScript.health -= areaDamage;
                Debug.Log(playerScript.health);
        }
    }

    public void areaAttackStart()
    {
        attackRange.enabled = true;
        animator.SetTrigger("areaAttack");
        Debug.Log("poltergeist areaAttack");
    }

    public void areaAttackEnd()
    {
        attackRange.enabled = false;
        Debug.Log("areaAttack ended");
    }
}
