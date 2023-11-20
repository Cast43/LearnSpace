using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public bool showHud = false;
    public int actualHud = 0;
    public int actualButton = 0;
    public SimulatorManager MngSimulator;
    public GameObject[] Huds;
    public Color[] colorsHud;
    public GameObject ButtonsPanels;
    public TMP_Text TitlePlanet;
    public TMP_Text infoPlanet;
    void Start()
    {

    }
    public void ChangeAllSizes(Slider slider)
    {
        MngSimulator.ChangeAllSizes(slider.value);
    }
    public void ChangeAllSpeed(Slider slider)
    {
        MngSimulator.ChangeAllSpeed(slider.value);
    }
    public void ChangeAllOrbitProportion(Slider slider)
    {
        MngSimulator.ChangeAllOrbitProportion(slider.value);
    }
    public void ChangeAllLines(Slider slider)
    {
        MngSimulator.ChangeAllLines(slider.value);
    }


    public void ChangeHud(int hud)
    {
        actualHud = hud;
    }
    public void ToggleHUD(int clickButton)
    {
        if (actualButton == clickButton)
        {
            actualButton = clickButton;
            if (!showHud)
            {
                HideAll();
                Huds[actualHud].GetComponent<Animator>().SetBool("Show", true);
                ButtonsPanels.GetComponent<Animator>().SetBool("Show", true);
                showHud = true;
                return;
            }
            else
            {
                HideAll();
                return;
            }
        }
        else
        {
            actualButton = clickButton;
            HideAll();
            Huds[actualHud].GetComponent<Animator>().SetBool("Show", true);
            ButtonsPanels.GetComponent<Animator>().SetBool("Show", true);
            showHud = true;
            return;
        }
    }
    public void HideAll()
    {
        for (int i = 0; i < Huds.Length; i++)
        {
            Huds[i].GetComponent<Animator>().SetBool("Show", false);
        }
        ButtonsPanels.GetComponent<Animator>().SetBool("Show", false);
        showHud = false;
    }
    public void ChangeColor(int color)
    {
        Huds[actualHud].GetComponent<Image>().color = colorsHud[color];
    }
    public void ChangeInfo(DaoStar planet)
    {
        TitlePlanet.text = planet.name;
        infoPlanet.text = planet.infoPlanet;
    }
}
