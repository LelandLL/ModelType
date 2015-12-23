using UnityEngine;
using System.Collections;

public class ShakeCamera : MonoBehaviour {

    private bool shakeCam = false;
    public float offset;
    public float interval;

    void Update()
    {
        if (shakeCam == true)
        {
            StartCoroutine(Shake());
            shakeCam = false;
        }
    }


    IEnumerator Shake()
    {
        transform.Translate(new Vector3(offset, 0f, 0f));
        yield return new WaitForSeconds(interval);
        transform.Translate(new Vector3(-offset, 0f, 0f));
        yield return new WaitForSeconds(interval);
        transform.Translate(new Vector3(offset, 0f, 0f));
        yield return new WaitForSeconds(interval);
        transform.Translate(new Vector3(-offset, 0f, 0f));
        yield return new WaitForSeconds(interval);
        transform.Translate(new Vector3(offset, 0f, 0f));
        yield return new WaitForSeconds(interval);
        transform.Translate(new Vector3(-offset, 0f, 0f));
    }

    public void ShaketheCamera()
    {
        shakeCam = true;
    }

    public void restartGame()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        print("Waiting for 3 seconds for new game!");
        yield return new WaitForSeconds(3f);
        print("wait is over");
        Application.LoadLevel("Zaptor");
    }

}
