using UnityEngine;

namespace RaceWithGhost
{
    public class PointPath
    {
        //����� � ������������ ��� ������ ��������� ������ ������

        public Vector3 Point { get; private set; }
        public Quaternion Rotation { get; private set; }

        public PointPath(Vector3 point, Quaternion rotation)
        {
            Point = point;
            Rotation = rotation;
        }
    }
}