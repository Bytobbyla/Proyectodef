using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] int nenemigos;

    bool active;
    
    public static float timeLeft = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        PauseGame();
     
    }

   
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Nivel2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;


    }
    public void Nivel3()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
    
    public void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            active = !active;
            PauseMenu.SetActive(true);
            Time.timeScale = (active) ? 0 : 1f;
            if (Time.timeScale == 1)
            {
                PauseMenu.SetActive(false);
            }
        }
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Numenemigos()
    {
        nenemigos--;
        if (nenemigos < 1)
        {
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
        }
    }
    
}
