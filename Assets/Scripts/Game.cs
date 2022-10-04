using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private int scoreBlue;
    private int scoreRed;
    private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreBlue = 0;
        scoreRed = 0;
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="Floor")
        {
            if (collision.contacts[0].point.x<0)
            {
                scoreRed++;
                resetGame(false);
            }
            else
            {
                scoreBlue++;
                resetGame(true);
            }
           
            scoreText.text = scoreBlue.ToString()+":"+scoreRed.ToString();
            



        }
    }

    private void resetGame(bool isBlue)
    {
        int constant = 1;
        if (!isBlue)
            constant *= -1;

        Rigidbody playerBlue = GameObject.FindGameObjectWithTag("BluePlayer").GetComponent<Rigidbody>();
        playerBlue.transform.position = new Vector3(-6.9f, 1, 0);
        playerBlue.velocity = new Vector3(0, 0, 0);
        Rigidbody playerRed = GameObject.FindGameObjectWithTag("RedPlayer").GetComponent<Rigidbody>();
        playerRed.transform.position = new Vector3(6.9f, 1, 0);
        playerRed.velocity = new Vector3(0, 0, 0);
        Rigidbody gameBall = GameObject.FindGameObjectWithTag("GameBall").GetComponent<Rigidbody>();
        gameBall.transform.position = new Vector3(constant*-6.3f, 5.2f, 0);
        gameBall.velocity = new Vector3(0, 0, 0);
    }
    
}
