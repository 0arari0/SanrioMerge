using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public BgmAudio bgmAudio;
    public SfxAudio sfxAudio;
}
