// Author  : Don MacSween
// Purpose : shows a usful indicator in editor where the interaction point is
using UnityEngine;

namespace ADVTK
{
    public class InteractionPointGizmo : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 0.3f);
        }
    }
}
