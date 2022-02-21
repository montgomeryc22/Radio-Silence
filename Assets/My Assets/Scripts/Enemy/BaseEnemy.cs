using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Create New Enemy")]

public class BaseEnemy: ScriptableObject
{
  [SerializeField] string name;

  [TextArea]
  [SerializeField] string description;

  [SerializeField] Sprite battleSprite;

  [SerializeField] EnemyTypes type1;
  [SerializeField] EnemyTypes type2;
  [SerializeField] EnemyTypes type3;

  [SerializeField] int maxHp;
  [SerializeField] int attack;
  [SerializeField] int defense;
  [SerializeField] int spAttack;
  [SerializeField] int spDefense;
  [SerializeField] int speed;

  [SerializeField] List<LearnableMove> learnableMove;

  [System.Serializable]


  public class LearnableMove
  {
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;
  }

  public List<LearnableMove> LearnableMoves
  {
    get
    {
      return learnableMove;
    }
  }

  public enum EnemyTypes
  {
    None,
    Scrappy,
    Aggressive,
    Hostile,
    Passive,
    Friendly,
    Timid,
    Pacifist,
    Pressurable,
  }
}
