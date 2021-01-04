using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_GameManager : MonoBehaviour
{

    /// <Summary> This is the script to keep all the data relating to the player within the game.
    /// <Description>
    /// Player Score and Player Lives are referenced in other scripts and displayed on the screen.
    /// </Description>

    public bool powerpillActive = false;
    public int playerScore;
    public int playerLives;

    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text livesText;

    private void Update() {
        scoreText.text = playerScore.ToString();
        livesText.text = playerLives.ToString();
    }
}
