using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicManager : MonoBehaviour
{
    public static musicManager instance = null;
    
    public AudioSource menu;
    public AudioSource mainIntro;
    public AudioSource mainLoop;
    public float fadeAmount;

    private enum currentScene {Menu, Main};
    
    
    void Awake()
    {
        if (instance == null) {
			instance = this;
        } else if (instance != this) {
			Destroy (gameObject);
        }
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Main Menu") {
            menu.Play();
        } else if (sceneName == "Splitscreen") {
            playMain();
        }
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update() {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        print("Loading!");
        if (scene.name == "Main Menu") {
            menu.Play();
        } else if (scene.name == "Splitscreen") {
            playMain();
        }
    }

    void playMain() {
        if (menu.isPlaying) {
            StartCoroutine(Fadeout(menu));
        }
        double introDuration = (double)mainIntro.clip.samples / mainIntro.clip.frequency;
        double startTime = AudioSettings.dspTime + 0.3;
        mainIntro.PlayScheduled(startTime);
        mainLoop.PlayScheduled(startTime + introDuration);
    }

    void playMenu() {
        if (mainIntro.isPlaying || mainLoop.isPlaying) {
            StartCoroutine(Fadeout(mainIntro));
            StartCoroutine(Fadeout(mainLoop));
        }
        menu.PlayScheduled(AudioSettings.dspTime + 0.3);
    }

    IEnumerator Fadeout(AudioSource source) {
        float priorVol = source.volume;
        while (source.volume > 0) {
            if (source.volume > fadeAmount) {
                source.volume -= fadeAmount;
            } else {
                source.volume = 0;
            }
            yield return null;
        }
        source.Stop();
        source.volume = priorVol;
    }
}
