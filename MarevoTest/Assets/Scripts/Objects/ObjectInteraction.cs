using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class ObjectInteraction : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        private Transform _model;
        public void Initialize(Transform model)
        {
            _model = model;
        }

        private void OnMouseDrag()
        {
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed;

            float rotY = Input.GetAxis("Mouse Y") * rotationSpeed;

            Camera camera = Camera.main;

            Vector3 right = Vector3.Cross(camera.transform.up, _model.position - camera.transform.position);

            Vector3 up = Vector3.Cross(_model.position - camera.transform.position, right);

            _model.rotation = Quaternion.AngleAxis(-rotX, up) * _model.rotation;

            _model.rotation = Quaternion.AngleAxis(rotY, right) * _model.rotation;

        }
    }
}
