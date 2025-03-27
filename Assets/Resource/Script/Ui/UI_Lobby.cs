using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UI_Lobby : UIBase
{
    public void OnBtnGoInGame() => ChangeScene(eSCENE.eSCENE_STAGE);
    public void OnBtnGoShop() => ChangeScene(eSCENE.eSCENE_SHOP);
    public void OnBtnGoRepair() => ChangeScene(eSCENE.eSCENE_REPAIR);
    public void OnBtnGoPractice() => ChangeScene(eSCENE.eSCENE_TEST);
    public void OnBtnGoTitle() => ChangeScene(eSCENE.eSCENE_TITLE);
}

