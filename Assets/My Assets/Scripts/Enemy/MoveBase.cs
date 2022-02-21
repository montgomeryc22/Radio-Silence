using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Enemy/Create new move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Enemy type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int timesPerformed;

    public string Name
    {
      get
      {
        return name;
      }
    }
    public string Description
    {
      get
      {
        return description;
      }
    }
    public int Power
    {
      get
      {
        return power;
      }
    }
    public int Accuracy
    {
      get
      {
        return accuracy;
      }
    }
    public int TimesPerformed
    {
      get
      {
        return timesPerformed;
      }
    }
}
