using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationMusic : MonoBehaviour
{
  public AudioClip active1;
  public AudioClip active2;
  public AudioClip active3;
  public AudioSource BlueCity;
  public AudioSource DarkBlueCity;
  public AudioSource RedCity;
  public AudioSource OrangeCity;
  public AudioSource Underground;

  public GameObject Wade;
  public GameObject Zarria;
  public GameObject Kameron;

  public GameObject WCam;
  public GameObject ZCam;
  public GameObject KCam;

  public float BlueCityPitch = 1.1f;




void Start()
  {
     StartCoroutine(LoopAudio());
  }



void Update()
{
  if (WCam.activeInHierarchy) {
    BlueCity.PlayOneShot(active1, 0f);
    OrangeCity.Pause();
    Underground.Pause();

  }

  if (ZCam.activeInHierarchy) {
    BlueCity.Pause();
    OrangeCity.PlayOneShot(active2, 0f);
    Underground.Pause();
  }

  if (KCam.activeInHierarchy) {
    BlueCity.Pause();
    OrangeCity.Pause();
    Underground.PlayOneShot(active3, 0f);
  }
}


 IEnumerator LoopAudio()
   {
     BlueCity.pitch = BlueCityPitch;
     float length = 31.5f;

     while(true)
     {
       BlueCity.Play();
       yield return new WaitForSeconds(length);

       OrangeCity.Play();
       yield return new WaitForSeconds(length);

       Underground.Play();
       yield return new WaitForSeconds(length);
     }
   }
 }
