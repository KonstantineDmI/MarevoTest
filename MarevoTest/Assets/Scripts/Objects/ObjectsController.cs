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

        private void Start()
        {
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
    }
}
