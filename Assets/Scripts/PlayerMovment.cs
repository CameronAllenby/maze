using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //makes the direction to move
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //allows the player to move
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        //death screen
        if (col.gameObject.tag == "Corn")
        {
            SceneManager.LoadScene(0);
        }
    }
}

