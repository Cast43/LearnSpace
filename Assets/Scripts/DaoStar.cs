using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaoStar : MonoBehaviour
{
    public float lineSize;
    public float planetSizeMultiplier;
    public float orbitalPeriod;
    public GameObject whoOrbit;
    public float eccentricity;
    public float aphelio;
    public float Yoffset;
    public float axisToRotate;
    public float drawTime;
    public float drawTimeDestroy;

    public float originalLineSize;
    public Vector3 originalPlanetSize;
    public float originalOrbitalPeriod;
    public float originalEccentricity;
    public float originalAphelio;
    public float originalYoffset;
    public float originalAxisToRotate;
    public float originalDrawTime;
    public float originalDrawTimeDestroy;

    [TextArea(5,10)]
    public string infoPlanet;

    void Awake()
    {
        drawTime = ((2 * Mathf.PI * aphelio) / orbitalPeriod);

        originalLineSize = lineSize;
        originalPlanetSize = transform.localScale;
        originalOrbitalPeriod = orbitalPeriod;
        originalEccentricity = eccentricity;
        originalAphelio = aphelio;
        originalYoffset = Yoffset;
        originalAxisToRotate = axisToRotate;
        originalDrawTime = drawTime;
        originalDrawTimeDestroy = drawTimeDestroy;
        originalDrawTime = drawTime;

        drawTimeDestroy = originalOrbitalPeriod * 2;

        originalDrawTimeDestroy = drawTimeDestroy;
    }

}
