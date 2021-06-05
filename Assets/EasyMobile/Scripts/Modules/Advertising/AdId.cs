using UnityEngine;
using System.Collections;
using System;
using EasyMobile.Internal;

namespace EasyMobile
{
    /// <summary>
    /// Generic cross-platform identifier for ad resources.
    /// </summary>
    [Serializable]
    public class AdId : CrossPlatformId
    {
        /// <summary>
        /// Gets the ad ID for iOS platform.
        /// </summary>
        /// <value>The ios identifier.</value>
        public override string IosId => Util.AutoTrimId(mIosId);

        /// <summary>
        /// Gets the ad ID for Android platform.
        /// </summary>
        /// <value>The android identifier.</value>
        public override string AndroidId => Util.AutoTrimId(mAndroidId);

        public AdId(string iOSId, string androidId)
            : base(iOSId, androidId)
        {
        }
    }
}