using UnityEngine;
using System;
using System.Collections;

public class SCR_PlayerController : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Reference to the Game Manager script, this contains score and life values.")]
    public SCR_GameManager gameManager;
    [Tooltip("Reference to the spawn location of the player, was planned to be used to reset the level after death.")]
    public Transform spawnLocation;

    [Header("Editable Values")]
    [Tooltip("The value at which the player moves at. As of default, set at 2f.")]
    public float playerSpeed = 2.0f;
    [Tooltip("This is how long the power pill is active before the AI return to their normal behaviours.")]
    public int powerPillActiveTime = 5;
    [SerializeField]
    [Tooltip("This locally references the character controller on the player. Used for all movement.")]
    private CharacterController controller;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        gameManager = gameManager.gameObject.GetComponent<SCR_GameManager>();
        spawnLocation = GetComponent<Transform>();
    }

    void Update()
    {
        PlayerMovement();
    }

    /// <Summary> This is the main character movement function.
    /// <Description>
    /// It takes in the Input from the mouse and normalises the the vector (to stop movement speed increasing when travelling along both axis).
    /// Then the function uses CharacterController.Move to move the player. This is then timesed by Time.deltaTime to stop intrusion by framerate and the players speed.
    /// </Description>
    void PlayerMovement()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        controller.Move(move * Time.deltaTime * playerSpeed);
    }

    /// <Summary> This is the trigger detection of the player.
    /// <Description>
    /// This function looks for multiple different parameters. Picking up the power pill, normal pill pickups and checking whether the player
    /// is hitting the ghosts and whether the powerpill is active whilst this is happening. A coroutine is used to ensure the powerpill only lasts
    /// for a certain amount of time, this is editable within the inspector.
    /// </Description>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Power Pill"))
        {
            gameManager.playerScore++;
            gameManager.powerpillActive = true;
            StartCoroutine(PowerPillLength());
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Pill"))
        {
            gameManager.playerScore++;
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Ghost") && !gameManager.powerpillActive)
        {
            gameManager.playerLives--;
            this.transform.position = spawnLocation.transform.position;
        }

        else if(other.CompareTag("Ghost") && gameManager.powerpillActive)
        {
            Destroy(other.gameObject);
            gameManager.playerScore += 20;
        }
    }

    IEnumerator PowerPillLength()
    {
        yield return new WaitForSeconds(powerPillActiveTime);
        gameManager.powerpillActive = false;
    }

}
