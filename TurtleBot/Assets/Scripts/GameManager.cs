using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Turtle _turtle;

    public void OnPlay()
    {
        _turtle.Play();
    }

    public void OnStop()
    {
        _turtle.Stop();
    }

    void Start()
    {

        _turtle.Forward(10);
        _turtle.PenColor(Color.red);
        _turtle.PenSize(0.9f);
        _turtle.Down();
        _turtle.Forward(10);
        _turtle.Left(45);
        _turtle.Forward(10);
        _turtle.Left(45);
        _turtle.Forward(10);
        _turtle.Left(45);
        _turtle.Forward(10);
        _turtle.Left(45);
        _turtle.Up();
        _turtle.PenColor(Color.green);
        _turtle.PenSize(0.1f);
        _turtle.Down();
        _turtle.Forward(10);
        _turtle.Left(45);
        _turtle.Forward(10);
        _turtle.Left(45);
        _turtle.Forward(10);
        _turtle.Left(45);
        _turtle.Forward(10);
        _turtle.Left(45);
        _turtle.Up();
        _turtle.Goto(new Vector2(10, 10));
        _turtle.Turn(180);

        //_turtle.Play();
    }

    void Update()
    {
        
    }
}
