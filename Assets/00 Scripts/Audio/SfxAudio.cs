using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SfxAudio : MonoBehaviour
{
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < clips.Length; i++)
            sfxDictionary.Add(clips[i].name, clips[i]);
    }

    /// <summary>
    /// ���ϴ� sfx�̸��� �Է��ϸ� ��������ִ� �Լ�
    /// </summary>
    public void Play(string sfxName)
    {
        // sfxDictionary�� �����Ϸ��� sfxName�� ��ϵ����� �ʴٸ� �ƹ��͵� �����ʰ� �Լ� ����
        if (!sfxDictionary.ContainsKey(sfxName))
            return;

        // sfx�� ��ȸ���̹Ƿ� PlayOneShot()�Լ��� ����
        audioSource.PlayOneShot(sfxDictionary[sfxName]);
    }

    public void Play(Sfx sfx)
    {
        // sfx�� ��ȸ���̹Ƿ� PlayOneShot()�Լ��� ����
        audioSource.PlayOneShot(clips[(int)sfx]);
    }

    public enum Sfx
    {
        LEVELUP, ATTACH, BUTTON, NEXT, OVER
    }

    public bool mute
    {
        get { return mute; }
        set
        {
            mute = value;
            audioSource.mute = mute;
        }
    }

    [SerializeField]
    AudioClip[] clips;

    AudioSource audioSource;
    Dictionary<string, AudioClip> sfxDictionary = new Dictionary<string, AudioClip>(); // key�� value�� ���� dictionary����
}
