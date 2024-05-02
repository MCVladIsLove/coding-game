#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    
    public class AssetsScriptsLuaObjectsCheckEnumWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Assets.Scripts.LuaObjects.CheckEnum), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Assets.Scripts.LuaObjects.CheckEnum), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Assets.Scripts.LuaObjects.CheckEnum), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "A", Assets.Scripts.LuaObjects.CheckEnum.A);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "B", Assets.Scripts.LuaObjects.CheckEnum.B);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "C", Assets.Scripts.LuaObjects.CheckEnum.C);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Assets.Scripts.LuaObjects.CheckEnum), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushAssetsScriptsLuaObjectsCheckEnum(L, (Assets.Scripts.LuaObjects.CheckEnum)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "A"))
                {
                    translator.PushAssetsScriptsLuaObjectsCheckEnum(L, Assets.Scripts.LuaObjects.CheckEnum.A);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "B"))
                {
                    translator.PushAssetsScriptsLuaObjectsCheckEnum(L, Assets.Scripts.LuaObjects.CheckEnum.B);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "C"))
                {
                    translator.PushAssetsScriptsLuaObjectsCheckEnum(L, Assets.Scripts.LuaObjects.CheckEnum.C);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Assets.Scripts.LuaObjects.CheckEnum!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Assets.Scripts.LuaObjects.CheckEnum! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class AssetsScriptsLuaObjectsCheckEnum2Wrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Assets.Scripts.LuaObjects.CheckEnum2), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Assets.Scripts.LuaObjects.CheckEnum2), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Assets.Scripts.LuaObjects.CheckEnum2), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "A", Assets.Scripts.LuaObjects.CheckEnum2.A);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "B", Assets.Scripts.LuaObjects.CheckEnum2.B);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "C", Assets.Scripts.LuaObjects.CheckEnum2.C);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Assets.Scripts.LuaObjects.CheckEnum2), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushAssetsScriptsLuaObjectsCheckEnum2(L, (Assets.Scripts.LuaObjects.CheckEnum2)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "A"))
                {
                    translator.PushAssetsScriptsLuaObjectsCheckEnum2(L, Assets.Scripts.LuaObjects.CheckEnum2.A);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "B"))
                {
                    translator.PushAssetsScriptsLuaObjectsCheckEnum2(L, Assets.Scripts.LuaObjects.CheckEnum2.B);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "C"))
                {
                    translator.PushAssetsScriptsLuaObjectsCheckEnum2(L, Assets.Scripts.LuaObjects.CheckEnum2.C);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Assets.Scripts.LuaObjects.CheckEnum2!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Assets.Scripts.LuaObjects.CheckEnum2! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class AssetsScriptsLuaObjectsCheckEnum23Wrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Assets.Scripts.LuaObjects.CheckEnum23), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Assets.Scripts.LuaObjects.CheckEnum23), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Assets.Scripts.LuaObjects.CheckEnum23), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "A", Assets.Scripts.LuaObjects.CheckEnum23.A);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "B", Assets.Scripts.LuaObjects.CheckEnum23.B);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "C", Assets.Scripts.LuaObjects.CheckEnum23.C);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Assets.Scripts.LuaObjects.CheckEnum23), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushAssetsScriptsLuaObjectsCheckEnum23(L, (Assets.Scripts.LuaObjects.CheckEnum23)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "A"))
                {
                    translator.PushAssetsScriptsLuaObjectsCheckEnum23(L, Assets.Scripts.LuaObjects.CheckEnum23.A);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "B"))
                {
                    translator.PushAssetsScriptsLuaObjectsCheckEnum23(L, Assets.Scripts.LuaObjects.CheckEnum23.B);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "C"))
                {
                    translator.PushAssetsScriptsLuaObjectsCheckEnum23(L, Assets.Scripts.LuaObjects.CheckEnum23.C);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Assets.Scripts.LuaObjects.CheckEnum23!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Assets.Scripts.LuaObjects.CheckEnum23! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
}