using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public ManagerStars managerStars;
    public void ChangeAllSizes(Slider slider)
    {
        for (int i = 0; i < managerStars.planets.Count; i++)
        {
            managerStars.ChangePlanetSize(managerStars.planets[i], slider.value);
        }
    }
    public void ChangeAllSpeed(Slider slider)
    {
        for (int i = 0; i < managerStars.planets.Count; i++)
        {
            managerStars.ChangeOrbitSpeed(managerStars.planets[i], slider.value);
        }
    }
    public void ChangeAllOrbitProportion(Slider slider)
    {
        for (int i = 0; i < managerStars.planets.Count; i++)
        {
            managerStars.ChangeOrbitProportion(managerStars.planets[i], slider.value);
        }
    }
    public void ChangeAllLines(Slider slider)
    {
        for (int i = 0; i < managerStars.planets.Count; i++)
        {
            managerStars.ChangeLineSize(managerStars.planets[i], slider.value);
        }
    }
}
