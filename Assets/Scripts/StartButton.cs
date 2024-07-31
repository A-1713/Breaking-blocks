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
        //音が鳴り終わってから0.5sec後にメインシーンに移行する処理
        StartCoroutine(StartButton.DelayMethod(0.5f, () => {SceneManager.LoadScene("MainScene");}));
    }
}
