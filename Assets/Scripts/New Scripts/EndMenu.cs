using UnityEngine;
using UnityEngine.SceneManagement;
public class EndMenu : MonoBehaviour {
    public void RestartGame() => SceneManager.LoadScene("Start"); 
}