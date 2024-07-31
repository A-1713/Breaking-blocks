using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;//TextMeshProを扱う際に必要

public class BlocksScript : MonoBehaviour
{
    public int cntChildren;
    //[SerializeField] TextMeshProUGUI gameclearText;//TextMeshProの変数宣言
    GameObject ball;
    GameObject button;
    List<GameObject> children = new List<GameObject> ();
    GameObject gameClear;

    // Start is called before the first frame update
    void Start()
    {
        cntChildren = 0;
        ball = GameObject.Find("Ball");
        button = GameObject.Find("Canvas").transform.Find("Button").gameObject;
        gameClear = GameObject.Find("Canvas").transform.Find("GameClear").gameObject;

        for (int index = 0; index < transform.childCount; index++)
        {
            children.Add(transform.GetChild(index).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cntChildren == transform.childCount)
        {
            //gameclearText.text = "GameClear";//TextMeshProでテキスト出力
            ball.GetComponent<BallScript>().directionX = 0;
            ball.GetComponent<BallScript>().directionY = 0;
            button.SetActive(true);//ボタン出現の処理
            gameClear.SetActive(true);
        }
    }

    public void Reset()
    {
        cntChildren = 0;
        foreach(GameObject child in children)
        {
            child.SetActive(true);
        }
    }
}
