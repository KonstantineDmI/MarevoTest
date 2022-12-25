using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ItemSettings
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] private GameObject windowGameObject;

        public virtual void Open(params object[] args)
        {
            windowGameObject.SetActive(true);
        }

        public virtual void Close()
        {
            windowGameObject.SetActive(false);
        }
    }

}
