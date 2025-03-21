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
        //StartCoroutine("INextScene");
        OptionWindow.gameObject.SetActive(false);
    }

    //IEnumerator INextScene()
    //{
    //    yield return new WaitForSeconds(3f);

    //    OnBtnTitle();
    //}
    public void OnBtnGoToLobby()// ����Ƽ�� ������ �� On~
    {
        Shared.SceneMgr.ChangeScene(eSCENE.eSCEME_TEST);
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