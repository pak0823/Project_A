using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneMgr : MonoBehaviour
{
    //partial: ��ũ��Ʈ ����� �κ������� ����

    private void Awake()
    {
        Shared.SceneMgr = this;
        //�̷��� �����Ͽ� ���

        DontDestroyOnLoad(this);
        //���� ���� �������� ����
    }
}
