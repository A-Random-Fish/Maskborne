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
    [SerializeField] float abilityTwoCooldown;
    [SerializeField] float abilityThreeCooldown;

    public int maskEquipped;
    bool invulnerable = false;

    bool swapping;

    [SerializeField] GameObject maskWheel;

    [Header("Inventory and Shop")]
    public bool canInteract;
    public string interactType;
    [SerializeField] Inventory inv;

    [Header("Moneys")]
    public int souls;

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

        if (swapping)
        {
            Time.timeScale = 0.1f;
            maskWheel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            maskWheel.SetActive(false);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed && canInteract)
        {
            if (interactType == "Shop")
            {
                inv.InventoryDisplay(!inv.showInventory);
            }
        }
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
                    Console.WriteLine("Mask 2 Ability 1");
                    break;
                case 3:
                    Console.WriteLine("Mask 3 Ability 1");
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
                    Console.WriteLine("Mask 1 Ability 2");
                    break;
                case 2:
                    Console.WriteLine("Mask 2 Ability 2");
                    break;
                case 3:
                    Console.WriteLine("Mask 3 Ability 3");
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
                    Console.WriteLine("Mask 1 Ability 3");
                    break;
                case 2:
                    Console.WriteLine("Mask 2 Ability 3");
                    break;
                case 3:
                    Console.WriteLine("Mask 3 Ability 3");
                    break;

            }
        }
    }

    public void Swap(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            swapping = true;
        }

        if (context.canceled)
        {
            swapping = false;
        }
    }

    //Interact Stuff

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            canInteract = true;
            interactType = other.gameObject.tag;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            canInteract = false;
            interactType = "None";
            inv.InventoryDisplay(false);
        }
    }
}
