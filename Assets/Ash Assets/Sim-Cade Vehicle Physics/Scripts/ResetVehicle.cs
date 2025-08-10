using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ashsvp
{
    public class ResetVehicle : MonoBehaviour
    {
        private Vector3 _startPosition;
        private Quaternion _startRotation;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _startPosition = transform.position;
            _startRotation = transform.rotation;

            _rigidbody = GetComponent<Rigidbody>();
        }
        public void resetVehicle()
        {
            //var pos = transform.position;
            //pos.y += 1;
            //transform.position = pos;
            //transform.rotation = Quaternion.identity;

            transform.position = _startPosition;
            transform.rotation = _startRotation;

            _rigidbody.velocity = Vector3.zero;
        }
        public void Quit()
        {
            Application.Quit();
        }
        public void ResetScene()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                resetVehicle();
            }
        }
    }
}
