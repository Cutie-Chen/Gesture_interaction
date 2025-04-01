using System;
using UnityEngine;
using Oculus.Interaction.Input;
using System.Collections.Generic;
using TMPro;

namespace Oculus.Interaction.PoseDetection
{
    public class DoubleVelocitySequence : MonoBehaviour, IActiveState
    {
        [SerializeField]
        private JointVelocityActiveState forward_dector;
        [SerializeField]
        private JointVelocityActiveState back_dector;

        [SerializeField, Min(0.1f)]
        private float _maxInterval = 0.5f;

        [SerializeField, Min(0)]
        private float _cooldown = 0.2f;
        public TextMeshProUGUI t;

        private enum DetectionState
        {
            WaitingFirst,
            WaitingSecond,
            Cooldown
        }

        private DetectionState _currentState;
        private float _firstDetectionTime;
        private float _lastDetectionTime;
        private bool _activated;
        private bool f_activate=false;

        public bool Active => _activated;

        private void Update()
        {
            UpdateStateMachine();
            CleanState();
        }

        private void UpdateStateMachine()
        {
            switch (_currentState)
            {
                case DetectionState.WaitingFirst:
                    if (forward_dector.Active)
                    {
                        f_activate = true;
                        //t.text = "向前";
                    }
                    if (f_activate &&back_dector.Active)
                    {
                        _firstDetectionTime = Time.time;
                        _currentState = DetectionState.WaitingSecond;
                        f_activate = false;
                        t.text = "第一次击打";
                    }
                    break;

                case DetectionState.WaitingSecond:
                    // 如果超过最大时间间隔，重置状态
                    if (Time.time - _firstDetectionTime > _maxInterval)
                    {
                        ResetState();
                    }
                    else
                    {
                        // 如果满足前向动作并且时间间隔超过0.1秒，激活前向动作
                        if (forward_dector.Active)
                        {
                            f_activate = true;
                            //t.text = "向前";
                        }

                        // 如果前向动作已经激活且检测到后向动作，完成第二次击打
                        if (f_activate && back_dector.Active)
                        {
                            _activated = true;
                            _lastDetectionTime = Time.time;
                            _currentState = DetectionState.Cooldown;
                            t.text = "第二次击打";
                            f_activate = false;
                        }
                    }
                    break;


                case DetectionState.Cooldown:
                    if (Time.time - _lastDetectionTime > _cooldown)
                    {
                        ResetState();
                    }
                    break;
            }
        }

        private void CleanState()
        {
            if (_activated && Time.time - _lastDetectionTime > _cooldown)
            {
                _activated = false;
                f_activate = false;
                t.text = "清除状态";
            }
        }

        private void ResetState()
        {
            _currentState = DetectionState.WaitingFirst;
            _firstDetectionTime = 0;
            _activated = false;
            f_activate = false;
            t.text = "初始状态";
        }

        #region Inject
        public void InjectAllDoubleVelocitySequence(
            JointVelocityActiveState velocityDetector,
            float maxInterval,
            float cooldown)
        {
            InjectVelocityDetector(velocityDetector);
            _maxInterval = maxInterval;
            _cooldown = cooldown;
        }

        public void InjectVelocityDetector(JointVelocityActiveState velocityDetector)
        {
            forward_dector = velocityDetector;
        }
        #endregion
    }
}