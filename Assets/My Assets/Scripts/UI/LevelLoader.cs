using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

  // Use this for initialization
  void Start(){
          Invoke("MyLoadingFunction",5.8f);
   }
   void MyLoadingFunction(){
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
      }
