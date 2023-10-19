using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public float cameraSlow = 1;
    public float zoomSlow = 10;
    public float originalOrthographicSize;
    public float speedTransit;
    public bool resetCamera = true;
    public bool changeOrthographicSize;
    public float orthographicSize;
    public GameObject selectedPlanet;
    public Vector3 pointMove;
    public Vector3 originalPos;
    Vector3 velocity = Vector3.zero;

    public enum ViewAspect { FreeAspect, Orbit, Planet };
    public ViewAspect viewType = ViewAspect.FreeAspect;
    public Camera cameraM;
    Vector3 moveInput;
    float zoomInput;
    void Start()
    {
        cameraM = Camera.main;
        originalPos = cameraM.transform.position;
        originalOrthographicSize = cameraM.orthographicSize;
    }

    void Update()
    {
        if (viewType == ViewAspect.FreeAspect)
        {
            if (((int)cameraM.orthographicSize) == ((int)originalOrthographicSize))
            {
                resetCamera = false;
            }
            FreeAspectView();
        }
        if (viewType == ViewAspect.Orbit)
        {
            OrbitView();
        }
        if (viewType == ViewAspect.Planet)
        {
            PlanetView();
        }
    }

    void FreeAspectView()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        zoomInput = Input.GetAxisRaw("Mouse ScrollWheel");
        cameraM.transform.position += moveInput * (cameraM.orthographicSize / cameraSlow);
        cameraM.orthographicSize -= zoomInput * (cameraM.orthographicSize / zoomSlow);
        selectedPlanet = null;

        if (resetCamera == true)
        {
            MovePoint(Vector3.zero);
            SetOrthographicSize(originalOrthographicSize);
        }
        // if (cameraM.orthographicSize != originalOrthographicSize)
        // {
        // }
    }
    public void OrbitView()
    {
        if (cameraM.transform.position != Vector3.zero)
        {
            MovePoint(Vector3.zero);
        }
        if (cameraM.orthographicSize != orthographicSize)
        {
            SetOrthographicSize(selectedPlanet.GetComponent<DaoStar>().aphelio * 1.2f);
        }
    }
    public void PlanetView()
    {
        if (cameraM.transform.position != selectedPlanet.transform.position)
        {
            MoveToAstro(selectedPlanet);
        }
        else
        {

        }

        if (cameraM.orthographicSize != orthographicSize)
        {
            SetOrthographicSize(selectedPlanet.transform.localScale.x * 1.5f);
        }
    }
    public void SetOrthographicSize(float scale)
    {
        cameraM.orthographicSize = Mathf.MoveTowards(cameraM.orthographicSize, scale, Mathf.Abs(scale - cameraM.orthographicSize) * speedTransit);
    }
    public void MovePoint(Vector3 planetPos)
    {
        float time = 0.1f;
        float x = Mathf.Lerp(cameraM.transform.position.x, planetPos.x, time);
        float z = Mathf.Lerp(cameraM.transform.position.z, planetPos.z, time);
        cameraM.transform.position = new Vector3(x, cameraM.transform.position.y, z);
    }
    public void MoveToAstro(GameObject planet)
    {
        Vector3 astroPosFix = new Vector3(planet.transform.position.x, cameraM.transform.position.y, planet.transform.position.z);
        // float x = Mathf.clamp(cameraM.transform.position.x, astroPosFix.x, time);
        // float z = Mathf.clamp(cameraM.transform.position.z, astroPosFix.z, time);

        float distanceSpeed = Mathf.Abs(astroPosFix.magnitude - cameraM.transform.position.magnitude) * speedTransit*5;

        cameraM.transform.position = Vector3.MoveTowards(cameraM.transform.position, astroPosFix, distanceSpeed);
    }
}
