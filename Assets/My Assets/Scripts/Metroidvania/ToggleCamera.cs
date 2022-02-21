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

  public GameObject WHud;
  public GameObject ZHud;
  public GameObject KHud;


// Start Method
void Start()
{
  WCam.SetActive(true);
  ZCam.SetActive(false);
  KCam.SetActive(false);

  Wade.SetActive(true);
  Zarria.SetActive(false);
  Kameron.SetActive(false);

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

        Wade.SetActive(true);
        Zarria.SetActive(false);
        Kameron.SetActive(false);

        WHud.SetActive(true);
        ZHud.SetActive(false);
        KHud.SetActive(false);
    }
    if (Input.GetKey ("2")) {
        WCam.SetActive(false);
        ZCam.SetActive(true);
        KCam.SetActive(false);

        Wade.SetActive(false);
        Zarria.SetActive(true);
        Kameron.SetActive(false);

        WHud.SetActive(false);
        ZHud.SetActive(true);
        KHud.SetActive(false);

    }
    if (Input.GetKey ("3")) {
        WCam.SetActive(false);
        ZCam.SetActive(false);
        KCam.SetActive(true);

        Wade.SetActive(false);
        Zarria.SetActive(false);
        Kameron.SetActive(true);

        WHud.SetActive(false);
        ZHud.SetActive(false);
        KHud.SetActive(true);
    }
  }
}
