using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerNextScene : MonoBehaviour
{
  public VideoPlayer VideoPlayer;
  public string Metroidvania;

 void Start()
 {
      VideoPlayer.loopPointReached += LoadScene;
 }
 
 void LoadScene(VideoPlayer VP)
 {
      SceneManager.LoadScene(Metroidvania);
  }
}
