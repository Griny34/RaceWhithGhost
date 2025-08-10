using System.Collections;
using UnityEngine;

namespace RaceWithGhost
{
    public class MovementGhost : MonoBehaviour
    {
        [SerializeField] private RecordingPath _recordingPath;

        private Coroutine _coroutine;
        private int _currentIndex = 0;

        //Реализация движения призрака через корутину и вызов через метод StartMove()

        public void StartMove()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(MoveGhost());
        }

        private IEnumerator MoveGhost()
        {
            gameObject.SetActive(true);

            while (_currentIndex < _recordingPath.GetRecordPath().Count - 1)
            {
                PointPath currentPointPath = _recordingPath.GetRecordPath()[_currentIndex];
                PointPath nextPointPath = _recordingPath.GetRecordPath()[_currentIndex + 1];

                transform.position = Vector3.Lerp(currentPointPath.Point, nextPointPath.Point, _recordingPath.DelayRecording);
                transform.rotation = Quaternion.Slerp(currentPointPath.Rotation, currentPointPath.Rotation, _recordingPath.DelayRecording);

                yield return _recordingPath.DelayCorutyne;

                _currentIndex++;
            }

            gameObject.SetActive(false);

            _currentIndex = 0;
        }
    }
}