using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public int health;
    public Control control;
    public AudioSource damageTaken;
    public Text gameOver;
    public float wait = 0;
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Player").GetComponent<Control>();
        health = 3;
        damageTaken = gameObject.GetComponent<AudioSource>();
        gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            control.controllable = false;
            gameOver.enabled = true;
            wait += Time.deltaTime;
            if (wait >1)
            {
                GameObject rocket = GameObject.Find("Player");
                rocket.SetActive(false);
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemyAttack")
        {
            damageTaken.Play();
            health -= 1;
        }
        if (other.gameObject.tag == "wallLeft")
        {
            control.goLeft = false;
        }
        if (other.gameObject.tag == "wallRight")
        {
            control.goRight = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "wallLeft")
        {
            control.goLeft = true;
        }
        if (other.gameObject.tag == "wallRight")
        {
            control.goRight = true;
        }
    }
}