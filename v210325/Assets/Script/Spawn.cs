using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject asteroid01;
    public GameObject asteroid02;
    public GameObject asteroid03;
    public GameObject spacedebris01;
    public GameObject spacedebris02;
    public GameObject spacedebris03;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAsteroid());
        StartCoroutine(Spacedebris());
    }

    IEnumerator SpawnAsteroid()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            int a = Random.Range(0, 3);

            Vector3 pos = this.transform.position +
                new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));

            if (a == 0)
                Instantiate(asteroid01, pos, Random.rotation);
            else if (a == 1)
                Instantiate(asteroid02, pos, Random.rotation);
            else if (a == 2)
                Instantiate(asteroid03, pos, Random.rotation);
        }
    }

    IEnumerator Spacedebris()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);

            int n = Random.Range(0,3);

            Vector3 pos = this.transform.position +
                    new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));

            if (n == 0)
            {
                Instantiate(spacedebris01, pos, Random.rotation);
            }
            else if (n == 1)
            {
                Instantiate(spacedebris02, pos, Random.rotation);
            }
            else if (n == 2)
            {
                Instantiate(spacedebris03, pos, Random.rotation);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
