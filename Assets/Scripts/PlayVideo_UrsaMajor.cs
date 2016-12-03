using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayVideo_UrsaMajor : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Handheld.PlayFullScreenMovie("ursamajor.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }


    public void NextScene() {
        SceneManager.LoadScene("Intro_2");
    }

}
