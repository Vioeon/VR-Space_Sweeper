using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public class shipend : MonoBehaviour
{
    private int count = 0;
    public Text life;

    Stopwatch sw = new Stopwatch();

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        if (count < PlayerPrefs.GetInt("life"))
        {
            count += 1;
            debug.Log("count : " + count);
            if (count == PlayerPrefs.GetInt("life"))
            {
                sw.Stop();
                PlayerPrefs.SetFloat("Time", sw.ElapsedMilliseconds / 1000.0f);
                yield return new WaitForSeconds(1.0f);

                count = 0;
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sw.Start();
    }

    // Update is called once per frame
    void Update()
    {
        life.text = "Life : " + (PlayerPrefs.GetInt("life") - count).ToString();
    }
}
