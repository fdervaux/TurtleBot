using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TurtleState
{
    public Color _penColor;
    public float _penSize;

    public bool _penIsChange;
    public bool _penIsDown;
    public Vector2 _position;
    public bool _moving;
    public Vector2 _direction;
}


public class Turtle : MonoBehaviour
{
    private int _targetTurtleStatIndex;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private bool _onPlay = false;

    [SerializeField]
    private List<TurtleState> _turtleStates = new List<TurtleState>();

    [SerializeField]
    private TurtleState currentState; //keep info for add State

    public Color _penColor;
    public float _penSize;
    public bool _penIsDown = false;

    private float _distanceTheeshold = 0.01f;

    public GameObject LinePrefab;

    private LineRenderer currentLine;
    private List<Vector3> LinePoints = new List<Vector3>();

    public GameObject _pen;

    public void Play()
    {
        _onPlay = true;
    }

    public void Stop()
    {
        _onPlay = false;
    }

    public void Down()
    {
        currentState._penIsDown = true;
        currentState._penIsChange = true;
        _turtleStates.Add(currentState);
        currentState._penIsChange = false;
    }

    public void Up()
    {
        currentState._penIsDown = false;
        currentState._penIsChange = true;
        _turtleStates.Add(currentState);
        currentState._penIsChange = false;
    }

    public void PenSize(float width)
    {
        currentState._penSize = width;
        currentState._penIsChange = true;
        _turtleStates.Add(currentState);
        currentState._penIsChange = false;
    }

    public void PenColor(Color color)
    {
        currentState._penColor = color;
        currentState._penIsChange = true;
        _turtleStates.Add(currentState);
        currentState._penIsChange = false;
    }

    public void Forward(float distance)
    {
        currentState._position += currentState._direction * distance;
        currentState._moving = true;
        _turtleStates.Add(currentState);
        currentState._moving = false;
    }

    public void Backward(float distance)
    {
        currentState._position -= currentState._direction * distance;
        currentState._moving = true;
        _turtleStates.Add(currentState);
        currentState._moving = false;
    }

    public void Right(float angle)
    {
        float currentAngle = -Vector2.SignedAngle(Vector2.up, currentState._direction);
        float finalAngle = currentAngle + angle;
        currentState._direction = AngleAxis(finalAngle);
        _turtleStates.Add(currentState);
    }

    public void Left(float angle)
    {
        float currentAngle = -Vector2.SignedAngle(Vector2.up, currentState._direction);
        float finalAngle = currentAngle - angle;
        currentState._direction = AngleAxis(finalAngle);
        _turtleStates.Add(currentState);
    }

    public void Goto(Vector2 position)
    {
        currentState._position = position;
        currentState._moving = true;
        _turtleStates.Add(currentState);
        currentState._moving = false;
    }

    public void Turn(float angle)
    {
        currentState._direction = AngleAxis(angle);
        _turtleStates.Add(currentState);
    }

    void Awake()
    {
        _turtleStates.Add(currentState);
        _targetTurtleStatIndex = 1;
        applyState(currentState);
    }

    void Update()
    {
        if (_onPlay)
        {
            if (_targetTurtleStatIndex >= _turtleStates.Count)
            {
                Debug.Log("End play");
                _onPlay = false;
            }
            else
            {
                Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
                Vector2 targetPosition = _turtleStates[_targetTurtleStatIndex]._position;
                float sqrDistance = (targetPosition - currentPosition).sqrMagnitude;

                if (sqrDistance > _distanceTheeshold)
                {
                    Vector2 position = Vector2.MoveTowards(currentPosition, targetPosition, _speed * Time.deltaTime);
                    transform.position = new Vector3(position.x, position.y, 0.0f);
                    if (_penIsDown)
                    {
                        if ((LinePoints[LinePoints.Count - 1] - transform.position).sqrMagnitude > 5.0f)
                        {
                            LinePoints[LinePoints.Count - 1] = transform.position;
                        }
                        
                    }
                        
                }
                else
                {
                    TurtleState currentState = _turtleStates[_targetTurtleStatIndex];
                    applyState(currentState);
                    _targetTurtleStatIndex++;

                    if (_penIsDown && currentState._moving) 
                    {
                        Debug.Log("Addpoints");
                        LinePoints[LinePoints.Count - 1] = transform.position;
                        currentLine.positionCount++;
                        LinePoints.Add(transform.position);
                    }
                }

                if (_penIsDown)
                {
                    Vector3[] points = LinePoints.ToArray();
                    currentLine.SetPositions(points);
                }

            }
        }

    }

    public void applyState(TurtleState state)
    {
        transform.position = new Vector3(state._position.x, state._position.y, 0.0f);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, Vector2.SignedAngle(Vector2.up, state._direction));

        _penIsDown = state._penIsDown;

        _pen.SetActive(_penIsDown);

        if (state._penIsChange)
        {
            _penColor = state._penColor;
            _penSize = state._penSize;

            if (_penIsDown)
            {
                GameObject lineObject = GameObject.Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
                currentLine = lineObject.GetComponent<LineRenderer>();
                LinePoints.Clear();
                currentLine.positionCount+=2;
                LinePoints.Add(transform.position);
                LinePoints.Add(transform.position);
                currentLine.material.SetColor("_Color", _penColor);
                currentLine.startWidth = _penSize;
                currentLine.endWidth = _penSize;
                
            }
        }

    }



    public Vector2 AngleAxis(float angle)
    {
        float angleInRad = Mathf.Deg2Rad * angle;
        return new Vector2(Mathf.Sin(angleInRad), Mathf.Cos(angleInRad));
    }
}
