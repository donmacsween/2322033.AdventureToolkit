// Author  : Don MacSween.
// Purpose : A data store for dialog responses and the actions they will execute
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
