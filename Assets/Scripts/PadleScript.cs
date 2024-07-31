using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadleScript : MonoBehaviour
{
    Vector2 pos;
    Vector2 startPos;
    [SerializeField]float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //‰EˆÚ“®
        if (Input.GetKey(KeyCode.D) && !IsRightEdge())
        {
            pos.x += moveSpeed * Time.deltaTime;
        }

        //¶ˆÚ“®
        if (Input.GetKey(KeyCode.A) && !IsLeftEdge())
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }
        
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

    public void Reset()
    {
        pos = startPos;
    }
}
