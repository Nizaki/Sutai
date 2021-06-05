using UnityEngine;
using System;

namespace EasyMobile
{
    public partial class GameServicesSettings
    {
        /// <summary>
        /// Whether the Multiplayer feature is enabled.
        /// </summary>
        /// <value><c>true</c> if Multiplayer is enabled; otherwise, <c>false</c>.</value>
        public bool IsMultiplayerEnabled => mEnableMultiplayer;

        [SerializeField] private bool mEnableMultiplayer = false;
    }
}