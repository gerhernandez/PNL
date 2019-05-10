using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Sb2CheckpointSetter : MonoBehaviour
{

    public Transform[] checkpoints;

    private HealthManager hm;


    // Use this for initialization
    void Start()
    {
        hm = FindObjectOfType<HealthManager>();
    }

    public void toMentor()
    {
        Vector2 newCheckpoint = new Vector2(checkpoints[0].position.x, checkpoints[0].position.y);
        hm.setCheckPoint(newCheckpoint);
        StartCoroutine(hm.goToLastCheckpoint());
    }

    public void quarterWayUp()
    {
        Vector2 newCheckpoint = new Vector2(checkpoints[1].position.x, checkpoints[1].position.y);
        hm.setCheckPoint(newCheckpoint);
        StartCoroutine(hm.goToLastCheckpoint());
    }

    public void halfWayUp()
    {
        Vector2 newCheckpoint = new Vector2(checkpoints[2].position.x, checkpoints[2].position.y);
        hm.setCheckPoint(newCheckpoint);
        StartCoroutine(hm.goToLastCheckpoint());
    }

    public void threeQuartersWayUp()
    {
        Vector2 newCheckpoint = new Vector2(checkpoints[3].position.x, checkpoints[3].position.y);
        hm.setCheckPoint(newCheckpoint);
        StartCoroutine(hm.goToLastCheckpoint());
    }

    public void fullWayUp()
    {
        Vector2 newCheckpoint = new Vector2(checkpoints[4].position.x, checkpoints[4].position.y);
        hm.setCheckPoint(newCheckpoint);
        StartCoroutine(hm.goToLastCheckpoint());
    }
}
