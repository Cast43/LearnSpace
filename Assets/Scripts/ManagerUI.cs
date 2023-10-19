using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public bool showInfo = false;
    public bool showConf = false;
    public SimulatorManager MngSimulator;
    public GameObject infoHUD;
    public GameObject configHUD;
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
    public void ToggleHUD(int hud)
    {
        if (hud == 2)
        {
            configHUD.GetComponent<Animator>().SetBool("Show", false);
            infoHUD.GetComponent<Animator>().SetBool("Show", true);
            ButtonsPanels.GetComponent<Animator>().SetBool("Show", true);
            showInfo = true;
            showConf = false;
        }
        if (hud == 1)
        {
            if (showConf == true)
            {
                HideAll();
            }
            else
            {
                infoHUD.GetComponent<Animator>().SetBool("Show", false);
                configHUD.GetComponent<Animator>().SetBool("Show", true);
                ButtonsPanels.GetComponent<Animator>().SetBool("Show", true);
                showConf = true;
                showInfo = false;
            }
        }
    }

    public void HideAll()
    {
        infoHUD.GetComponent<Animator>().SetBool("Show", false);
        configHUD.GetComponent<Animator>().SetBool("Show", false);
        ButtonsPanels.GetComponent<Animator>().SetBool("Show", false);
        showInfo = false;
        showConf = false;
    }
    public void ChangeInfo(DaoStar planet)
    {
        TitlePlanet.text = planet.name;
        infoPlanet.text = planet.infoPlanet;
    }
}
