using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Upgrade : MonoBehaviour
{
    public Image CursorGaugeImage; // public => inspector에 나타난다.
    private float GaugeTimer;

    public Text pointtext;
    public Text lifetext;
    public Text speedtext;
    public Text weighttext;

    float[] value = new float[5];

    // Start is called before the first frame update
    void Start()
    {
        
        if (!PlayerPrefs.HasKey("point"))
        {
            PlayerPrefs.SetInt("point", 1);
        }
        if (!PlayerPrefs.HasKey("life"))
        {
            PlayerPrefs.SetInt("life", 2);
        }
        if (!PlayerPrefs.HasKey("speed"))
        {
            PlayerPrefs.SetFloat("speed", 0.1f);
        }
        if (!PlayerPrefs.HasKey("weight"))
        {
            PlayerPrefs.SetInt("weight", 4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;
        CursorGaugeImage.fillAmount = GaugeTimer;

        if (Physics.Raycast(transform.position, forward, out hit))
        {
            if (PlayerPrefs.GetInt("point") > 0)
            {
                if (hit.collider.name == "Lplus")
                {
                    GaugeTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        PlayerPrefs.SetInt("life", PlayerPrefs.GetInt("life") + 1);
                        GaugeTimer = 0.0f;
                        PlayerPrefs.SetInt("point", PlayerPrefs.GetInt("point") - 1);
                    }
                }
                /*else if (hit.collider.name == "Lminus")
                {
                    GaugeTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        PlayerPrefs.SetInt("life", PlayerPrefs.GetInt("life") - 1);
                        GaugeTimer = 0.0f;
                        PlayerPrefs.SetInt("point", PlayerPrefs.GetInt("point") + 1);
                    }
                }*/

                else if (hit.collider.name == "Splus")
                {
                    GaugeTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        PlayerPrefs.SetFloat("speed", PlayerPrefs.GetFloat("speed") + 0.02f);
                        GaugeTimer = 0.0f;
                        PlayerPrefs.SetInt("point", PlayerPrefs.GetInt("point") - 1);
                    }
                }
                /*else if (hit.collider.name == "Sminus")
                {
                    GaugeTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        PlayerPrefs.SetFloat("speed", PlayerPrefs.GetFloat("speed") - 0.1f);
                        GaugeTimer = 0.0f;
                        PlayerPrefs.SetInt("point", PlayerPrefs.GetInt("point") + 1);
                    }
                }*/

                else if (hit.collider.name == "Wplus")
                {
                    GaugeTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        PlayerPrefs.SetInt("weight", PlayerPrefs.GetInt("weight") + 1);
                        GaugeTimer = 0.0f;
                        PlayerPrefs.SetInt("point", PlayerPrefs.GetInt("point") - 1);
                    }
                }
                /*else if (hit.collider.name == "Wminus")
                {
                    GaugeTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        PlayerPrefs.SetInt("weight", PlayerPrefs.GetInt("weight") - 1);
                        GaugeTimer = 0.0f;
                        PlayerPrefs.SetInt("point", PlayerPrefs.GetInt("point") + 1);
                    }
                }*/
                else if (hit.collider.tag == "Start") // start 버튼
                {
                    GaugeTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        SceneManager.LoadScene("MainGame");
                        GaugeTimer = 0.0f;
                    }
                }
                else if (hit.collider.tag == "Back")
                {
                    GaugeTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GaugeTimer >= 1.0f)
                    {
                        SceneManager.LoadScene("Mainmenu");
                        GaugeTimer = 0.0f;
                    }
                }
                else
                    GaugeTimer = 0.0f;

                PlayerPrefs.Save();
            }

            else if (hit.collider.tag == "Start")
            {
                GaugeTimer += 1.0f / 2.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    SceneManager.LoadScene("MainGame");
                    GaugeTimer = 0.0f;
                }
            }
            else if (hit.collider.tag == "Back")
            {
                GaugeTimer += 1.0f / 2.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    SceneManager.LoadScene("Mainmenu");
                    GaugeTimer = 0.0f;
                }
            }
            else
                GaugeTimer = 0.0f;
        }
        else
            GaugeTimer = 0.0f;

        pointtext.text = "잔여 포인트 : " + PlayerPrefs.GetInt("point").ToString();
        lifetext.text = "내구력 : " + PlayerPrefs.GetInt("life").ToString();
        speedtext.text = "   속도 : " + PlayerPrefs.GetFloat("speed").ToString();
        weighttext.text = "적재량 : " + PlayerPrefs.GetInt("weight").ToString();
    }
}
