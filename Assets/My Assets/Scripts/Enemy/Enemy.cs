using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
  BaseEnemy _base;
  int level;

  public Enemy(BaseEnemy eBase, int eLevel)
  {
    _base = eBase;
    level = eLevel;
  }

}
