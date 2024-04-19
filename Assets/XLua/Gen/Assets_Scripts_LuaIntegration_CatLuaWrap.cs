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
    public class AssetsScriptsLuaIntegrationCatLuaWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Assets.Scripts.LuaIntegration.CatLua);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Move", _m_Move);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Say", _m_Say);
			
			
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 4 && translator.Assignable<UnityEngine.MonoBehaviour>(L, 2) && translator.Assignable<Assets.Scripts.LuaIntegration.MoveCommand>(L, 3) && translator.Assignable<Assets.Scripts.LuaIntegration.SayCommand>(L, 4))
				{
					UnityEngine.MonoBehaviour _coroutineRunner = (UnityEngine.MonoBehaviour)translator.GetObject(L, 2, typeof(UnityEngine.MonoBehaviour));
					Assets.Scripts.LuaIntegration.MoveCommand _moveCommand = (Assets.Scripts.LuaIntegration.MoveCommand)translator.GetObject(L, 3, typeof(Assets.Scripts.LuaIntegration.MoveCommand));
					Assets.Scripts.LuaIntegration.SayCommand _sayCommand = (Assets.Scripts.LuaIntegration.SayCommand)translator.GetObject(L, 4, typeof(Assets.Scripts.LuaIntegration.SayCommand));
					
					var gen_ret = new Assets.Scripts.LuaIntegration.CatLua(_coroutineRunner, _moveCommand, _sayCommand);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Assets.Scripts.LuaIntegration.CatLua constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Move(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Assets.Scripts.LuaIntegration.CatLua gen_to_be_invoked = (Assets.Scripts.LuaIntegration.CatLua)translator.FastGetCSObj(L, 1);
            
            
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
            
            return LuaAPI.luaL_error(L, "invalid arguments to Assets.Scripts.LuaIntegration.CatLua.Move!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Say(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Assets.Scripts.LuaIntegration.CatLua gen_to_be_invoked = (Assets.Scripts.LuaIntegration.CatLua)translator.FastGetCSObj(L, 1);
            
            
                
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
        
        
        
        
        
        
		
		
		
		
    }
}
