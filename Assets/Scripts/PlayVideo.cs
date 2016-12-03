using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Handheld.PlayFullScreenMovie("gaia.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }

    // Update is called once per frame
    void Update () {
        
    }

    public void NextScene() {
        SceneManager.LoadScene("Intro_2_Movie");
    }

}
