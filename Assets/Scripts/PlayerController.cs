using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator WolfClawAnim;

    Vector2 movement;
    [SerializeField] float moveSpeed = 5f;

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

    [Header("Wolf Mask")]
    [SerializeField] float wolfAbilityOneCooldown;
    [SerializeField] float wolfAbilityTwoCooldown;
    [SerializeField] float rollSpeed = 1f;
    [SerializeField] float rollDuration;

    [Header("Snail Mask")]
    [SerializeField] GameObject shellBoomerang;
    [SerializeField] Transform boomerangSpawnLoc;
    [SerializeField] GameObject snailShell;
    float snailAbilityTwoCooldown;

    public bool snailAbilityOneActive = true;

    [Header("GourdMask")]
    [SerializeField] GameObject gourdBoulder;
    [SerializeField] GameObject JackOFlames;
    float gourdAbilityOneCooldown;
    float gourdAbilityTwoCooldown;

    //KB
    bool KBActive;
    public float KBDuration;

    [Header("Player Sprites")]
    [SerializeField] Sprite wolfMaskUp;
    [SerializeField] Sprite wolfMaskDown;
    [SerializeField] Sprite gourdMaskUp;
    [SerializeField] Sprite gourdMaskDown;
    [SerializeField] Sprite snailMaskUp;
    [SerializeField] Sprite snailMaskDown;

    [Header("UI")]
    [SerializeField] Image ability1;
    [SerializeField] Image ability2;
    [SerializeField] TextMeshProUGUI ability1text;
    [SerializeField] TextMeshProUGUI ability2text;

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

        //Timers:
        rollDuration -= Time.deltaTime;
        wolfAbilityOneCooldown -= Time.deltaTime;
        wolfAbilityTwoCooldown -= Time.deltaTime;
        snailAbilityTwoCooldown -= Time.deltaTime;
        gourdAbilityOneCooldown -= Time.deltaTime;
        gourdAbilityTwoCooldown -= Time.deltaTime;

        //Damage negation thingies lol
        if (rollDuration > 0f) //Wolf mask dodge roll
        {
            invulnerable = true;
            rollSpeed = 4f;
        }
        else if (snailAbilityTwoCooldown > 3.84f) //Snail mask shell ability
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

        //Player Sprite Changing
        if (maskEquipped == "WolfMask")
        {
            if (movement.y > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = wolfMaskUp;
            }
            else if (movement.y < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = wolfMaskDown;
            }

            ability1.sprite = Resources.Load("WolfAbilityIcon1", typeof (Sprite)) as Sprite;
            ability2.sprite = Resources.Load("WolfAbilityIcon2", typeof (Sprite)) as Sprite;

            if (wolfAbilityOneCooldown <= 0)
            {
                ability1text.text = "Ready";
            }
            else
            {
                ability1text.text = "Charging...";
            }

            if (wolfAbilityTwoCooldown <= 0)
            {
                ability2text.text = "Ready";
            }
            else
            {
                ability2text.text = "Charging...";
            }
        }

        if (maskEquipped == "GourdMask")
        {
            if (movement.y > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = gourdMaskUp;
            }
            else if (movement.y < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = gourdMaskDown;
            }

            ability1.sprite = Resources.Load("PumpkinAbilityIcon1", typeof (Sprite)) as Sprite;
            ability2.sprite = Resources.Load("PumpkinAbilityIcon2", typeof (Sprite)) as Sprite;

            if (gourdAbilityOneCooldown <= 0)
            {
                ability1text.text = "Ready";
            }
            else
            {
                ability1text.text = "Charging...";
            }

            if (gourdAbilityTwoCooldown <= 0)
            {
                ability2text.text = "Ready";
            }
            else
            {
                ability2text.text = "Charging...";
            }
        }

        if (maskEquipped == "SnailMask")
        {
            if (movement.y > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = snailMaskUp;
            }
            else if (movement.y < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = snailMaskDown;
            }

            ability1.sprite = Resources.Load("SnailAbilityIcon1", typeof (Sprite)) as Sprite;
            ability2.sprite = Resources.Load("SnailAbilityIcon2", typeof (Sprite)) as Sprite;

            if (snailAbilityOneActive)
            {
                ability1text.text = "Ready";
            }
            else
            {
                ability1text.text = "Charging...";
            }

            if (snailAbilityTwoCooldown <= 0)
            {
                ability2text.text = "Ready";
            }
            else
            {
                ability2text.text = "Charging...";
            }
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
                case "WolfMask": //Performs the wolf claw ability, also makes sure the rotation stops of the aimer.
                    if (wolfAbilityOneCooldown < 0f)
                    {
                        rotStop = true;
                        wolfAbilityOneCooldown = 0.5f;
                        WolfClawAnim.SetBool("Active", true);
                    }
                    break;
                case "GourdMask":
                    if (gourdAbilityOneCooldown < 0f)
                    {
                        gourdAbilityOneCooldown = 1f;
                        Instantiate(gourdBoulder, boomerangSpawnLoc.position, Quaternion.identity);
                    }
                    break;
                case "SnailMask":
                    if (snailAbilityOneActive)
                    {
                        snailAbilityOneActive = false;
                        Instantiate(shellBoomerang, boomerangSpawnLoc.position, Quaternion.identity);
                    }
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
                case "WolfMask": //Ability to do a quick dash with a cooldown.
                    if (wolfAbilityTwoCooldown < 0f)
                    {
                        wolfAbilityTwoCooldown = 1f;
                        rollDuration = 0.2f;
                    }
                    break;
                case "GourdMask":
                    if (gourdAbilityTwoCooldown < 0f)
                    {
                        gourdAbilityTwoCooldown = 5f;
                        Instantiate(JackOFlames, boomerangSpawnLoc.position, Quaternion.identity);
                    }
                    break;
                case "SnailMask":
                    if (snailAbilityTwoCooldown < 0f)
                    {
                        snailAbilityTwoCooldown = 5f;
                        invulnerable = true;
                        canMove = false;
                        Instantiate(snailShell, this.gameObject.transform.position, Quaternion.identity);
                    }
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

    public IEnumerator<object> Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
            float timer = 0;

            while (knockbackDuration > timer)
            {
                canMove = false;
                timer += Time.deltaTime;
                Vector2 direction = (obj.transform.position - this.transform.position).normalized;
                rb.AddForce(-direction * knockbackPower);
            }

            rb.linearVelocity = Vector2.zero;
            yield return 0;
            canMove = true;
    }
}
