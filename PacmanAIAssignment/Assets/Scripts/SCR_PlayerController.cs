using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public SCR_GameManager gameManager;
    public float playerSpeed = 2.0f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        gameManager = gameManager.gameObject.GetComponent<SCR_GameManager>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        controller.Move(move * Time.deltaTime * playerSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerpill"))
        {

        }

        if(other.CompareTag("Pill"))
        {

        }

        if(other.CompareTag("Ghost") && !gameManager.powerpillActive)
        {
            SceneManager.LoadScene("SCN_Main");
        }
    }
}
