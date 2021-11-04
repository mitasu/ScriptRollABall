using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 20;
    public Text ScoreText;
    public Text WinText;

    private Rigidbody rb;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        score = 0;
        SetCountText();
        
        WinText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0, moveVertical);
        
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);

            score = score + 1;

            SetCountText();
        }
    }

    void SetCountText()
    {
        ScoreText.text = "Count: " + score.ToString();

        if (score >= 12)
        {
            WinText.gameObject.SetActive(true);
        }
    }
    
    
}
