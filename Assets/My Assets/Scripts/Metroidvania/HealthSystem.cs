using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

  public int health;
  public int numOfHearts;
  public Image[] faces;

  public Sprite HappyFace;
  public Sprite SemiHappyFace;
  public Sprite NormalFace;
  public Sprite UnhappyFace;
  public Sprite DistressedFace;
  public Sprite DeadFace;

  private void Update()
  {
    if(health > numOfHearts)
    {
      health = numOfHearts;
    }
    for (int i = 0; i < faces.Length; i++)
    {
      if(i < health)
      {
        faces[i].sprite = HappyFace;
      } else
      {
        faces[i].sprite = DeadFace;
      }


      if(i < numOfHearts)
      {
        faces[i].enabled = true;
      } else
      {
        faces[i].enabled = false;
      }
    }
  }
}
