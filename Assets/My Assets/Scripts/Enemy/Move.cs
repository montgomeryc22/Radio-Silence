using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
  public MoveBase Base
  {
    get;
    set;
  }
  public int TimesPerformed
  {
    get;
    set;
  }
  public Move(MoveBase pBase)
  {
    Base = pBase;
    TimesPerformed = pBase.TimesPerformed;
  }
}
