﻿#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;
using System.Collections.Generic;
using System.Reflection;


namespace XLua.CSObjectWrap
{
    public class XLua_Gen_Initer_Register__
	{
        
        
        static void wrapInit0(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(Assets.Scripts.LuaAPIs.CatAPI), AssetsScriptsLuaAPIsCatAPIWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Assets.Scripts.LuaAPIs.CheckEnum), AssetsScriptsLuaAPIsCheckEnumWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Assets.Scripts.LuaAPIs.CheckEnum2), AssetsScriptsLuaAPIsCheckEnum2Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Assets.Scripts.LuaAPIs.CheckEnum23), AssetsScriptsLuaAPIsCheckEnum23Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Assets.Scripts.LuaIntegration.AsyncCommandsController), AssetsScriptsLuaIntegrationAsyncCommandsControllerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Assets.Scripts.LuaIntegration.LuaAPI), AssetsScriptsLuaIntegrationLuaAPIWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Assets.Scripts.LuaIntegration.LuaCsCommand), AssetsScriptsLuaIntegrationLuaCsCommandWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Assets.Scripts.LuaCommands.SayCommand), AssetsScriptsLuaCommandsSayCommandWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(object), SystemObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Object), UnityEngineObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector2), UnityEngineVector2Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector3), UnityEngineVector3Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector4), UnityEngineVector4Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Quaternion), UnityEngineQuaternionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Color), UnityEngineColorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Ray), UnityEngineRayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Bounds), UnityEngineBoundsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Ray2D), UnityEngineRay2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Time), UnityEngineTimeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GameObject), UnityEngineGameObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Component), UnityEngineComponentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Behaviour), UnityEngineBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Transform), UnityEngineTransformWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Resources), UnityEngineResourcesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.TextAsset), UnityEngineTextAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Keyframe), UnityEngineKeyframeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimationCurve), UnityEngineAnimationCurveWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimationClip), UnityEngineAnimationClipWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MonoBehaviour), UnityEngineMonoBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem), UnityEngineParticleSystemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SkinnedMeshRenderer), UnityEngineSkinnedMeshRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Renderer), UnityEngineRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Light), UnityEngineLightWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Mathf), UnityEngineMathfWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Collections.Generic.List<int>), SystemCollectionsGenericList_1_SystemInt32_Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Debug), UnityEngineDebugWrap.__Register);
        
        
        
        }
        
        public static void Init(LuaEnv luaenv, ObjectTranslator translator)
        {
            
            wrapInit0(luaenv, translator);
            
            
            translator.AddInterfaceBridgeCreator(typeof(System.Collections.IEnumerator), SystemCollectionsIEnumeratorBridge.__Create);
            
        }
	}
}

namespace XLua
{
	internal partial class InternalGlobals_Gen
    {
	    
        private delegate bool TryArrayGet(Type type, RealStatePtr L, ObjectTranslator translator, object obj, int index);
        private delegate bool TryArraySet(Type type, RealStatePtr L, ObjectTranslator translator, object obj, int array_idx, int obj_idx);
	    private static void Init(
            out Dictionary<Type, IEnumerable<MethodInfo>> extensionMethodMap,
            out TryArrayGet genTryArrayGetPtr,
            out TryArraySet genTryArraySetPtr)
		{
            XLua.LuaEnv.AddIniter(XLua.CSObjectWrap.XLua_Gen_Initer_Register__.Init);
            XLua.LuaEnv.AddIniter(XLua.ObjectTranslator_Gen.Init);
		    extensionMethodMap = new Dictionary<Type, IEnumerable<MethodInfo>>()
			{
			    
			};
			
            genTryArrayGetPtr = StaticLuaCallbacks_Wrap.__tryArrayGet;
            genTryArraySetPtr = StaticLuaCallbacks_Wrap.__tryArraySet;
		}
	}
}
