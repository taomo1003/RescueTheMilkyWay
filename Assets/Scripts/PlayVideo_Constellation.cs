using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayVideo_Constellation : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Handheld.PlayFullScreenMovie("constellation.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }


    public void NextScene() {
        SceneManager.LoadScene("Intro_3");
    }

}
