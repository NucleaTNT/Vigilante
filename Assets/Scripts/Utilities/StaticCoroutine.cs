/*
*   Thank you to fellow indie dev CykesDev for this invaluable StaticCoroutine script!
*   https://forum.unity.com/members/cykesdev.1703063/
*/


using System.Collections;
using UnityEngine;
 
namespace Dev.NucleaTNT.Utilities 
{
    public class StaticCoroutine : MonoBehaviour {
        private static StaticCoroutine s_instance;
     
        // OnDestroy is called when the MonoBehaviour will be destroyed.
        // Coroutines are not stopped when a MonoBehaviour is disabled, but only when it is definitely destroyed.
        private void OnDestroy()
        { s_instance.StopAllCoroutines(); }
     
        // OnApplicationQuit is called on all game objects before the application is closed.
        // In the editor it is called when the user stops playmode.
        private void OnApplicationQuit()
        { s_instance.StopAllCoroutines(); }
     
        // Build will attempt to retrieve the class-wide instance, returning it when available.
        // If no instance exists, attempt to find another StaticCoroutine that exists.
        // If no StaticCoroutines are present, create a dedicated StaticCoroutine object.
        private static StaticCoroutine Build() {
            if (s_instance != null)
            { return s_instance; }
     
            s_instance = (StaticCoroutine)FindObjectOfType(typeof(StaticCoroutine));
     
            if (s_instance != null)
            { return s_instance; }
     
            GameObject instanceObject = new GameObject("StaticCoroutine");
            instanceObject.AddComponent<StaticCoroutine>();
            s_instance = instanceObject.GetComponent<StaticCoroutine>();
     
            if (s_instance != null)
            { return s_instance; }
     
            Debug.LogError("Build did not generate a replacement instance. Method Failed!");
     
            return null;
        }
     
        // Overloaded Static Coroutine Methods which use Unity's default Coroutines.
        // Polymorphism applied for best compatibility with the standard engine.
        public static void Start(string methodName)
        { Build().StartCoroutine(methodName); }
        public static void Start(string methodName, object value)
        { Build().StartCoroutine(methodName, value); }
        public static void Start(IEnumerator routine)
        { Build().StartCoroutine(routine); }
    }
}