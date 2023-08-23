using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation2 : MonoBehaviour
{
    public DaoStar daoStar;
    public List<Vector3> posOrbit;
    public bool draw = false;
    public bool destroyDraw = false;
    public bool stopDraw = false;
    public LineRenderer lineRenderer;
    float timer = 0;

    // Start is called before the first frame update
    void Awake()
    {
        daoStar = GetComponent<DaoStar>();
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
    }
    void Start()
    {
        StartCoroutine(DestroyDraw(gameObject));
    }
    void Update()
    {
        timer += Time.fixedDeltaTime * (2 * Mathf.PI / daoStar.orbitalPeriod);
        Translate();

        if (draw == false)
        {
            if (!stopDraw)
            {
                StartCoroutine(Draw());
            }
        }
    }
    void Translate()
    {
        float raio = (daoStar.aphelio / (1 + daoStar.eccentricity * Mathf.Cos(timer))) * (1 - Mathf.Pow(daoStar.eccentricity, 2));
        float x = Mathf.Cos(timer) * raio;
        float z = Mathf.Sin(timer) * raio;
        Vector3 pos = new Vector3(x, daoStar.Yoffset, z);
        transform.position = pos + daoStar.whoOrbit.transform.position;
    }
    IEnumerator Draw()
    {
        draw = true;
        yield return new WaitForSeconds(2 / daoStar.drawTime);

        posOrbit.Add(transform.position - daoStar.whoOrbit.transform.position);
        lineRenderer.positionCount = posOrbit.Count;
        lineRenderer.SetPositions(posOrbit.ToArray());
        if (destroyDraw)
        {
            posOrbit.RemoveAt(0);
        }
        draw = false;
    }

    public IEnumerator DestroyDraw(GameObject planet)
    {
        planet.GetComponent<Translation2>().destroyDraw = false;
        yield return new WaitForSeconds(daoStar.drawTimeDestroy);
        planet.GetComponent<Translation2>().destroyDraw = true;
    }
}
