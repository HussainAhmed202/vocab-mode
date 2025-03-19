using System.Collections.Generic;
using System.Linq;
using Convai.Scripts.Runtime.Core;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Events;

namespace Convai.Scripts.Runtime.Features
{
    public class NarrativeDesignTrigger : MonoBehaviour
    {
        public ConvaiNPC convaiNPC;
        [HideInInspector] public int selectedTriggerIndex;
        [HideInInspector] public List<string> availableTriggers = new();
        public UnityEvent onTriggerEvent;

        private NarrativeDesignManager _narrativeDesignManager;

        private void Awake()
        {
            UpdateNarrativeDesignManager();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Entered the OnTriggerEnter method of NarrativeDesignTrigger");
            if (other == null) Debug.Log("No object detected");
            else {
                Debug.Log("Collided with: " + other.name);
                Debug.Log("Tag of collided object: " + other.tag);
            };


            if (other.gameObject.CompareTag("Player")) InvokeSelectedTrigger();
        }

        private void OnValidate()
        {
            UpdateNarrativeDesignManager();
        }

        private void UpdateNarrativeDesignManager()
        {
            if (convaiNPC != null)
            {
                _narrativeDesignManager = convaiNPC.GetComponent<NarrativeDesignManager>();
                if (_narrativeDesignManager != null) UpdateAvailableTriggers();
            }
            else
            {
                availableTriggers.Clear();
                selectedTriggerIndex = -1;
            }
        }

        public void UpdateAvailableTriggers()
        {
            if (_narrativeDesignManager != null)
            {
                availableTriggers = _narrativeDesignManager.triggerDataList.Select(trigger => trigger.triggerName).ToList();
                if (selectedTriggerIndex >= availableTriggers.Count) selectedTriggerIndex = availableTriggers.Count - 1;
            }
        }

        public void InvokeSelectedTrigger()
        {
            if (convaiNPC != null && availableTriggers != null && selectedTriggerIndex >= 0 && selectedTriggerIndex < availableTriggers.Count)
            {
                string selectedTriggerName = availableTriggers[selectedTriggerIndex];
                ConvaiNPCManager.Instance.SetActiveConvaiNPC(convaiNPC, false);
                onTriggerEvent?.Invoke();
                convaiNPC.TriggerEvent(selectedTriggerName);
            }
        }

        public void InvokeSpeech(string message)
        {
            if (convaiNPC != null && !string.IsNullOrEmpty(message))
            {
                ConvaiNPCManager.Instance.SetActiveConvaiNPC(convaiNPC, false);
                onTriggerEvent?.Invoke();
                convaiNPC.TriggerSpeech(message);
            }
        }
    }
}