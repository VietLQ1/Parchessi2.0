﻿using System;
using System.Collections.Generic;
using _Scripts.Player.Pawn;
using AxieMixer.Unity;
using Spine.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Game.Player.Axie
{
    /// <summary>
    /// The class was extracted from AxieMixerPlayground.cs
    /// </summary>
    public class AxieLoader : MonoBehaviour
    {
        private static bool initialized;
        Axie2dBuilder Builder => Mixer.Builder;

        private MapPawn _pawn ;
        
        private void Awake()
        {
            if (!initialized)
            {
                initialized = true;
                Mixer.Init();
            }
            
            _pawn = GetComponent<MapPawn>();
            
        }

        private void Start()
        {
            ProcessMixer(_pawn.PawnDescription.PawnID.ToString() , _pawn.PawnDescription.AxieHex, false);
        }


        private int HexStringToInt(string hexString)
        {
            // Remove any leading "0x" if present
            if (hexString.StartsWith("0x"))
            {
                hexString = hexString.Substring(2);
            }

            int result;
            if (int.TryParse(hexString, System.Globalization.NumberStyles.HexNumber, null, out result))
            {
                return result;
            }
            else
            {
                Debug.LogError("Failed to convert hex string to int: " + hexString);
                return 0; // You can choose to handle the error differently if needed.
            }
        }
        
        void ProcessMixer(string axieId, string genesStr, bool isGraphic)
        {
            if (string.IsNullOrEmpty(genesStr))
            {
                Debug.LogError($"[{axieId}] genes not found!!!");
                return;
            }
            float scale = 0.007f;

            var meta = new Dictionary<string, string>();
            //foreach (var accessorySlot in ACCESSORY_SLOTS)
            //{
            //    meta.Add(accessorySlot, $"{accessorySlot}1{System.Char.ConvertFromUtf32((int)('a') + accessoryIdx - 1)}");
            //}
            var builderResult = Builder.BuildSpineFromGene(axieId, genesStr, meta, scale, isGraphic);

            SpawnSkeletonAnimation(builderResult);
            
        }
        
        /// <summary>
        /// This is the method to spawn skeleton animation, use by GameObject
        /// </summary>
        /// <param name="builderResult"></param>
        void SpawnSkeletonAnimation(Axie2dBuilderResult builderResult)
        {
            SkeletonAnimation runtimeSkeletonAnimation = SkeletonAnimation.NewSkeletonAnimationGameObject(builderResult.skeletonDataAsset);
            runtimeSkeletonAnimation.gameObject.layer = LayerMask.NameToLayer("Player");
            runtimeSkeletonAnimation.transform.SetParent(transform, false);
            runtimeSkeletonAnimation.transform.localScale = Vector3.one;

            runtimeSkeletonAnimation.gameObject.AddComponent<AutoBlendAnimController>();
            runtimeSkeletonAnimation.state.SetAnimation(0, "action/idle/normal", true);

            if (builderResult.adultCombo.ContainsKey("body") &&
                builderResult.adultCombo["body"].Contains("mystic") &&
                builderResult.adultCombo.TryGetValue("body-class", out var bodyClass) &&
                builderResult.adultCombo.TryGetValue("body-id", out var bodyId))
            {
                runtimeSkeletonAnimation.gameObject.AddComponent<MysticIdController>().Init(bodyClass, bodyId);
            }
            runtimeSkeletonAnimation.skeleton.FindSlot("shadow").Attachment = null;
        }
        
        

        
    }
}