using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

  public static bool GameIsPaused = false;
  public GameObject PauseUI;

  GameObject Wade;
  GameObject Zarria;
  GameObject Kameron;

  AudioSource WB;
  AudioSource ZK;
  AudioSource KOW;

  void Start ()
  {
    WB = Wade.GetComponent<AudioSource>();
    ZK = Zarria.GetComponent<AudioSource>();
    KOW = Kameron.GetComponent<AudioSource>();
  }

  	// Update is called once per frame
  	void Update () {

  		//uses the p button to pause and unpause the game
  		if(Input.GetKeyDown(KeyCode.P))
  		{
        if(GameIsPaused)
        {
          Resume();
        } else
        {
          Pause();
        }
  	}
  }

    public void PauseMusic()
    {
      if(!WB.isPlaying)
      {
        WB.Pause();
      }
      if(!ZK.isPlaying)
      {
        WB.Pause();
      }
      if(!KOW.isPlaying)
      {
        KOW.Pause();
      }
    }

    public void PlayMusic()
    {
      if(!WB.isPlaying)
      {
        WB.UnPause();
      }
      if(!ZK.isPlaying)
      {
        WB.UnPause();
      }
      if(!KOW.isPlaying)
      {
        KOW.UnPause();
      }
    }

    //Resumes the Game
    public void Resume ()
    {
      PauseUI.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false;
    }


    //Pauses the Game
    public void Pause()
    {
      PauseUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
    }

  	//Reloads the Level
  	public void Reload(string BaseGame){
  		SceneManager.LoadScene(BaseGame);
  	}

    //load to main menu
    public void LoadToMenu(string Title){
      Time.timeScale = 1f;
  		SceneManager.LoadScene(Title);
  	}

    //Quits the Game
    public void QuitGame(){
      Application.Quit();
    }
  }
