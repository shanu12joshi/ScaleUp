using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject restartButton;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Win(){
        restartButton.SetActive(true);
        }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
