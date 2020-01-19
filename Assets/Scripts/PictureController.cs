﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureController : MonoBehaviour
{
    [SerializeField] private Sprite heavyCavalery;
    [SerializeField] private Sprite landsknechte;
    [SerializeField] private Sprite suisse;
    private Image myImage;

    private void UnitClicked(int unitId)
    {
        Unit tempUnit = null;
        if (!BattleManager.isInputBlocked)
        {
            tempUnit = BattleManager.Instance.GetUnit(unitId);
            switch (tempUnit.GetUnitType())
            {
                case "Gendarmes":
                    myImage.sprite = heavyCavalery;
                    break;
                case "Landsknechte":
                    myImage.sprite = landsknechte;
                    break;
                case "Suisse":
                    myImage.sprite = suisse;
                    break;
                case "Imperial Cavalery":
                    myImage.sprite = heavyCavalery;
                    break;
            }
        }
    }

    private void OnDestroy()
    {
        EventManager.onUnitClicked -= UnitClicked;
    }

    private void OnEnable()
    {
        EventManager.onUnitClicked += UnitClicked;
    }

    void Start()
    {
        myImage = GetComponent<Image>();
    }
}
