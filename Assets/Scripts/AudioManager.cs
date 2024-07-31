using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Audio�̊Ǘ��N���X�B�V�[�����܂����ł��j������Ȃ��V���O���g���Ŏ�������
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
            //���ɃC���X�^���X������ꍇ�͎��g��j�󂷂�
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);//�V�[����J�ڂ��Ă��j������Ȃ�����
        instance = this;//�C���X�^���X�Ƃ��ĕێ�����

        //Resources/2D_SE���f�B���N�g������AudioClip��S�Ď擾����
        var audioClips = Resources.LoadAll<AudioClip> ("2D_SE");
        foreach ( var clip in audioClips )
        {
            _clips.Add(clip.name,clip);
        }
    }

    //�w�肵�����O�̉����t�@�C�����Đ�����
    public void Play(string clipName)
    {
        /*if (!_clips.ContainsKey(clipName))
        {
            //���݂��Ȃ����O���w�肵����G���[
            throw new Exception("Sound" + clipName + "is not defined");
        }*/

        //�w��̖��O��clip�ɍ����ւ��čĐ�����
        _audioSource.clip = _clips[clipName];
        _audioSource.Play();
    }

}
