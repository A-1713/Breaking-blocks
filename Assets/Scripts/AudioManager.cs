using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Audioの管理クラス。シーンをまたいでも破棄されないシングルトンで実装する
    public static AudioManager instance;

    [SerializeField]private AudioSource _audioSource;
    private readonly Dictionary<string, AudioClip> _clips = new Dictionary<string, AudioClip>();

    public static AudioManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (null != instance)
        {
            //既にインスタンスがある場合は自身を破壊する
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);//シーンを遷移しても破棄されなくする
        instance = this;//インスタンスとして保持する

        //Resources/2D_SEをディレクトリ下のAudioClipを全て取得する
        var audioClips = Resources.LoadAll<AudioClip> ("2D_SE");
        foreach ( var clip in audioClips )
        {
            _clips.Add(clip.name,clip);
        }
    }

    //指定した名前の音声ファイルを再生する
    public void Play(string clipName)
    {
        /*if (!_clips.ContainsKey(clipName))
        {
            //存在しない名前を指定したらエラー
            throw new Exception("Sound" + clipName + "is not defined");
        }*/

        //指定の名前のclipに差し替えて再生する
        _audioSource.clip = _clips[clipName];
        _audioSource.Play();
    }

}
