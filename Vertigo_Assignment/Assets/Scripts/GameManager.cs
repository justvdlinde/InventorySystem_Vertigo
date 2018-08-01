using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject controlsScreen;
    public static GameManager Instance { set; get; }

    private void Start () {
        Instance = this;
        controlsScreen.SetActive(false);
        DontDestroyOnLoad(gameObject);
	}

    public void StartButton() {
        SceneManager.LoadScene("Main");
    }
	
	public void ControlsButton() {
        controlsScreen.SetActive(true);
    }

    public void BackButton() {
        controlsScreen.SetActive(false);
    }
}
