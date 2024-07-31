using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;//TextMeshPro�������ۂɕK�v

public class BallScript : MonoBehaviour
{
    //�ϐ��̐錾(�^�@�ϐ���)
    Vector2 pos;
    public int directionX;
    public float directionY;
    [SerializeField]public float movespeed;
    //[SerializeField]TextMeshProUGUI gameoverText;//TextMeshPro�̕ϐ��錾
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
        button = GameObject.Find("Canvas").transform.Find("Button").gameObject;//�{�^���擾

        startPos =transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //�΂�45���ɐi�܂���
        Move();

        //�E�̕ǂɓ�����������
        if (IsRightEdge())
        {
            directionX = -1;
        }
        //���̕ǂɓ�����������
        if (IsLeftEdge())
        {
            directionX = 1;
        }
        //��̕ǂɓ�����������
        if (IsUpperEdge())
        {
            directionY = -0.5f;
        }
        //���̕ǂɓ�����������
        if (IsLowerEdge())
        {
            directionX = 0;
            directionY = 0;
            //gameoverText.text = "GameOver";//TextMeshPro�Ńe�L�X�g�o��
            button.SetActive(true);//�{�^���o���̏���
            gameOver.SetActive(true);
        }
    }

    //update���œ��������\�b�h�Q

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

        //�p�h�����璵�˕Ԃ鏈��
        if (collision.gameObject.name == "Paddle")
        {
            directionY = 1;
        }

        //Block���璵�˕Ԃ鏈��
        if (collision.gameObject.tag == "Block")
        {
            directionX = -directionX;
            directionY = -directionY;
        }
        //���˕Ԃ鎞�ɉ����鏈��
       AudioManager.Instance.Play("Poyon");
    }

    public void Reset()
    {
        pos = startPos;
        directionX = 1;
        directionY = 1;
    }
}
