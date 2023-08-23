using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SimulatorManager : MonoBehaviour
{
    public GameObject selectedPlanet;
    public GameObject actualPlanet;
    public ManagerStars managerStars;
    public CameraControll camControll;
    public float starsSizes;
    public float orbitsVelocity;
    public float orbitsProportion;
    void Start()
    {
        ChangeAllOrbitProportion(starsSizes);
        ChangeAllSizes(orbitsVelocity);
        ChangeAllSpeed(orbitsProportion);
    }

    void Update()
    {
        GetKeyPress();
        if (Input.GetKeyDown("o"))
        {
            selectedPlanet = null;
            camControll.cameraM.transform.parent = null;
            camControll.viewType = CameraControll.ViewAspect.FreeAspect;
            camControll.MovePoint(camControll.originalPos);
            camControll.SetOrthographicSize(camControll.originalOrthographicSize);
        }
    }
    public void ChangeAllSizes(float proportion)
    {
        for (int i = 0; i < managerStars.planets.Count; i++)
        {
            managerStars.ChangePlanetSize(managerStars.planets[i], proportion);
        }
    }
    public void ChangeAllSpeed(float speed)
    {
        for (int i = 0; i < managerStars.planets.Count; i++)
        {
            managerStars.ChangeOrbitSpeed(managerStars.planets[i], speed);
        }
    }
    public void ChangeAllOrbitProportion(float proportion)
    {
        for (int i = 0; i < managerStars.planets.Count; i++)
        {
            managerStars.ChangeOrbitProportion(managerStars.planets[i], proportion);
        }
    }


    void GetKeyPress()
    {
        var input = Input.inputString;
        switch (input)
        {
            case ("q"):
                PressInputPlanet(0);
                break;
            case ("w"):
                PressInputPlanet(1);
                break;
            case ("e"):
                PressInputPlanet(2);
                break;
            case ("r"):
                PressInputPlanet(3);
                break;
            case ("t"):
                PressInputPlanet(4);
                break;
            case ("y"):
                PressInputPlanet(5);
                break;
            case ("u"):
                PressInputPlanet(6);
                break;
            case ("i"):
                PressInputPlanet(7);
                break;
        }
    }
    void PressInputPlanet(int planetIndex)
    {
        selectedPlanet = managerStars.planets[planetIndex];
        camControll.selectedPlanet = selectedPlanet;

        if (actualPlanet != selectedPlanet)
        {
            camControll.viewType = CameraControll.ViewAspect.Orbit;
        }
        if (camControll.viewType == CameraControll.ViewAspect.FreeAspect || camControll.viewType == CameraControll.ViewAspect.Orbit)
        {
            camControll.viewType = CameraControll.ViewAspect.Planet;
            camControll.selectedPlanet = selectedPlanet;
            camControll.cameraM.transform.parent = selectedPlanet.transform;  //coloca a camera como um filho do planeta
            actualPlanet = selectedPlanet;
            return;
        }
        else if (camControll.viewType == CameraControll.ViewAspect.Planet)
        {
            camControll.viewType = CameraControll.ViewAspect.Orbit;

            camControll.cameraM.transform.parent = null;
            actualPlanet = selectedPlanet;
            return;
        }
    }
}
