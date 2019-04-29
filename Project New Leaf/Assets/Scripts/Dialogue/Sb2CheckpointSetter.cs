using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Sb2CheckpointSetter : MonoBehaviour
{

    public Transform[] checkpoints;

    private Player player;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    public void quarterWayUp()
    {
        Vector2 newCheckpoint = new Vector2(checkpoints[0].position.x, checkpoints[0].position.y);
        player.setCurrentCheckpoint(newCheckpoint);
    }

    public void halfWayUp()
    {
        Vector2 newCheckpoint = new Vector2(checkpoints[1].position.x, checkpoints[1].position.y);
        player.setCurrentCheckpoint(newCheckpoint);
    }

    public void threeQuartersWayUp()
    {
        Vector2 newCheckpoint = new Vector2(checkpoints[2].position.x, checkpoints[2].position.y);
        player.setCurrentCheckpoint(newCheckpoint);
    }

    public void fullWayUp()
    {
        Vector2 newCheckpoint = new Vector2(checkpoints[3].position.x, checkpoints[3].position.y);
        player.setCurrentCheckpoint(newCheckpoint);
    }
}
