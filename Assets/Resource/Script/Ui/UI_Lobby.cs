using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UI_Lobby : MonoBehaviour
{
    public GameObject backBtn;
    public GameObject OptionWindow;

    bool isOptionShow = false;

    void Start()
    {
        
    }

    public void OnBtnOptionWindows()//�ɼ�â �ݱ�
    {
        if(isOptionShow)
        {
            OptionWindow.gameObject.SetActive(false);
            isOptionShow = false;
        } 
        else
        {
            OptionWindow.gameObject.SetActive(true);
            isOptionShow = true;
        }
            
    }

    public void OnBtnGoInGame()
    {
        Shared.SceneMgr.ChangeScene(eSCENE.eSCENE_TEST);
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
