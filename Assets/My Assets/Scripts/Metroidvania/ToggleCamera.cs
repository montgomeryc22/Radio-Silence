using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera : MonoBehaviour {

  public GameObject WCam;
  public GameObject ZCam;
  public GameObject KCam;

  public GameObject Wade;
  public GameObject Zarria;
  public GameObject Kameron;

  public GameObject Enemy;
  public GameObject Jam;

  public GameObject WHud;
  public GameObject ZHud;
  public GameObject KHud;

// Start Method
void Start()
{

  Wade.GetComponent<PlayerMovementKameron>().enabled = true;
  Zarria.GetComponent<PlayerMovementKameron>().enabled = false;
  Kameron.GetComponent<PlayerMovementKameron>().enabled = false;

  Wade.GetComponent<AudioSource>().enabled = true;
  Zarria.GetComponent<AudioSource>().enabled = false;
  Kameron.GetComponent<AudioSource>().enabled = false;

  Enemy.GetComponent<PingPong>().enabled = false;
  Jam.GetComponent<AudioSource>().enabled = false;


  WCam.SetActive(true);
  ZCam.SetActive(false);
  KCam.SetActive(false);

  WHud.SetActive(true);
  ZHud.SetActive(false);
  KHud.SetActive(false);

}
// Update is called once per frame
void Update ()
{
    if (Input.GetKey ("1")) {
        WCam.SetActive(true);
        ZCam.SetActive(false);
        KCam.SetActive(false);

        Wade.GetComponent<PlayerMovementKameron>().enabled = true;
        Zarria.GetComponent<PlayerMovementKameron>().enabled = false;
        Kameron.GetComponent<PlayerMovementKameron>().enabled = false;

        Enemy.GetComponent<PingPong>().enabled = false;
        Jam.GetComponent<AudioSource>().enabled = false;


        Wade.GetComponent<AudioSource>().enabled = true;
        Zarria.GetComponent<AudioSource>().enabled = false;
        Kameron.GetComponent<AudioSource>().enabled = false;

        WHud.SetActive(true);
        ZHud.SetActive(false);
        KHud.SetActive(false);
    }
    if (Input.GetKey ("2")) {
        WCam.SetActive(false);
        ZCam.SetActive(true);
        KCam.SetActive(false);

        Wade.GetComponent<PlayerMovementKameron>().enabled = false;
        Zarria.GetComponent<PlayerMovementKameron>().enabled = true;
        Kameron.GetComponent<PlayerMovementKameron>().enabled = false;

        Enemy.GetComponent<PingPong>().enabled = false;
        Jam.GetComponent<AudioSource>().enabled = false;


        Wade.GetComponent<AudioSource>().enabled = false;
        Zarria.GetComponent<AudioSource>().enabled = true;
        Kameron.GetComponent<AudioSource>().enabled = false;


        WHud.SetActive(false);
        ZHud.SetActive(true);
        KHud.SetActive(false);

    }
    if (Input.GetKey ("3")) {
        WCam.SetActive(false);
        ZCam.SetActive(false);
        KCam.SetActive(true);

        Wade.GetComponent<PlayerMovementKameron>().enabled = false;
        Zarria.GetComponent<PlayerMovementKameron>().enabled = false;
        Kameron.GetComponent<PlayerMovementKameron>().enabled = true;

        Enemy.GetComponent<PingPong>().enabled = true;
        Jam.GetComponent<AudioSource>().enabled = true;


        Wade.GetComponent<AudioSource>().enabled = false;
        Zarria.GetComponent<AudioSource>().enabled = false;
        Kameron.GetComponent<AudioSource>().enabled = true;

        WHud.SetActive(false);
        ZHud.SetActive(false);
        KHud.SetActive(true);
    }
  }
}
