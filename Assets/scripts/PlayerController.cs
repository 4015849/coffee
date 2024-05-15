using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    bool canMove = true;
    public GameObject swordHitbox;
    BoxCollider2D hitbox;
    public float health = 10;
    public GameObject gameOverMenu;
    public GameObject enemy;
    public float swordDamage = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        hitbox = swordHitbox.GetComponent<BoxCollider2D>();
        hitbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("horizontal", movementInput.x);
        animator.SetFloat("vertical", movementInput.y);
        animator.SetFloat("speed", movementInput.sqrMagnitude);

        if(movementInput.x == 1 || movementInput.x == -1 || movementInput.y == 1 || movementInput.y == -1)
        {
            animator.SetFloat("lastMoveX", movementInput.x);
            animator.SetFloat("lastMoveY", movementInput.y);
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            // If movement input is not 0, try to move
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));
                }

                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            } 
        }
        if (health <= 0)
        {
            Defeated();
        }
    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero) { 
        // Check for potential collisions
        int count = rb.Cast(
            direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
            movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
            castCollisions, // List of collisions to store the found collisions into after the Cast is finished
            moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset

        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
        }
        else
        {
            //can't move if there's no direction to move in
            return false;
        }

    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
        Debug.Log("fire");
    }

    public void LockMove()
    {
        canMove = false;
        hitbox.enabled = true;
        Debug.Log("locked");
    }

    public void UnlockMove()
    {
        canMove = true;
        hitbox.enabled = false;
        Debug.Log("unlocked");
    }

    public void Defeated()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // deal damage to the enemy
            enemy enemy = collision.gameObject.GetComponent<enemy>();
            if (enemy != null)
            {
                enemy.health -= swordDamage;
                Debug.Log(enemy.health);
            }
        }
    }
}
