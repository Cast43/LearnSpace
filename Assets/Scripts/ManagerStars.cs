using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerStars : MonoBehaviour
{
    public List<GameObject> planets;

    public void ChangeLineSize(GameObject planet, float size)
    {
        DaoStar daoStar = planet.GetComponent<DaoStar>();
        Translation2 translation = planet.GetComponent<Translation2>();

        daoStar.lineSize = size;
        translation.lineRenderer.widthMultiplier = daoStar.lineSize;
    }
    public void ChangePlanetSize(GameObject planet, float proportion)
    {
        DaoStar daoStar = planet.GetComponent<DaoStar>();
        daoStar.planetSizeMultiplier = proportion;
        planet.transform.localScale = daoStar.planetSizeMultiplier * daoStar.originalPlanetSize;
    }
    public void ChangeOrbitSpeed(GameObject planet, float proportion)
    {
        DaoStar daoStar = planet.GetComponent<DaoStar>();
        Translation2 translation = planet.GetComponent<Translation2>();

        daoStar.orbitalPeriod = daoStar.originalOrbitalPeriod / proportion;

        daoStar.drawTimeDestroy = daoStar.originalOrbitalPeriod / proportion;

        daoStar.drawTime = ((2 * Mathf.PI * daoStar.aphelio) / daoStar.orbitalPeriod);

        translation.StartCoroutine(translation.DestroyDraw(planet));
    }
    public void ChangeOrbitProportion(GameObject planet, float proportion)
    {
        DaoStar daoStar = planet.GetComponent<DaoStar>();
        Translation2 translation = planet.GetComponent<Translation2>();

        daoStar.aphelio = daoStar.originalAphelio * proportion;
        translation.StartCoroutine(translation.DestroyDraw(planet));
        translation.posOrbit.Clear();
    }
}
