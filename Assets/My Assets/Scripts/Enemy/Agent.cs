using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour {
  [SerializeField] Transform target;

  private NavMeshAgent agent;

  void Start ()
  {
    target = GameObject.FindGameObjectWithTag("Player1").transform;

    agent = GetComponent<NavMeshAgent>();
    agent.updateRotation = false;
    agent.updateUpAxis = false;
  }

  void Update()
  {
    agent.SetDestination(target.position);
  }
}
