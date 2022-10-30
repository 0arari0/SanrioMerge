using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    [Header("----------[ Audio ]")]
    public AudioSource bgmPlayer;
    public AudioClip sfxButton;

    bool isPlayingBgm = true;

    public void StartGame() //���ο��� ���ӽ��� ����
    {
        SceneManager.LoadScene(0);
    }
    public void GameExit() //���ο��� ��������
    {
        Application.Quit();
    }
    public void StopBGM()
    {
        isPlayingBgm = !isPlayingBgm; //else ���� ����

        if (isPlayingBgm)
            bgmPlayer.Play();
        else
            bgmPlayer.Stop();
    }

}
