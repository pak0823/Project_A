using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneMgr : MonoBehaviour
{
    //partial: 스크립트 기능을 부분적으로 나눈다.

    private void Awake()
    {
        Shared.SceneMgr = this;
        //이렇게 참조하여 사용하면 된다.

        DontDestroyOnLoad(this);
        //현재 씬을 제거하지 않는다.
    }
}
