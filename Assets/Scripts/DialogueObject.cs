using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System.Reflection;


namespace AcDialogue
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue")]
    class DialogueObject : ScriptableObject
    {
        [SerializeField] List<string> callbacks = new List<string>();
        [SerializeField] DialogueInfo[] infos = null;
        Dictionary<string, MethodInfo> callbacksDic = new Dictionary<string, MethodInfo>();
        public DialogueInfo[] Infos => infos;

        public void Init<T>(T obj) where T : new()
        {
            var type = obj.GetType();
            foreach (var callback in callbacks)
            {
                var method = type.GetMethod(callback);
                if (method != null)
                    callbacksDic.Add(callback, method);
            }

        }

        public void Invoke<T>(T target, string methodName, Object[] parameters)
        {
            var method = callbacksDic[methodName];
            method.Invoke(target, parameters);
        }

        public void ParseText<T>(T target, string origin)
        {
            var pattern = @"`(\w+)`";
            var rex = new Regex(pattern);
            var matches = rex.Matches(origin);
            foreach (Match match in matches)
            {
                var groups = match.Groups;
                Invoke<T>(target, groups[1].Value, null);
            }
        }


    }

    [System.Serializable]
    class DialogueInfo
    {
        public string Name;
        public string Content;
    }


}