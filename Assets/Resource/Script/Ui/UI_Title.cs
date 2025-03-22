using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI_Title : MonoBehaviour
{
    public GameObject OptionWindow;//�ɼ�â ������Ʈ
    public GameObject Credits;//ũ����â ������Ʈ

    bool isCredit = false;

    public void Start()
    {
        OptionWindow.gameObject.SetActive(false);
    }

    public void OnBtnGoToLoading()
    {
        Shared.SceneMgr.ChangeScene(eSCENE.eSCENE_TEST);
    }


    public void OnBtnOpenOptionWindows()//�ɼ�â ����
    {
        OptionWindow.gameObject.SetActive(true);
    }
    public void OnBtnCloseOptionWindows()//�ɼ�â �ݱ�
    {
        OptionWindow.gameObject.SetActive(false);
    }

    public void OnBtnOpenCreaditWindows()//ũ���� �¿���
    {
        if(isCredit)
        {
            Credits.gameObject.SetActive(false);
            isCredit = false;
        }
        else
        {
            Credits.gameObject.SetActive(true);
            isCredit = true;
        }
            
    }

    public void OnBtnExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // �����Ϳ��� ����
#else
        Application.Quit(); // ����� ���ӿ��� ����
#endif
    }

}