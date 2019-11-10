﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RoleInfoView : ViewBase<RoleInfoView>
{
    private Text roleName;
    private Text roleIdentity;
    private Text roleState;
    private Slider healthSlider;
    private Slider chakraSlider;
    private Text info;
    private Transform character;
    public void Open(Transform character, UnityAction onInit = null)
    {
        if (!isInit)
        {
            roleName = transform.Find("Content/RoleName").GetComponent<Text>();
            roleIdentity = transform.Find("Content/RoleIdentity").GetComponent<Text>();
            roleState = transform.Find("Content/RoleState").GetComponent<Text>();
            healthSlider = transform.Find("Content/Health").GetComponent<Slider>();
            chakraSlider = transform.Find("Content/Chakra").GetComponent<Slider>();
            info = transform.Find("Content/Info").GetComponent<Text>();

            var DB = Global.characterDataList.Find(d => d.roleEName == character.GetComponent<CharacterStatus>().roleEName);
            roleName.text = character.GetComponent<CharacterStatus>().roleCName.Replace(" ", "");
            roleIdentity.text = character.GetComponent<CharacterStatus>().identity;
            roleState.text = character.GetComponent<Unit>().UnitEnd ? "结束" : "待机";
            roleState.color = character.GetComponent<Unit>().UnitEnd ? Utils_Color.redTextColor : Utils_Color.purpleTextColor;
            healthSlider.maxValue = DB.attributes.Find(d => d.eName == "hp").ValueMax;
            healthSlider.value = DB.attributes.Find(d => d.eName == "hp").Value;
            chakraSlider.maxValue = DB.attributes.Find(d => d.eName == "mp").ValueMax;
            chakraSlider.value = DB.attributes.Find(d => d.eName == "mp").Value;
            info.text = healthSlider.GetComponent<Slider>().value + "\n" + chakraSlider.GetComponent<Slider>().value;
        }
        base.Open(onInit);
    }
}