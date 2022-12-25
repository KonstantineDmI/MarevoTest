using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Objects
{
    public class ObjectsController : MonoBehaviour
    {
        [SerializeField] private ObjectModel objectModel;
        [SerializeField] private ObjectInteraction objectInteraction;
        [SerializeField] private SpreadSheet data;

        private Vector3 _initialPosition;

        private void Start()
        {
            _initialPosition = objectModel.transform.position;
            objectInteraction.Initialize(objectModel.transform);
        }


        public void SetTexture(int id)
        {
            objectModel.renderer.material.SetTexture("_MainTex", data.GetTextureById(id));
        }

        public void SetScale(Vector3 scale)
        {
            objectModel.transform.localScale = scale / 100;
        }

        public void ResetPosition()
        {
            objectModel.transform.position = _initialPosition;
        }
    }
}
