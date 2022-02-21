using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerBattle : MonoBehaviour
{
  public Button AttackButton;
  Animator animator;

      // Use this for initialization
      void Start () {
          animator = GetComponent<Animator>();
          Button attack = AttackButton.GetComponent<Button>();
      }

      // Update is called once per frame
      void Update () {

      }
  }
