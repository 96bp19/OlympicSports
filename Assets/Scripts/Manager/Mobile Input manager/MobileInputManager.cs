using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Binaya.MyInput
{
    public class MobileInputManager : MobileInputBase
    {
        // this delay is used to know if the screen touch is hold or tap
        // touch released before given time pass is considered tap , else it is hold
        [SerializeField] private float screenTouchDelay =0.3f;

        // the swipe inside radius of dead zone will be considered Tap
        [SerializeField] private float swipeStartDeadZone = 10f;

        private float deltaTime;
        private float currentTime;
        private float SwipeDistance;
        private bool ScreenTouched;
        private bool swipeStarted;
        private bool InputEnabled = true;

        private Vector3 InitialTouchPos;
        private Vector3 FinalTouchPos;

        void OnScreenTap()
        {
            ScreenTapListener?.Invoke();
        }

        void OnScreenHold()
        {
            ScreenHoldListener?.Invoke();
        }

        void OnSwipeStarted()
        {
            screenSwipeStartListener?.Invoke();
        }

        void OnSwipeUp()
        {
            SwipeUpListener?.Invoke();
        }

        void OnSwipeDown()
        {
            SwipeDownListener?.Invoke();
        }

        void OnSwipeRight()
        {
            SwipeRightListener?.Invoke();
        }

        void OnSwipeLeft()
        {
            SwipeLeftListener?.Invoke();
        }

        private static MobileInputManager _Instance;
        public static MobileInputManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = FindObjectOfType<MobileInputManager>();
                    if (_Instance == null)
                    {
                        GameObject obj = new GameObject("mobileInputManager");
                        _Instance = obj.AddComponent<MobileInputManager>();
                    }
                }
                return _Instance;
            }
        }

        private void Start()
        {
            Time.timeScale = 1;
            deltaTime = Time.deltaTime;

        }

        void CheckForInputs()
        {
            if (!InputEnabled)
            {
                return;
            }
            if (ScreenTouched == false)
            {
                ScreenTouched = Input.GetMouseButtonDown(0);
                if (ScreenTouched)
                {
                    InitialTouchPos = Input.mousePosition;
                   
                    currentTime = screenTouchDelay;
                }
            }

            if (ScreenTouched == false)
            {
                return;
            }

            CheckForScreenTap();
            CheckForSwipe();
            CheckForScreenHold();

           

        }

        void CheckForScreenTap()
        {
            if (currentTime > 0 && ScreenTouched)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    // it was screen tap
                    ScreenTouched = false;
                    OnScreenTap();

                }
                currentTime -= deltaTime;
            }
        }

        void CheckForScreenHold()
        {
            if (currentTime < 0 && ScreenTouched)
            {
                // it was Screen Hold
                OnScreenHold();
                if (Input.GetMouseButtonUp(0))
                {
                    ScreenTouched = false;

                }
            }
        }

        void CheckForSwipe()
        {
            if (ScreenTouched)
            {
                SwipeDistance = Vector3.Distance(InitialTouchPos, Input.mousePosition);
                if (SwipeDistance > swipeStartDeadZone)
                {
                    swipeStarted = true;
                    currentTime = -1;
                    OnSwipeStarted();
                }

                if (swipeStarted)
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        swipeStarted = false;
                        FinalTouchPos = Input.mousePosition;
                        CalculateSwipeType();
                    }
                }
            }

        }

        void CalculateSwipeType()
        {
            float XDistance = CalculateDistance(InitialTouchPos.x, FinalTouchPos.x);
            float YDistance = CalculateDistance(InitialTouchPos.y, FinalTouchPos.y);

            if (XDistance >= YDistance)
            {
                // horizontal Swipe
                if (InitialTouchPos.x > FinalTouchPos.x)
                {
                    // right swipe
                    OnSwipeRight();
                }
                else
                {
                    // left swipe
                    OnSwipeLeft();
                }
            }
            else
            {
                if (InitialTouchPos.y >FinalTouchPos.y)
                {
                    // up swipe
                    OnSwipeUp();
                }
                else
                {
                    // down swipe
                    OnSwipeDown();
                }
               
            }
        }


        private void Update()
        {
            CheckForInputs();
        }

        float CalculateDistance(float a , float b)
        {
            return Mathf.Abs(a - b);
        }


        public void EnableInput(bool value)
        {
            InputEnabled = value;
            if (value == false)
            {
                currentTime = -1;
                ScreenTouched = false;
            }
        }

         







    }






}


