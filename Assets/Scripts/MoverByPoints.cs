using UnityEngine;

public class MoverByPoints : MonoBehaviour
{
    private const float MinDistant = 0.5f;

    [SerializeField] private Transform[] _points;

    [SerializeField] private float _speed;

    private int _numberNextPoint = 0;

    private Transform _nextPoint;

    public void Update()
    {
        _nextPoint = _points[_numberNextPoint];
        transform.position = Vector3.MoveTowards(transform.position, _nextPoint.position, _speed * Time.deltaTime);

        if ((transform.position - _nextPoint.position).sqrMagnitude < MinDistant)
        {
            _numberNextPoint = ++_numberNextPoint % _points.Length;
            transform.forward = _points[_numberNextPoint].transform.position - transform.position;
        }
    }
}
