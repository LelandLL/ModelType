using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {

    [SerializeField]
    GameObject background;

    [SerializeField]
    GameObject text;

    [SerializeField]
    GameObject progressBar;

    int progress = 0;

    // Use this for initialization
    void Start()
    {
        background.SetActive(false);
        text.SetActive(false);
        progressBar.SetActive(false);
    }

    public void LoadLevel(string Title)
    {
        StartCoroutine(DisplayLoadingScreen(Title));
    }

    IEnumerator DisplayLoadingScreen(string Title)
    {
        background.SetActive(true);
        text.SetActive(true);
        progressBar.SetActive(true);

        progressBar.transform.localScale = new Vector3(progress / 100, progressBar.transform.localScale.y);

        GetComponent<GUIText>().text = "Loading up the game " + progress + "%";

        // Start loading game
        AsyncOperation async = Application.LoadLevelAsync(Title);

        // Update progress bar
        while (!async.isDone)
        {
            progress = (int)(async.progress * 100);

            GetComponent<GUIText>().text = "loading " + progress + "%";

            progressBar.transform.localScale = new Vector3(async.progress, progressBar.transform.localScale.y);

            yield return null;
        }
    }
}

