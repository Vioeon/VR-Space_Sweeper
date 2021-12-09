using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceDebris : MonoBehaviour
{
    private int debris = 0;
    public GameObject returntext;
    public GameObject mainCam;

    public Text weight;

    public AudioClip fire;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = mainCam.transform.TransformDirection(Vector3.forward) * 1000;

        if (Physics.Raycast(mainCam.transform.position, forward, out hit))
        { 
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.transform.gameObject.tag == "SpaceDebris")
                {
                    this.gameObject.GetComponent<AudioSource>().PlayOneShot(fire);

                    debris++;
                    //Debug.Log("쓰레기 수 : " + debris);
                    Destroy(hit.transform.gameObject);
                          
                    if (debris == PlayerPrefs.GetInt("weight"))
                    {
                        PlayerPrefs.SetInt("point", PlayerPrefs.GetInt("point") + debris / 2);
                        PlayerPrefs.Save();

                        returntext.SetActive(true);
                        StartCoroutine(Return());
                    }
                }
            }
        }
        weight.text = "적재량 : " + debris + "/" + PlayerPrefs.GetInt("weight").ToString();

    }
    IEnumerator Return()
    {
        yield return new WaitForSeconds(2.0f);

        debris = 0;
        returntext.SetActive(false);
        SceneManager.LoadScene("Upgrade");
    }
}
