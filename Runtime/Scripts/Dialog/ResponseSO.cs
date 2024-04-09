
using UnityEngine;

namespace ADVTK
{
    [CreateAssetMenu(fileName = "Response", menuName = "ADVTK/Response")]
    public class ResponseSO : ScriptableObject
    {
        [Multiline]
        public string     response;
        public ActionSO[] actions;
    }
}
