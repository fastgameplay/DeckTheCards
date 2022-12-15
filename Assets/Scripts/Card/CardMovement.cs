using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMovement : MonoBehaviour{
    public float TargetAngle{
        set{
            _targetAngle = value;
        }
    }
    public bool IsActive{
        set{
            _isActive = value;
        }
    }
    [SerializeField] float _speed;

    Vector3 _targetPosition;
    float _targetAngle;
    float _angle;

    float _currentHight{
        get{
            if(_isActive)
                return _activeHeight;
            else 
                return _height;
        }
    }
    float _height;
    float _activeHeight;
    
    bool _isActive;

    void Update(){
        _angle = Mathf.MoveTowards(_angle, _targetAngle, _speed * Time.deltaTime);
        _targetPosition = CalculatePosition(_angle);
        transform.localPosition = Vector3.MoveTowards (transform.localPosition, _targetPosition, Time.deltaTime * _speed);
        transform.localRotation = Quaternion.AngleAxis(_angle, Vector3.back);
    }
    
    public Vector3 CalculatePosition(float angle){
        float x = _currentHight * Mathf.Sin(angle / Mathf.Rad2Deg);
        float y = _currentHight * Mathf.Cos(angle / Mathf.Rad2Deg);
        return new Vector3(x, y, 0);
    }

    public void SetHeight(float height, float activeHeight){
        _height = height;
        _activeHeight = activeHeight;
    }
}
