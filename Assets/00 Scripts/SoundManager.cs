using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    void Awake()
    {
        if (instance == null) //soundManager ���� �Ҵ�
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //���� �ٲ� �� �ڽ��� �ı��Ǵ� ���� ����
        }
        else
            Destroy(gameObject); // �� ������Ʈ�� �����ϴ� ������ �� �� instance�� �� �Ҵ��� �Ǳ� �����ε�
                                 // �̹� instance�� �Ҵ��� �Ǿ��ִٸ� ����Ŵ����� Ȱ��ȭ �Ǿ��ִٴ� ���̹Ƿ�
                                 // instance�� null�� �ƴ�. ���� ���� ������ �ش� ������Ʈ�� �������־�� ��

        audioSource = GetComponent<AudioSource>();

        // �ν����Ϳ��� �־��� audioClip���� bgm �� sfx dictionary�� �־������ν�
        // O(1)�ð��� ���ϴ� Ŭ���� �����ų �� �ֵ��� ��.
        // O(1)�ð��� �ڷḦ Ž���� �� ���� ���� �ӵ��� �����ִ� ��ǥ(�ð����⵵).
        for (int i = 0; i < bgmClips.Length; i++)
            bgmDictionary.Add(bgmClips[i].name, bgmClips[i]);
        for (int i = 0; i < sfxClips.Length; i++)
            sfxDictionary.Add(sfxClips[i].name, sfxClips[i]);
    }

    /// <summary>
    /// ���ϴ� bgm�̸��� �Է��ϸ� ��������ִ� �Լ�
    /// �ι�°���ڴ� ���� ����, ������ �� �ڵ����� loop��
    /// </summary>
    /// <param name="bgmName"></param>
    /// <param name="loop"></param>
    public void PlayBgm(string bgmName, bool loop = true)
    {
        // bgmDictionary�� �����Ϸ��� bgmName�� ��ϵ����� �ʴٸ� �ƹ��͵� �����ʰ� �Լ� ����
        if (!bgmDictionary.ContainsKey(bgmName))
            return;

        audioSource.loop = loop; // �������� ���� ���ڷ� ����
        audioSource.clip = bgmDictionary[bgmName];
        audioSource.Play();
    }

    /// <summary>
    /// �������� bgm����.
    /// �̹� �������� bgm�� ������ �ƹ��͵� �������� �ʰ� ����
    /// </summary>
    public void StopBgm()
    {
        if (!audioSource.isPlaying)
            return;

        audioSource.Stop();
    }

    /// <summary>
    /// ���ϴ� sfx�̸��� �Է��ϸ� ��������ִ� �Լ�
    /// </summary>
    public void PlaySfx(string sfxName)
    {
        // sfxDictionary�� �����Ϸ��� sfxName�� ��ϵ����� �ʴٸ� �ƹ��͵� �����ʰ� �Լ� ����
        if (!sfxDictionary.ContainsKey(sfxName))
            return;

        // sfx�� ��ȸ���̹Ƿ� PlayOneShot()�Լ��� ����
        audioSource.PlayOneShot(sfxDictionary[sfxName]);
    }

    [SerializeField]
    AudioClip[] bgmClips;
    [SerializeField]
    AudioClip[] sfxClips;

    AudioSource audioSource;
    Dictionary<string, AudioClip> bgmDictionary = new Dictionary<string, AudioClip>(); // key�� value�� ���� dictionary����
    Dictionary<string, AudioClip> sfxDictionary = new Dictionary<string, AudioClip>(); // key�� value�� ���� dictionary����
}
