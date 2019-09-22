﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedure_Battle : Procedure
{
    protected override void OnProcedureEnter()
    {
        LoadBattle();
    }

    protected override void OnProcedureExit()
    {
        Camera.main.GetComponent<RTSCamera>().enabled = false;
    }

    private void LoadBattle()
    {
        RoundManager.GetInstance();
    }
}
