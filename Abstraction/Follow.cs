using System;
using System.Collections.Generic;
using GlobalEnums;
using UnityEngine;

namespace Abstraction
{
    public class Follow : MonoBehaviour
    {
        private void Update()
        {
            gameObject.transform.position = HeroController.instance.gameObject.transform.position;
        }
    }
}
