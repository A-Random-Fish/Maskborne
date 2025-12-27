using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator WolfClawAnim;

    Vector2 movement;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rollSpeed = 1f;
    [SerializeField] float rollDuration;
    [SerializeField] float wolfAbilityOneCooldown;
    [SerializeField] float wolfAbilityTwoCooldown;
    [SerializeField] float abilityThreeCooldown;

    public bool canMove;

    GameObject CursorAimer;

    public string maskEquipped;

    public bool invulnerable = false;
    bool rotStop = false;
    bool swapping;

    [SerializeField] GameObject maskWheel;

    [Header("Inventory and Shop")]
    public bool canInteract;
    public string interactType;
    [SerializeField] Inventory inv;

    [Header("Moneys")]
    public int souls;

    [Header("Snail Mask")]
    [SerializeField] GameObject shellBoomerang;
    [SerializeField] Transform boomerangSpawnLoc;
    [SerializeField] GameObject snailShell;
    float snailAbilityTwoCooldown;

    public bool snailAbilityOneActive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //Grabs the Rigidbody2D without having to place it into the script
        CursorAimer = GameObject.Find("CursorDirection");
        WolfClawAnim = GameObject.Find("ClawArc").GetComponent<Animator>();
    }

    void Update()
    {
        if (!rotStop)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            CursorAimer.transform.rotation = rotation;
        }
        // JACOB I JUST MADE IT SO IT STOPS ROTATING THE ARC WHEN IT SWINGS DONT WORRY!

        //Timers:
        rollDuration -= Time.deltaTime;
        wolfAbilityOneCooldown -= Time.deltaTime;
        wolfAbilityTwoCooldown -= Time.deltaTime;
        snailAbilityTwoCooldown -= Time.deltaTime;

        //Wolf ability one (dodge)
        if (rollDuration > 0f)
        {
            invulnerable = true;
            rollSpeed = 4f;
        }
        else if (snailAbilityTwoCooldown > 9)
        {
            invulnerable = true;
            rollSpeed = 1f;
        }
        else
        {
            invulnerable = false;
            rollSpeed = 1f;
        }

        //Wolf ability two (rotStop disabled)
        if (wolfAbilityOneCooldown < 0f)
        {
            rotStop = false;
        }

        //swapping menu
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

    private void FixedUpdate() //Movement for the player
    {
        if (canMove)
            rb.linearVelocity = movement * moveSpeed * rollSpeed;
        else
            rb.linearVelocity = Vector2.zero;
    }

    public void Move(InputAction.CallbackContext context) //Checks for input from the movement keys (WASD)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void Interact(InputAction.CallbackContext context) //Checks for input from the interaction button 'E' and acts on it.
    {
        if (context.performed && canInteract)
        {
            if (interactType == "Shop") //Checks if the 'E' button is interacting with the shop trigger.
            {
                inv.InventoryDisplay(!inv.showInventory); //Displays the UI for the masks.
            }
        }
    }

    public void Ability1(InputAction.CallbackContext context)
    {
        if (context.performed && !swapping)
        {
            switch (maskEquipped)
            {
                case "WolfMask":
                    if (wolfAbilityOneCooldown < 0f)
                    {
                        rotStop = true;
                        wolfAbilityOneCooldown = 0.5f;
                        WolfClawAnim.SetBool("Active", true);
                    }
                    break;
                case "FerretMask":
                    Console.WriteLine("");
                    break;
                case "SnailMask":
                    if (snailAbilityOneActive)
                    {
                        snailAbilityOneActive = false;
                        Instantiate(shellBoomerang, boomerangSpawnLoc.position, Quaternion.identity);
                    }
                    break;
                case "EelMask":
                    Console.WriteLine("");
                    break;
                case "CrowMask":
                    Console.WriteLine("");
                    break;
            }
        }
    }

    public void Ability2(InputAction.CallbackContext context)
    {
        if (context.performed && !swapping)
        {
            switch (maskEquipped)
            {
                case "WolfMask":
                    if (wolfAbilityTwoCooldown < 0f)
                    {
                        wolfAbilityTwoCooldown = 1f;
                        rollDuration = 0.2f;
                    }
                    break;
                case "FerretMask":
                    Console.WriteLine("");
                    break;
                case "SnailMask":
                    if (snailAbilityTwoCooldown < 0f)
                    {
                        snailAbilityTwoCooldown = 10f;
                        invulnerable = true;
                        canMove = false;
                        Instantiate(snailShell, this.gameObject.transform.position, Quaternion.identity);
                    }
                    break;
                case "CrowMask":
                    Console.WriteLine("");
                    break;
                case "EelMask":
                    Console.WriteLine("");
                    break;

            }
        }
    }

    public void Ability3(InputAction.CallbackContext context)
    {
        if (context.performed && !swapping)
        {
            switch (maskEquipped)
            {
                case "WolfMask":
                    Console.WriteLine("");
                    break;
                case "FerretMask":
                    Console.WriteLine("");
                    break;
                case "SnailMask":
                    Console.WriteLine("");
                    break;
                case "EelMask":
                    Console.WriteLine("");
                    break;
                case "CrowMask":
                    Console.WriteLine("");
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
