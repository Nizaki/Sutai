using System;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile.Internal;

namespace EasyMobile
{
    [Serializable]
    public class TapjoySettings : AdNetworkSettings
    {
        /// <summary>
        /// Enables or disables auto-reconnect coroutine.
        /// </summary>
        public bool EnableAutoReconnect
        {
            get => mAutoReconnect;
            set => mAutoReconnect = value;
        }

        /// <summary>
        /// Gets or sets auto-reconnect coroutine interval.
        /// </summary>
        public float AutoReconnectInterval
        {
            get => mAutoReconnectInterval;
            set => mAutoReconnectInterval = value;
        }

        /// <summary>
        /// Gets or sets the default interstitial ad identifier.
        /// </summary>
        public AdId DefaultInterstitialAdId
        {
            get => mDefaultInterstitialAdId;
            set => mDefaultInterstitialAdId = value;
        }

        /// <summary>
        /// Gets or sets the default rewarded ad identifier.
        /// </summary>
        public AdId DefaultRewardedAdId
        {
            get => mDefaultRewardedAdId;
            set => mDefaultRewardedAdId = value;
        }

        /// <summary>
        /// Gets or sets the list of custom interstitial ad identifiers.
        /// Each identifier is associated with an ad placement.
        /// </summary>
        public Dictionary<AdPlacement, AdId> CustomInterstitialAdIds
        {
            get => mCustomInterstitialAdIds;
            set => mCustomInterstitialAdIds = value as Dictionary_AdPlacement_AdId;
        }

        /// <summary>
        /// Gets or sets the list of custom rewarded ad identifiers.
        /// Each identifier is associated with an ad placement.
        /// </summary>
        public Dictionary<AdPlacement, AdId> CustomRewardedAdIds
        {
            get => mCustomRewardedAdIds;
            set => mCustomRewardedAdIds = value as Dictionary_AdPlacement_AdId;
        }

        [SerializeField] private bool mAutoReconnect = true;
        [SerializeField] [Range(5, 100)] private float mAutoReconnectInterval = 10f;

        [SerializeField] private AdId mDefaultInterstitialAdId;
        [SerializeField] private AdId mDefaultRewardedAdId;
        [SerializeField] private Dictionary_AdPlacement_AdId mCustomInterstitialAdIds;
        [SerializeField] private Dictionary_AdPlacement_AdId mCustomRewardedAdIds;
    }
}