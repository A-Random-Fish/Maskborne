using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rollSpeed = 1f;
    [SerializeField] float rollDuration;
    [SerializeField] float abilityOneCooldown;

    [SerializeField] int maskEquipped;
    bool invulnerable = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        rollDuration -= Time.deltaTime;
        abilityOneCooldown -= Time.deltaTime;

        if (rollDuration > 0f)
        {
            invulnerable = true;
            rollSpeed = 4f;
        }
        else
        {
            invulnerable = false;
            rollSpeed = 1f;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed * rollSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void Ability1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (maskEquipped)
            {
                case 1:
                    if (abilityOneCooldown < 0f)
                    {
                        abilityOneCooldown = 5f;
                        rollDuration = 0.2f;
                    }
                    break;
                case 2:
                    Console.WriteLine("Placeholder");
                    break;
                case 3:
                    Console.WriteLine("Placeholder");
                    break;

            }
        }
    }

    public void Ability2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (maskEquipped)
            {
                case 1:
                    Console.WriteLine("Placeholder");
                    break;
                case 2:
                    Console.WriteLine("Placeholder");
                    break;
                case 3:
                    Console.WriteLine("Placeholder");
                    break;

            }
        }
    }

    public void Ability3(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (maskEquipped)
            {
                case 1:
                    Console.WriteLine("Placeholder");
                    break;
                case 2:
                    Console.WriteLine("Placeholder");
                    break;
                case 3:
                    Console.WriteLine("Placeholder");
                    break;

            }
        }
    }
}
