using System;
using CustomAvatar.Tracking;
using UnityEngine;

namespace CustomAvatarsLeftHandPatch
{
    public enum ViveButton
    {
        RightMenu = KeyCode.JoystickButton0,
        LeftMenu = KeyCode.JoystickButton2,
        LeftTrackpadPress = KeyCode.JoystickButton8,
        RightTrackpadPress = KeyCode.JoystickButton9,
        LeftTrigger = KeyCode.JoystickButton14,
        RightTrigger = KeyCode.JoystickButton15,
        LeftTrackpadTouch = KeyCode.JoystickButton16,
        RightTrackpadTouch = KeyCode.JoystickButton17,
        LeftGrip = KeyCode.JoystickButton4,
        RightGrip = KeyCode.JoystickButton5,
        Space = KeyCode.Space,
        None = KeyCode.None
    }
    public class BeatSaberUtilitiesPatch
    {
        public static bool Prefix(DeviceUse use, ref Pose pose, MainSettingsModelSO ____mainSettingsModel, IVRPlatformHelper ____vrPlatformHelper, Func<OpenVRHelper, OpenVRHelper.VRControllerManufacturerName> ___kVrControllerManufacturerNameGetter)
        {
            // Beat Saber Custom Avatars Plugin by icoco007
            // https://github.com/nicoco007/BeatSaberCustomAvatars
            // Orginal code
            // https://github.com/nicoco007/BeatSaberCustomAvatars/blob/main/Source/CustomAvatar/Utilities/BeatSaberUtilities.cs
            // LGPL-3.0 license
            // https://github.com/nicoco007/BeatSaberCustomAvatars/blob/main/LICENSE.txt
            if (use != DeviceUse.LeftHand && use != DeviceUse.RightHand) return false;

            Vector3 position = ____mainSettingsModel.controllerPosition;
            Vector3 rotation = ____mainSettingsModel.controllerRotation;

            // Z rotation isn't mirrored by the game for some reason
            //if (use == DeviceUse.LeftHand)
            //{
            //    rotation.z = -rotation.z;
            //}
            var leftGripKey = (KeyCode)ViveButton.LeftGrip;
            var rightGripKey = (KeyCode)ViveButton.RightGrip;
            if (Input.GetKey(leftGripKey) || Input.GetKey(rightGripKey))
            {
                rotation.y += 50;
            }

            if (____vrPlatformHelper is OculusVRHelper)
            {
                rotation += new Vector3(-40f, 0f, 0f);
                position += new Vector3(0f, 0f, 0.055f);
            }
            else if (____vrPlatformHelper is OpenVRHelper openVRHelper)
            {
                if (___kVrControllerManufacturerNameGetter(openVRHelper) == OpenVRHelper.VRControllerManufacturerName.Valve)
                {
                    rotation += new Vector3(-16.3f, 0f, 0f);
                    position += new Vector3(0f, 0.022f, -0.01f);
                }
                else
                {
                    rotation += new Vector3(-4.3f, 0f, 0f);
                    position += new Vector3(0f, -0.008f, 0f);
                }
            }

            // mirror across YZ plane for left hand
            if (use == DeviceUse.LeftHand)
            {
                rotation.y = -rotation.y;
                rotation.z = -rotation.z;

                position.x = -position.x;
            }

            pose.rotation *= Quaternion.Euler(rotation);
            pose.position += pose.rotation * position;
            return false;
        }
    }
}
