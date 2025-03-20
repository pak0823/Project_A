using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    �� ������ ����ϰ� �״�� ����ϸ� �ȴ�. ����ȸ�翡�� �̹� ������ �ڵ��̴�.
    ���� �� �߰� ���Ű� ���� �׷� ���� ���������� ����.
 
 */
public partial class SceneMgr : MonoBehaviour
{
    public eSCENE Scene = eSCENE.eSCENE_TITLE;

    public void ChangeScene(eSCENE _e, bool _Loading = false)//�Ű������� _�� �־ ����ϸ� �����Ͽ� ���� ����. �׳� ����ؼ� �ͼ�������
    {
        if (Scene == _e)
            return;


        switch (_e)
        {
            case eSCENE.eSCENE_TITLE:   //SceneManager �Լ� �������� int���� ����� ���������� ���� ���� ���ڿ��� �ۼ��Ѵ�. int���� ����ϰ� ������ ����
                SceneManager.LoadScene("TitleScene");
                break;
            case eSCENE.eSCENE_LOADING:
                SceneManager.LoadScene("LoadingScene");
                break;
            case eSCENE.eSCENE_STAGE:
                SceneManager.LoadScene("LoadingScene");
                break;
            case eSCENE.eSCEME_INGAME:
                SceneManager.LoadScene("LoadingScene");
                break;
            case eSCENE.eSCEME_TEST:
                SceneManager.LoadScene("TestScene");
                break;
            case eSCENE.eSCENE_END:
                SceneManager.LoadScene("End");
                break;
        }
    }
}
