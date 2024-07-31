using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContinueScript : MonoBehaviour
{
    GameObject ball;
    GameObject paddle;
    GameObject blocks;
    GameObject gameOver;
    GameObject gameClear;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        paddle = GameObject.Find("Paddle");
        blocks = GameObject.Find("Blocks");
        gameOver = transform.parent.Find("GameOver").gameObject;
        gameClear = transform.parent.Find("GameClear").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        ball.GetComponent<BallScript>().Reset();
        paddle.GetComponent<PadleScript>().Reset();
        blocks.GetComponent<BlocksScript>().Reset();
        this.gameObject.SetActive(false);
        gameOver.SetActive(false);
        gameClear.SetActive(false);
    }
}
