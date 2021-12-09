using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceShip : MonoBehaviour
{

    public GameObject head;
    public GameObject mainCam;
    public GameObject ship;
    public GameObject spawnship;

    float cur_angle;
    float prev_angle;
    float delta_angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();

    }

    void MoveForward()
    {
        head.transform.Translate(mainCam.transform.forward * PlayerPrefs.GetFloat("speed"));

        cur_angle = mainCam.transform.eulerAngles.y;
        delta_angle = cur_angle - prev_angle;
        prev_angle = cur_angle;

        if (delta_angle < 0)
        {
            ship.transform.rotation = Quaternion.Lerp(ship.transform.rotation,
                Quaternion.Euler(ship.transform.eulerAngles.x, ship.transform.eulerAngles.y, 45), Time.deltaTime);
        }
        else if (delta_angle > 0)
        {
            ship.transform.rotation = Quaternion.Lerp(ship.transform.rotation,
                Quaternion.Euler(ship.transform.eulerAngles.x, ship.transform.eulerAngles.y, -45), Time.deltaTime);
        }
        else
        {
            ship.transform.rotation = Quaternion.Lerp(ship.transform.rotation,
                Quaternion.Euler(ship.transform.eulerAngles.x, ship.transform.eulerAngles.y, 0), Time.deltaTime);
        }
    }
}
