using UnityEngine;
using System.Collections;

namespace EasyMobile
{
    [System.Serializable]
    public class GameServicesItem
    {
        public string Name => _name;

        public string IOSId => _iosId;

        public string AndroidId => _androidId;

        public string Id
        {
            get
            {
#if UNITY_IOS
                return _iosId;
#elif UNITY_ANDROID
                return _androidId;
#else
                return null;
#endif
            }
        }

        [SerializeField] private string _name;
        [SerializeField] private string _iosId;
        [SerializeField] private string _androidId;

        public GameServicesItem(string name, string iosId, string androidId)
        {
            _name = name;
            _iosId = iosId;
            _androidId = androidId;
        }
    }

    [System.Serializable]
    public class Leaderboard : GameServicesItem
    {
        public Leaderboard(string name, string iosId, string androidId)
            : base(name, iosId, androidId)
        {
        }
    }

    [System.Serializable]
    public class Achievement : GameServicesItem
    {
        public Achievement(string name, string iosId, string androidId)
            : base(name, iosId, androidId)
        {
        }
    }
}