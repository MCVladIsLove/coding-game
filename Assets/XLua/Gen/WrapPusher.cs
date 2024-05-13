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


namespace XLua
{
    public static partial class ObjectTranslator_Gen
    {
		public static void Init(LuaEnv luaenv, ObjectTranslator translator)
		{
		
			translator.RegisterPushAndGetAndUpdate<UnityEngine.Vector2>(translator.PushUnityEngineVector2, translator.GetUnityEngineVector2, translator.UpdateUnityEngineVector2);
			translator.RegisterPushAndGetAndUpdate<UnityEngine.Vector3>(translator.PushUnityEngineVector3, translator.GetUnityEngineVector3, translator.UpdateUnityEngineVector3);
			translator.RegisterPushAndGetAndUpdate<UnityEngine.Vector4>(translator.PushUnityEngineVector4, translator.GetUnityEngineVector4, translator.UpdateUnityEngineVector4);
			translator.RegisterPushAndGetAndUpdate<UnityEngine.Color>(translator.PushUnityEngineColor, translator.GetUnityEngineColor, translator.UpdateUnityEngineColor);
			translator.RegisterPushAndGetAndUpdate<UnityEngine.Quaternion>(translator.PushUnityEngineQuaternion, translator.GetUnityEngineQuaternion, translator.UpdateUnityEngineQuaternion);
			translator.RegisterPushAndGetAndUpdate<UnityEngine.Ray>(translator.PushUnityEngineRay, translator.GetUnityEngineRay, translator.UpdateUnityEngineRay);
			translator.RegisterPushAndGetAndUpdate<UnityEngine.Bounds>(translator.PushUnityEngineBounds, translator.GetUnityEngineBounds, translator.UpdateUnityEngineBounds);
			translator.RegisterPushAndGetAndUpdate<UnityEngine.Ray2D>(translator.PushUnityEngineRay2D, translator.GetUnityEngineRay2D, translator.UpdateUnityEngineRay2D);
			translator.RegisterPushAndGetAndUpdate<Assets.Scripts.LuaAPIs.CheckEnum>(translator.PushAssetsScriptsLuaAPIsCheckEnum, translator.GetAssetsScriptsLuaAPIsCheckEnum, translator.UpdateAssetsScriptsLuaAPIsCheckEnum);
			translator.RegisterPushAndGetAndUpdate<Assets.Scripts.LuaAPIs.CheckEnum2>(translator.PushAssetsScriptsLuaAPIsCheckEnum2, translator.GetAssetsScriptsLuaAPIsCheckEnum2, translator.UpdateAssetsScriptsLuaAPIsCheckEnum2);
			translator.RegisterPushAndGetAndUpdate<Assets.Scripts.LuaAPIs.CheckEnum23>(translator.PushAssetsScriptsLuaAPIsCheckEnum23, translator.GetAssetsScriptsLuaAPIsCheckEnum23, translator.UpdateAssetsScriptsLuaAPIsCheckEnum23);
		
		}
        
        static int UnityEngineVector2_TypeID = -1;
        public static void PushUnityEngineVector2(this ObjectTranslator thiz, RealStatePtr L, UnityEngine.Vector2 val)
        {
            if (UnityEngineVector2_TypeID == -1)
            {
			    bool is_first;
                UnityEngineVector2_TypeID = thiz.getTypeId(L, typeof(UnityEngine.Vector2), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 8, UnityEngineVector2_TypeID);
            if (!CopyByValue_Gen.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Vector2 ,value="+val);
            }
			
        }
		
        public static void GetUnityEngineVector2(this ObjectTranslator thiz, RealStatePtr L, int index, out UnityEngine.Vector2 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector2_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector2");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue_Gen.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Vector2");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue_Gen.UnPack(thiz, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Vector2)thiz.objectCasters.GetCaster(typeof(UnityEngine.Vector2))(L, index, null);
            }
        }
		
        public static void UpdateUnityEngineVector2(this ObjectTranslator thiz, RealStatePtr L, int index, UnityEngine.Vector2 val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector2_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector2");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue_Gen.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Vector2 ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        static int UnityEngineVector3_TypeID = -1;
        public static void PushUnityEngineVector3(this ObjectTranslator thiz, RealStatePtr L, UnityEngine.Vector3 val)
        {
            if (UnityEngineVector3_TypeID == -1)
            {
			    bool is_first;
                UnityEngineVector3_TypeID = thiz.getTypeId(L, typeof(UnityEngine.Vector3), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 12, UnityEngineVector3_TypeID);
            if (!CopyByValue_Gen.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Vector3 ,value="+val);
            }
			
        }
		
        public static void GetUnityEngineVector3(this ObjectTranslator thiz, RealStatePtr L, int index, out UnityEngine.Vector3 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector3_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector3");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue_Gen.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Vector3");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue_Gen.UnPack(thiz, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Vector3)thiz.objectCasters.GetCaster(typeof(UnityEngine.Vector3))(L, index, null);
            }
        }
		
        public static void UpdateUnityEngineVector3(this ObjectTranslator thiz, RealStatePtr L, int index, UnityEngine.Vector3 val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector3_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector3");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue_Gen.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Vector3 ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        static int UnityEngineVector4_TypeID = -1;
        public static void PushUnityEngineVector4(this ObjectTranslator thiz, RealStatePtr L, UnityEngine.Vector4 val)
        {
            if (UnityEngineVector4_TypeID == -1)
            {
			    bool is_first;
                UnityEngineVector4_TypeID = thiz.getTypeId(L, typeof(UnityEngine.Vector4), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineVector4_TypeID);
            if (!CopyByValue_Gen.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Vector4 ,value="+val);
            }
			
        }
		
        public static void GetUnityEngineVector4(this ObjectTranslator thiz, RealStatePtr L, int index, out UnityEngine.Vector4 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector4_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector4");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue_Gen.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Vector4");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue_Gen.UnPack(thiz, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Vector4)thiz.objectCasters.GetCaster(typeof(UnityEngine.Vector4))(L, index, null);
            }
        }
		
        public static void UpdateUnityEngineVector4(this ObjectTranslator thiz, RealStatePtr L, int index, UnityEngine.Vector4 val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector4_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector4");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue_Gen.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Vector4 ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        static int UnityEngineColor_TypeID = -1;
        public static void PushUnityEngineColor(this ObjectTranslator thiz, RealStatePtr L, UnityEngine.Color val)
        {
            if (UnityEngineColor_TypeID == -1)
            {
			    bool is_first;
                UnityEngineColor_TypeID = thiz.getTypeId(L, typeof(UnityEngine.Color), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineColor_TypeID);
            if (!CopyByValue_Gen.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Color ,value="+val);
            }
			
        }
		
        public static void GetUnityEngineColor(this ObjectTranslator thiz, RealStatePtr L, int index, out UnityEngine.Color val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineColor_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Color");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue_Gen.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Color");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue_Gen.UnPack(thiz, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Color)thiz.objectCasters.GetCaster(typeof(UnityEngine.Color))(L, index, null);
            }
        }
		
        public static void UpdateUnityEngineColor(this ObjectTranslator thiz, RealStatePtr L, int index, UnityEngine.Color val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineColor_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Color");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue_Gen.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Color ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        static int UnityEngineQuaternion_TypeID = -1;
        public static void PushUnityEngineQuaternion(this ObjectTranslator thiz, RealStatePtr L, UnityEngine.Quaternion val)
        {
            if (UnityEngineQuaternion_TypeID == -1)
            {
			    bool is_first;
                UnityEngineQuaternion_TypeID = thiz.getTypeId(L, typeof(UnityEngine.Quaternion), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineQuaternion_TypeID);
            if (!CopyByValue_Gen.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Quaternion ,value="+val);
            }
			
        }
		
        public static void GetUnityEngineQuaternion(this ObjectTranslator thiz, RealStatePtr L, int index, out UnityEngine.Quaternion val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineQuaternion_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Quaternion");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue_Gen.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Quaternion");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue_Gen.UnPack(thiz, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Quaternion)thiz.objectCasters.GetCaster(typeof(UnityEngine.Quaternion))(L, index, null);
            }
        }
		
        public static void UpdateUnityEngineQuaternion(this ObjectTranslator thiz, RealStatePtr L, int index, UnityEngine.Quaternion val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineQuaternion_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Quaternion");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue_Gen.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Quaternion ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        static int UnityEngineRay_TypeID = -1;
        public static void PushUnityEngineRay(this ObjectTranslator thiz, RealStatePtr L, UnityEngine.Ray val)
        {
            if (UnityEngineRay_TypeID == -1)
            {
			    bool is_first;
                UnityEngineRay_TypeID = thiz.getTypeId(L, typeof(UnityEngine.Ray), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 24, UnityEngineRay_TypeID);
            if (!CopyByValue_Gen.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Ray ,value="+val);
            }
			
        }
		
        public static void GetUnityEngineRay(this ObjectTranslator thiz, RealStatePtr L, int index, out UnityEngine.Ray val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue_Gen.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Ray");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue_Gen.UnPack(thiz, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Ray)thiz.objectCasters.GetCaster(typeof(UnityEngine.Ray))(L, index, null);
            }
        }
		
        public static void UpdateUnityEngineRay(this ObjectTranslator thiz, RealStatePtr L, int index, UnityEngine.Ray val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue_Gen.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Ray ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        static int UnityEngineBounds_TypeID = -1;
        public static void PushUnityEngineBounds(this ObjectTranslator thiz, RealStatePtr L, UnityEngine.Bounds val)
        {
            if (UnityEngineBounds_TypeID == -1)
            {
			    bool is_first;
                UnityEngineBounds_TypeID = thiz.getTypeId(L, typeof(UnityEngine.Bounds), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 24, UnityEngineBounds_TypeID);
            if (!CopyByValue_Gen.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Bounds ,value="+val);
            }
			
        }
		
        public static void GetUnityEngineBounds(this ObjectTranslator thiz, RealStatePtr L, int index, out UnityEngine.Bounds val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineBounds_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Bounds");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue_Gen.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Bounds");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue_Gen.UnPack(thiz, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Bounds)thiz.objectCasters.GetCaster(typeof(UnityEngine.Bounds))(L, index, null);
            }
        }
		
        public static void UpdateUnityEngineBounds(this ObjectTranslator thiz, RealStatePtr L, int index, UnityEngine.Bounds val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineBounds_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Bounds");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue_Gen.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Bounds ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        static int UnityEngineRay2D_TypeID = -1;
        public static void PushUnityEngineRay2D(this ObjectTranslator thiz, RealStatePtr L, UnityEngine.Ray2D val)
        {
            if (UnityEngineRay2D_TypeID == -1)
            {
			    bool is_first;
                UnityEngineRay2D_TypeID = thiz.getTypeId(L, typeof(UnityEngine.Ray2D), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineRay2D_TypeID);
            if (!CopyByValue_Gen.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Ray2D ,value="+val);
            }
			
        }
		
        public static void GetUnityEngineRay2D(this ObjectTranslator thiz, RealStatePtr L, int index, out UnityEngine.Ray2D val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay2D_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray2D");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue_Gen.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Ray2D");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue_Gen.UnPack(thiz, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Ray2D)thiz.objectCasters.GetCaster(typeof(UnityEngine.Ray2D))(L, index, null);
            }
        }
		
        public static void UpdateUnityEngineRay2D(this ObjectTranslator thiz, RealStatePtr L, int index, UnityEngine.Ray2D val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay2D_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray2D");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue_Gen.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Ray2D ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        static int AssetsScriptsLuaAPIsCheckEnum_TypeID = -1;
		static int AssetsScriptsLuaAPIsCheckEnum_EnumRef = -1;
        
        public static void PushAssetsScriptsLuaAPIsCheckEnum(this ObjectTranslator thiz, RealStatePtr L, Assets.Scripts.LuaAPIs.CheckEnum val)
        {
            if (AssetsScriptsLuaAPIsCheckEnum_TypeID == -1)
            {
			    bool is_first;
                AssetsScriptsLuaAPIsCheckEnum_TypeID = thiz.getTypeId(L, typeof(Assets.Scripts.LuaAPIs.CheckEnum), out is_first);
				
				if (AssetsScriptsLuaAPIsCheckEnum_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(Assets.Scripts.LuaAPIs.CheckEnum));
				    AssetsScriptsLuaAPIsCheckEnum_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, AssetsScriptsLuaAPIsCheckEnum_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, AssetsScriptsLuaAPIsCheckEnum_TypeID);
            if (!CopyByValue_Gen.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Assets.Scripts.LuaAPIs.CheckEnum ,value="+val);
            }
			
			LuaAPI.lua_getref(L, AssetsScriptsLuaAPIsCheckEnum_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public static void GetAssetsScriptsLuaAPIsCheckEnum(this ObjectTranslator thiz, RealStatePtr L, int index, out Assets.Scripts.LuaAPIs.CheckEnum val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != AssetsScriptsLuaAPIsCheckEnum_TypeID)
				{
				    throw new Exception("invalid userdata for Assets.Scripts.LuaAPIs.CheckEnum");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue_Gen.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Assets.Scripts.LuaAPIs.CheckEnum");
                }
				val = (Assets.Scripts.LuaAPIs.CheckEnum)e;
                
            }
            else
            {
                val = (Assets.Scripts.LuaAPIs.CheckEnum)thiz.objectCasters.GetCaster(typeof(Assets.Scripts.LuaAPIs.CheckEnum))(L, index, null);
            }
        }
		
        public static void UpdateAssetsScriptsLuaAPIsCheckEnum(this ObjectTranslator thiz, RealStatePtr L, int index, Assets.Scripts.LuaAPIs.CheckEnum val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != AssetsScriptsLuaAPIsCheckEnum_TypeID)
				{
				    throw new Exception("invalid userdata for Assets.Scripts.LuaAPIs.CheckEnum");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue_Gen.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Assets.Scripts.LuaAPIs.CheckEnum ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        static int AssetsScriptsLuaAPIsCheckEnum2_TypeID = -1;
		static int AssetsScriptsLuaAPIsCheckEnum2_EnumRef = -1;
        
        public static void PushAssetsScriptsLuaAPIsCheckEnum2(this ObjectTranslator thiz, RealStatePtr L, Assets.Scripts.LuaAPIs.CheckEnum2 val)
        {
            if (AssetsScriptsLuaAPIsCheckEnum2_TypeID == -1)
            {
			    bool is_first;
                AssetsScriptsLuaAPIsCheckEnum2_TypeID = thiz.getTypeId(L, typeof(Assets.Scripts.LuaAPIs.CheckEnum2), out is_first);
				
				if (AssetsScriptsLuaAPIsCheckEnum2_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(Assets.Scripts.LuaAPIs.CheckEnum2));
				    AssetsScriptsLuaAPIsCheckEnum2_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, AssetsScriptsLuaAPIsCheckEnum2_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, AssetsScriptsLuaAPIsCheckEnum2_TypeID);
            if (!CopyByValue_Gen.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Assets.Scripts.LuaAPIs.CheckEnum2 ,value="+val);
            }
			
			LuaAPI.lua_getref(L, AssetsScriptsLuaAPIsCheckEnum2_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public static void GetAssetsScriptsLuaAPIsCheckEnum2(this ObjectTranslator thiz, RealStatePtr L, int index, out Assets.Scripts.LuaAPIs.CheckEnum2 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != AssetsScriptsLuaAPIsCheckEnum2_TypeID)
				{
				    throw new Exception("invalid userdata for Assets.Scripts.LuaAPIs.CheckEnum2");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue_Gen.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Assets.Scripts.LuaAPIs.CheckEnum2");
                }
				val = (Assets.Scripts.LuaAPIs.CheckEnum2)e;
                
            }
            else
            {
                val = (Assets.Scripts.LuaAPIs.CheckEnum2)thiz.objectCasters.GetCaster(typeof(Assets.Scripts.LuaAPIs.CheckEnum2))(L, index, null);
            }
        }
		
        public static void UpdateAssetsScriptsLuaAPIsCheckEnum2(this ObjectTranslator thiz, RealStatePtr L, int index, Assets.Scripts.LuaAPIs.CheckEnum2 val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != AssetsScriptsLuaAPIsCheckEnum2_TypeID)
				{
				    throw new Exception("invalid userdata for Assets.Scripts.LuaAPIs.CheckEnum2");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue_Gen.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Assets.Scripts.LuaAPIs.CheckEnum2 ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        static int AssetsScriptsLuaAPIsCheckEnum23_TypeID = -1;
		static int AssetsScriptsLuaAPIsCheckEnum23_EnumRef = -1;
        
        public static void PushAssetsScriptsLuaAPIsCheckEnum23(this ObjectTranslator thiz, RealStatePtr L, Assets.Scripts.LuaAPIs.CheckEnum23 val)
        {
            if (AssetsScriptsLuaAPIsCheckEnum23_TypeID == -1)
            {
			    bool is_first;
                AssetsScriptsLuaAPIsCheckEnum23_TypeID = thiz.getTypeId(L, typeof(Assets.Scripts.LuaAPIs.CheckEnum23), out is_first);
				
				if (AssetsScriptsLuaAPIsCheckEnum23_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(Assets.Scripts.LuaAPIs.CheckEnum23));
				    AssetsScriptsLuaAPIsCheckEnum23_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, AssetsScriptsLuaAPIsCheckEnum23_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, AssetsScriptsLuaAPIsCheckEnum23_TypeID);
            if (!CopyByValue_Gen.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Assets.Scripts.LuaAPIs.CheckEnum23 ,value="+val);
            }
			
			LuaAPI.lua_getref(L, AssetsScriptsLuaAPIsCheckEnum23_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public static void GetAssetsScriptsLuaAPIsCheckEnum23(this ObjectTranslator thiz, RealStatePtr L, int index, out Assets.Scripts.LuaAPIs.CheckEnum23 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != AssetsScriptsLuaAPIsCheckEnum23_TypeID)
				{
				    throw new Exception("invalid userdata for Assets.Scripts.LuaAPIs.CheckEnum23");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue_Gen.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Assets.Scripts.LuaAPIs.CheckEnum23");
                }
				val = (Assets.Scripts.LuaAPIs.CheckEnum23)e;
                
            }
            else
            {
                val = (Assets.Scripts.LuaAPIs.CheckEnum23)thiz.objectCasters.GetCaster(typeof(Assets.Scripts.LuaAPIs.CheckEnum23))(L, index, null);
            }
        }
		
        public static void UpdateAssetsScriptsLuaAPIsCheckEnum23(this ObjectTranslator thiz, RealStatePtr L, int index, Assets.Scripts.LuaAPIs.CheckEnum23 val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != AssetsScriptsLuaAPIsCheckEnum23_TypeID)
				{
				    throw new Exception("invalid userdata for Assets.Scripts.LuaAPIs.CheckEnum23");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue_Gen.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Assets.Scripts.LuaAPIs.CheckEnum23 ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        
		// table cast optimze
		
        
    }
	
	public partial class StaticLuaCallbacks_Wrap
    {
	    internal static bool __tryArrayGet(Type type, RealStatePtr L, ObjectTranslator translator, object obj, int index)
		{
		
			if (type == typeof(UnityEngine.Vector2[]))
			{
			    UnityEngine.Vector2[] array = obj as UnityEngine.Vector2[];
				translator.PushUnityEngineVector2(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector3[]))
			{
			    UnityEngine.Vector3[] array = obj as UnityEngine.Vector3[];
				translator.PushUnityEngineVector3(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector4[]))
			{
			    UnityEngine.Vector4[] array = obj as UnityEngine.Vector4[];
				translator.PushUnityEngineVector4(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Color[]))
			{
			    UnityEngine.Color[] array = obj as UnityEngine.Color[];
				translator.PushUnityEngineColor(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Quaternion[]))
			{
			    UnityEngine.Quaternion[] array = obj as UnityEngine.Quaternion[];
				translator.PushUnityEngineQuaternion(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray[]))
			{
			    UnityEngine.Ray[] array = obj as UnityEngine.Ray[];
				translator.PushUnityEngineRay(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Bounds[]))
			{
			    UnityEngine.Bounds[] array = obj as UnityEngine.Bounds[];
				translator.PushUnityEngineBounds(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray2D[]))
			{
			    UnityEngine.Ray2D[] array = obj as UnityEngine.Ray2D[];
				translator.PushUnityEngineRay2D(L, array[index]);
				return true;
			}
			else if (type == typeof(Assets.Scripts.LuaAPIs.CheckEnum[]))
			{
			    Assets.Scripts.LuaAPIs.CheckEnum[] array = obj as Assets.Scripts.LuaAPIs.CheckEnum[];
				translator.PushAssetsScriptsLuaAPIsCheckEnum(L, array[index]);
				return true;
			}
			else if (type == typeof(Assets.Scripts.LuaAPIs.CheckEnum2[]))
			{
			    Assets.Scripts.LuaAPIs.CheckEnum2[] array = obj as Assets.Scripts.LuaAPIs.CheckEnum2[];
				translator.PushAssetsScriptsLuaAPIsCheckEnum2(L, array[index]);
				return true;
			}
			else if (type == typeof(Assets.Scripts.LuaAPIs.CheckEnum23[]))
			{
			    Assets.Scripts.LuaAPIs.CheckEnum23[] array = obj as Assets.Scripts.LuaAPIs.CheckEnum23[];
				translator.PushAssetsScriptsLuaAPIsCheckEnum23(L, array[index]);
				return true;
			}
            return false;
		}
		
		internal static bool __tryArraySet(Type type, RealStatePtr L, ObjectTranslator translator, object obj, int array_idx, int obj_idx)
		{
		
			if (type == typeof(UnityEngine.Vector2[]))
			{
			    UnityEngine.Vector2[] array = obj as UnityEngine.Vector2[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector3[]))
			{
			    UnityEngine.Vector3[] array = obj as UnityEngine.Vector3[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector4[]))
			{
			    UnityEngine.Vector4[] array = obj as UnityEngine.Vector4[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Color[]))
			{
			    UnityEngine.Color[] array = obj as UnityEngine.Color[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Quaternion[]))
			{
			    UnityEngine.Quaternion[] array = obj as UnityEngine.Quaternion[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray[]))
			{
			    UnityEngine.Ray[] array = obj as UnityEngine.Ray[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Bounds[]))
			{
			    UnityEngine.Bounds[] array = obj as UnityEngine.Bounds[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray2D[]))
			{
			    UnityEngine.Ray2D[] array = obj as UnityEngine.Ray2D[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Assets.Scripts.LuaAPIs.CheckEnum[]))
			{
			    Assets.Scripts.LuaAPIs.CheckEnum[] array = obj as Assets.Scripts.LuaAPIs.CheckEnum[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Assets.Scripts.LuaAPIs.CheckEnum2[]))
			{
			    Assets.Scripts.LuaAPIs.CheckEnum2[] array = obj as Assets.Scripts.LuaAPIs.CheckEnum2[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Assets.Scripts.LuaAPIs.CheckEnum23[]))
			{
			    Assets.Scripts.LuaAPIs.CheckEnum23[] array = obj as Assets.Scripts.LuaAPIs.CheckEnum23[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
            return false;
		}
	}
}