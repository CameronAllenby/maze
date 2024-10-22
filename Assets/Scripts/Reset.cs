using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    //replays the game
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(1);
    }
}
