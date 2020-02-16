using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binaya.MyInput
{
    public class MobileInputBase : MonoBehaviour
    {
        public delegate void OnScreen_Tap();
        public delegate void OnScreen_Hold();
        public delegate void OnScreenSwipe_Start();
        public delegate void OnSwipe_Up();
        public delegate void OnSwipe_Down();
        public delegate void OnSwipe_Right();
        public delegate void OnSwipe_Left();


        public OnScreen_Tap ScreenTapListener;
        public OnScreen_Hold ScreenHoldListener;
        public OnScreenSwipe_Start screenSwipeStartListener;
        public OnSwipe_Up SwipeUpListener;
        public OnSwipe_Down SwipeDownListener;
        public OnSwipe_Right SwipeRightListener;
        public OnSwipe_Left SwipeLeftListener;
    }

}
