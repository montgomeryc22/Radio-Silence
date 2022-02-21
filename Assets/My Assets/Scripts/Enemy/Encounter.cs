using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{

  public GameObject Bug;
  public GameObject Airor;
  public GameObject WhiteSpace;
  public GameObject Sytntax;
  public GameObject Runtime;
  public GameObject MJ;

    // Start is called before the first frame update
    void Start()
    {
      GameObject enemy = (GameObject)Instantiate(Resources.Load("Enemy"));
    }


    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey ("1")) {
          Bug.SetActive(true);
          Airor.SetActive(false);
          WhiteSpace.SetActive(false);
          Sytntax.SetActive(false);
          Runtime.SetActive(false);
          MJ.SetActive(false);
        }
    }
}
