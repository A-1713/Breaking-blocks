using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    GameObject blocks;
    
    // Start is called before the first frame update
    void Start()
    {
        blocks = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
        //cntChildrenのカウントアップ処理
        blocks.GetComponent<BlocksScript>().cntChildren++;
    }
}
