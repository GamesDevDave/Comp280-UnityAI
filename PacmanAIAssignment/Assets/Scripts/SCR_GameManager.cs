using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_GameManager : MonoBehaviour
{

    public bool powerpillActive = false;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
}
