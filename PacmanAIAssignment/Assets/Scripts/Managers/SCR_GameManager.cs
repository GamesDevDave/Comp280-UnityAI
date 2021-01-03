using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_GameManager : MonoBehaviour
{
    public bool powerpillActive = false;
    public int playerScore;

    public TMPro.TMP_Text scoreText;

    private void Update() {
        scoreText.text = playerScore.ToString();
    }
}
