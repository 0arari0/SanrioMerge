using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //ũ���� ��� ��� �������� [SerializeField]�� �Ѳ����� �����Ű�� �Ͱ� ����
public class Sound
{
    public string name; // �� �̸�
    public AudioClip clip; // ����� Ŭ��
}

public class SoundManager : MonoBehaviour
{
    #region singleton
    static public SoundManager instance;

    private void Awake()
    {
        if (instance == null) //soundManager ���� �Ҵ�
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //���� �ٲ� �� �ڽ��� �ı��Ǵ� ���� ����
        }
        else
            Destroy(this.gameObject);
    }
    #endregion singleton

    public Sound[] effectSounds;
    public Sound[] bgmSounds;

    public AudioSource bgmSource;
    public AudioSource[] sfxSources;
    public string[] playSoundName;

    void Start()
    {
        
    }

    void PlaySE(string _name)
    {
        for(int i=0; i<effectSounds.Length; i++)
        {
            if(_name == effectSounds[i].name)
            {
                for(int j=0; j<sfxSources.Length; j++)
                {
                    if()
                }
            }
        }
    }
}
