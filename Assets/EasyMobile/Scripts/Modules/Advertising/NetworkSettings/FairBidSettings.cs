using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyMobile
{
    [Serializable]
    public class FairBidSettings : AdNetworkSettings
    {
        /// <summary>
        /// Gets or sets FairBid's publisher identifier.
        /// </summary>
        public string PublisherId
        {
            get => mPublisherId;
            set => mPublisherId = value;
        }

        /// <summary>
        /// Gets or sets the default banner identifier.
        /// </summary>
        public string DefaultBannerId
        {
            get => mDefaultBannerId;
            set => mDefaultBannerId = value;
        }

        /// <summary>
        /// Gets or sets the default interstitial ad identifier.
        /// </summary>
        public string DefaultInterstitialAdId
        {
            get => mDefaultInterstitialAdId;
            set => mDefaultInterstitialAdId = value;
        }

        /// <summary>
        /// Gets or sets the default rewarded ad identifier.
        /// </summary>
        public string DefaultRewardedAdId
        {
            get => mDefaultRewardedAdId;
            set => mDefaultRewardedAdId = value;
        }

        /// <summary>
        /// Gets or sets FairBid's custom banner placements (used for auto ad loading).
        /// </summary>
        public AdPlacement[] CustomBannerPlacements
        {
            get => mCustomBannerPlacements;
            set => mCustomBannerPlacements = value;
        }

        /// <summary>
        /// Gets or sets FairBid's custom interstitial placements (used for auto ad loading).
        /// </summary>
        public AdPlacement[] CustomInterstitialPlacements
        {
            get => mCustomInterstitialPlacements;
            set => mCustomInterstitialPlacements = value;
        }

        /// <summary>
        /// Gets or sets FairBid's custom rewarded ad placements (used for auto ad loading).
        /// </summary>
        public AdPlacement[] CustomRewardedPlacements
        {
            get => mCustomRewardedPlacements;
            set => mCustomRewardedPlacements = value;
        }

        /// <summary>
        /// Enables or disables test suite.
        /// </summary>
        public bool ShowTestSuite
        {
            get => mShowTestSuite;
            set => mShowTestSuite = value;
        }

        [SerializeField] private string mPublisherId;
        [SerializeField] private bool mShowTestSuite;

        [SerializeField] private string mDefaultBannerId;
        [SerializeField] private string mDefaultInterstitialAdId;
        [SerializeField] private string mDefaultRewardedAdId;
        [SerializeField] private AdPlacement[] mCustomBannerPlacements;
        [SerializeField] private AdPlacement[] mCustomInterstitialPlacements;
        [SerializeField] private AdPlacement[] mCustomRewardedPlacements;
    }
}