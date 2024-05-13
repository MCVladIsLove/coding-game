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
    public class AssetsScriptsLuaAPIsCatAPIWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Assets.Scripts.LuaAPIs.CatAPI);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 1, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Move", _m_Move);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Say", _m_Say);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SSSS", _m_SSSS);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "dddd", _m_dddd);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "en", _g_get_en);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "en", _s_set_en);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 4 && translator.Assignable<UnityEngine.MonoBehaviour>(L, 2) && translator.Assignable<Assets.Scripts.LuaCommands.MoveCommand>(L, 3) && translator.Assignable<Assets.Scripts.LuaCommands.SayCommand>(L, 4))
				{
					UnityEngine.MonoBehaviour _coroutineRunner = (UnityEngine.MonoBehaviour)translator.GetObject(L, 2, typeof(UnityEngine.MonoBehaviour));
					Assets.Scripts.LuaCommands.MoveCommand _moveCommand = (Assets.Scripts.LuaCommands.MoveCommand)translator.GetObject(L, 3, typeof(Assets.Scripts.LuaCommands.MoveCommand));
					Assets.Scripts.LuaCommands.SayCommand _sayCommand = (Assets.Scripts.LuaCommands.SayCommand)translator.GetObject(L, 4, typeof(Assets.Scripts.LuaCommands.SayCommand));
					
					var gen_ret = new Assets.Scripts.LuaAPIs.CatAPI(_coroutineRunner, _moveCommand, _sayCommand);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Assets.Scripts.LuaAPIs.CatAPI constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Move(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Assets.Scripts.LuaAPIs.CatAPI gen_to_be_invoked = (Assets.Scripts.LuaAPIs.CatAPI)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<System.Action>(L, 3)) 
                {
                    UnityEngine.Vector3 _moveDirection;translator.Get(L, 2, out _moveDirection);
                    System.Action _notifyFinish = translator.GetDelegate<System.Action>(L, 3);
                    
                    gen_to_be_invoked.Move( _moveDirection, _notifyFinish );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _moveDirection;translator.Get(L, 2, out _moveDirection);
                    
                    gen_to_be_invoked.Move( _moveDirection );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Assets.Scripts.LuaAPIs.CatAPI.Move!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Say(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Assets.Scripts.LuaAPIs.CatAPI gen_to_be_invoked = (Assets.Scripts.LuaAPIs.CatAPI)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _say1 = LuaAPI.lua_tostring(L, 2);
                    string _say2 = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = gen_to_be_invoked.Say( _say1, _say2 );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SSSS(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Assets.Scripts.LuaAPIs.CatAPI gen_to_be_invoked = (Assets.Scripts.LuaAPIs.CatAPI)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Assets.Scripts.LuaAPIs.CheckEnum _d;translator.Get(L, 2, out _d);
                    Assets.Scripts.LuaAPIs.CheckEnum2 _dd;translator.Get(L, 3, out _dd);
                    Assets.Scripts.LuaAPIs.CheckEnum2 _ddd;translator.Get(L, 4, out _ddd);
                    
                    gen_to_be_invoked.SSSS( _d, _dd, _ddd );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_dddd(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Assets.Scripts.LuaAPIs.CatAPI gen_to_be_invoked = (Assets.Scripts.LuaAPIs.CatAPI)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Assets.Scripts.LuaAPIs.CheckEnum _dffas;translator.Get(L, 2, out _dffas);
                    
                    gen_to_be_invoked.dddd( _dffas );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_en(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Assets.Scripts.LuaAPIs.CatAPI gen_to_be_invoked = (Assets.Scripts.LuaAPIs.CatAPI)translator.FastGetCSObj(L, 1);
                translator.PushAssetsScriptsLuaAPIsCheckEnum(L, gen_to_be_invoked.en);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_en(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Assets.Scripts.LuaAPIs.CatAPI gen_to_be_invoked = (Assets.Scripts.LuaAPIs.CatAPI)translator.FastGetCSObj(L, 1);
                Assets.Scripts.LuaAPIs.CheckEnum gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.en = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
