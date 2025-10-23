using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace UnityEngine.XR.Content.Interaction
{
    /// <summary>
    /// This component makes sure that the attached <c>Interactor</c> always have an interactable selected.
    /// This is accomplished by forcing the <c>Interactor</c> to select a new <c>Interactable Prefab</c> instance whenever
    /// it loses the current selected interactable.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(XRBaseInteractor))]
    public class XRInfiniteInteractable : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Whether infinite spawning is active.")]
        bool m_Active = true;

        [SerializeField]
        [Tooltip("If true then during Awake the Interactor \"Starting Selected Interactable\" will be overriden by an " +
                 "instance of the \"Interactable Prefab\".")]
        bool m_OverrideStartingSelectedInteractable;

        [SerializeField]
        [Tooltip("The Prefab or GameObject to be instantiated and selected.")]
        XRBaseInteractable m_InteractablePrefab;

        XRBaseInteractor m_Interactor;

        /// <summary>
        /// Whether infinite spawning is enabled.
        /// </summary>
        public bool active
        {
            get => m_Active;

            set
            {
                m_Active = value;
                if (enabled && value && !m_Interactor.hasSelection)
                    InstantiateAndSelectInteractable();
            }
        }

        void Awake()
        {
            m_Interactor = GetComponent<XRBaseInteractor>();

            if (m_OverrideStartingSelectedInteractable)
                OverrideStartingSelectedInteractable();
        }

        void OnEnable()
        {
            if (m_InteractablePrefab == null)
            {
                Debug.LogWarning("No interactable prefab set - nothing to spawn!");
                enabled = false;
                return;
            }
            m_Interactor.selectExited.AddListener(OnSelectExited);
        }

        void OnDisable()
        {
            m_Interactor.selectExited.RemoveListener(OnSelectExited);
        }

        void OnSelectExited(SelectExitEventArgs selectExitEventArgs)
        {
            if (selectExitEventArgs.isCanceled || !active)
                return;
            if (selectExitEventArgs.isCanceled)
            // Appliquer une vélocité de 500 dans l'axe "forward" de l'interactor sur l'objet relâché
            // selectExitEventArgs.interactableObject est l'objet qui vient d'être relâché par l'interactor.
            if (selectExitEventArgs.interactableObject is XRBaseInteractable releasedInteractable)
            {
                var rb = releasedInteractable.GetComponent<Rigidbody>();
                if (rb != null && selectExitEventArgs.interactorObject != null)
                {
                    var forward = selectExitEventArgs.interactorObject.transform.forward;
                    rb.velocity = forward * 500f;
                    // Si vous voulez réinitialiser la vitesse angulaire :
                    // rb.angularVelocity = Vector3.zero;
                }
            }

            InstantiateAndSelectInteractable();
        }

        XRBaseInteractable InstantiateInteractable()
        {
            var socketTransform = m_Interactor.transform;
            return Instantiate(m_InteractablePrefab, socketTransform.position, socketTransform.rotation);
        }

        void OverrideStartingSelectedInteractable()
        {
            m_Interactor.startingSelectedInteractable = InstantiateInteractable();
        }

        void InstantiateAndSelectInteractable()
        {
            if (!gameObject.activeInHierarchy || m_Interactor.interactionManager == null)
                return;

            m_Interactor.interactionManager.SelectEnter((IXRSelectInteractor)m_Interactor, InstantiateInteractable());
        }
    }
}
