using System.Collection;
using System.Colletion.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
  public void PlayGame()
  (
    SceneManager.LoadScene(SceneManager.getActiveScene().buildIndex += 1);
  )
  
  public void QuitGame()
  (
    ApplicationDone.Quit();
  )
}