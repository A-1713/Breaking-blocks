using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;//TextMeshProを扱う際に必要

public class BallScript : MonoBehaviour
{
    //変数の宣言(型　変数名)
    Vector2 pos;
    public int directionX;
    public float directionY;
    [SerializeField]public float movespeed;
    //[SerializeField]TextMeshProUGUI gameoverText;//TextMeshProの変数宣言
    GameObject button;
    Vector2 startPos;
    GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        directionX = 1;
        directionY = 0.5f;
        gameOver = GameObject.Find("Canvas").transform.Find("GameOver").gameObject;
        button = GameObject.Find("Canvas").transform.Find("Button").gameObject;//ボタン取得

        startPos =transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //斜め45°に進ませる
        Move();

        //右の壁に当たった処理
        if (IsRightEdge())
        {
            directionX = -1;
        }
        //左の壁に当たった処理
        if (IsLeftEdge())
        {
            directionX = 1;
        }
        //上の壁に当たった処理
        if (IsUpperEdge())
        {
            directionY = -0.5f;
        }
        //下の壁に当たった処理
        if (IsLowerEdge())
        {
            directionX = 0;
            directionY = 0;
            //gameoverText.text = "GameOver";//TextMeshProでテキスト出力
            button.SetActive(true);//ボタン出現の処理
            gameOver.SetActive(true);
        }
    }

    //update内で動かすメソッド群

    private void Move()
    {
        pos.x += movespeed * directionX * Time.deltaTime;
        pos.y += movespeed * directionY * Time.deltaTime;
        transform.position = pos;
    }

    private bool IsRightEdge()
    {
        return pos.x > 8.387;
    }

    private bool IsLeftEdge()
    {
        return pos.x < -8.387;
    }

    private bool IsUpperEdge()
    {
        return pos.y > 4.5;
    }

    private bool IsLowerEdge()
    {
        return pos.y < -4.5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //パドルから跳ね返る処理
        if (collision.gameObject.name == "Paddle")
        {
            directionY = 1;
        }

        //Blockから跳ね返る処理
        if (collision.gameObject.tag == "Block")
        {
            directionX = -directionX;
            directionY = -directionY;
        }
        //跳ね返る時に音が鳴る処理
       AudioManager.Instance.Play("Poyon");
    }

    public void Reset()
    {
        pos = startPos;
        directionX = 1;
        directionY = 1;
    }
}
