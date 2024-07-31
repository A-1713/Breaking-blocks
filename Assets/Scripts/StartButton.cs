using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StartButton : MonoBehaviour
{
    public static IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(2.5f);
        action();
    }

    
    public void OnClickStartButton()
    {
        AudioManager.Instance.Play("Vanishing");
        //������I����Ă���0.5sec��Ƀ��C���V�[���Ɉڍs���鏈��
        StartCoroutine(StartButton.DelayMethod(0.5f, () => {SceneManager.LoadScene("MainScene");}));
    }
}
