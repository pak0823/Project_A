using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Title : MonoBehaviour
{
    public void Start()
    {
        //StartCoroutine("INextScene");
    }

    //IEnumerator INextScene()
    //{
    //    yield return new WaitForSeconds(3f);

    //    OnBtnTitle();
    //}
    public void OnBtnTitle()// ����Ƽ�� ������ �� On~
    {
        Shared.SceneMgr.ChangeScene(eSCENE.eSCEME_TEST);
    }
}