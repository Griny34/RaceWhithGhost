using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RaceWithGhost
{
    public class RecordingPath : MonoBehaviour
    {
        //Записывает точки движения игрока с определенным интервалом времени в список.
        //Список копируется во второй, тем самым обеспечивается многократное перезаписывание траектории движения в каждом заезде.     

        [SerializeField] private float _delayRecording;
        [SerializeField] private GameObject _point;

        private WaitForSeconds _delayCorutyne;
        private Coroutine _coroutine;
        private List<PointPath> _pointsPath = new List<PointPath>();
        private List<PointPath> _pointsPathCopy = new List<PointPath>();

        public bool IsRecording { get; private set; } = true;
        public WaitForSeconds DelayCorutyne => _delayCorutyne;
        public float DelayRecording => _delayRecording;

        private void Awake()
        {
            _delayCorutyne = new WaitForSeconds(_delayRecording);
        }

        public void RestartRecord()
        {
            StopRecording();

            _pointsPathCopy.Clear();

            СopyList(_pointsPath);

            _pointsPath.Clear();

            IsRecording = true;
        }

        public void StopRecording()
        {
            IsRecording = false;
        }

        public List<PointPath> GetRecordPath()
        {
            return _pointsPathCopy;
        }

        public void StartRecord()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(Record());
        }

        private IEnumerator Record()
        {
            while (IsRecording == true)
            {
                _pointsPath.Add(new PointPath(_point.transform.position, _point.transform.rotation));

                yield return _delayCorutyne;
            }
        }

        private void СopyList(List<PointPath> pointPaths)
        {
            foreach (PointPath pointPath in pointPaths)
            {
                _pointsPathCopy.Add(new PointPath(pointPath.Point, pointPath.Rotation));
            }
        }
    }
}