using UnityEngine;
using Zenject;

namespace Character
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float lerpSpeed;
        private Transform _target;
        private Vector3 _offset;
        private Vector3 _targetPos;
        
        [Inject]
        private void SetDependency(Player player)
        {
            _target = player.transform;
        }
        
        private void Start()
        {
            if (_target == null) return;

            _offset = transform.position - _target.position;
        }

        private void Update()
        {
            if (_target == null) return;

            MoveCameraToTargetPosition();
        }

        private void MoveCameraToTargetPosition()
        {
            _targetPos = _target.position + _offset;
            transform.position = Vector3.Lerp(transform.position, _targetPos, lerpSpeed * Time.deltaTime);
        }
    }
}
