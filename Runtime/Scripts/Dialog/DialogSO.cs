
using UnityEngine;

namespace ADVTK
{
    [CreateAssetMenu(fileName = "Dialog", menuName = "ADVTK/Dialog")]
    public class DialogSO : ScriptableObject
    {
        public bool         isConditional;
        public string       flagToCheck;
        public DialogSO     conditionalTrueDialog;
        public DialogSO     conditionalFalseDialog;
        [Multiline]
        public string       unconditionalDialog;
        public ResponseSO[] responses;
    }
}