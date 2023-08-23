using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public float cameraSlow = 1;
    public float zoomSlow = 10;
    public float originalOrthographicSize;
    public bool movePoint;
    public bool moveAstro;
    public bool changeOrthographicSize;
    public float orthographicSize;
    public GameObject selectedPlanet;
    public Vector3 pointMove;
    public Vector3 originalPos;

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
        if (cameraM.transform.position != Vector3.zero)
        {
            MovePoint(Vector3.zero);
        }
        if (cameraM.orthographicSize != originalOrthographicSize)
        {
            SetOrthographicSize(originalOrthographicSize);
        }
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
            MoveAstro(selectedPlanet);
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
        cameraM.orthographicSize = Mathf.Lerp(cameraM.orthographicSize, scale, 0.05f);
    }
    public void MovePoint(Vector3 planetPos)
    {
        float time = 0.1f;
        float x = Mathf.Lerp(cameraM.transform.position.x, pointMove.x, time);
        float z = Mathf.Lerp(cameraM.transform.position.z, pointMove.z, time);
        cameraM.transform.position = new Vector3(x, cameraM.transform.position.y, z);
    }
    public void MoveAstro(GameObject planet)
    {
        Vector3 astroPosFix = new Vector3(selectedPlanet.transform.position.x, cameraM.transform.position.y, selectedPlanet.transform.position.z);
        float time = (planet.transform.position - cameraM.transform.position).magnitude * 0.000008f;
        float x = Mathf.Lerp(cameraM.transform.position.x, astroPosFix.x, time);
        float z = Mathf.Lerp(cameraM.transform.position.z, astroPosFix.z, time);
        cameraM.transform.position = new Vector3(x, cameraM.transform.position.y, z);
    }
}
