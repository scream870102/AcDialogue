using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Scream.UniMO.Collections;

namespace AcDialogue
{
    [CreateAssetMenu(fileName = "Callback", menuName = "ScriptableObjects/CallbackContainer")]
    class CallbackContainer : Container<string, UnityEvent> { }
}

