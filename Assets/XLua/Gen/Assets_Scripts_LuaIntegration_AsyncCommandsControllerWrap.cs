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
    public class AssetsScriptsLuaIntegrationAsyncCommandsControllerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Assets.Scripts.LuaIntegration.AsyncCommandsController);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RunLoopIteration", _m_RunLoopIteration);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopAsyncExecution", _m_StopAsyncExecution);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RunAsyncCommand", _m_RunAsyncCommand);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AsyncExecutionFailed", _e_AsyncExecutionFailed);
			
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<UnityEngine.MonoBehaviour>(L, 2))
				{
					UnityEngine.MonoBehaviour _coroutineRunner = (UnityEngine.MonoBehaviour)translator.GetObject(L, 2, typeof(UnityEngine.MonoBehaviour));
					
					var gen_ret = new Assets.Scripts.LuaIntegration.AsyncCommandsController(_coroutineRunner);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Assets.Scripts.LuaIntegration.AsyncCommandsController constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RunLoopIteration(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Assets.Scripts.LuaIntegration.AsyncCommandsController gen_to_be_invoked = (Assets.Scripts.LuaIntegration.AsyncCommandsController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action _onFinish = translator.GetDelegate<System.Action>(L, 2);
                    
                    gen_to_be_invoked.RunLoopIteration( _onFinish );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopAsyncExecution(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Assets.Scripts.LuaIntegration.AsyncCommandsController gen_to_be_invoked = (Assets.Scripts.LuaIntegration.AsyncCommandsController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.StopAsyncExecution(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RunAsyncCommand(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Assets.Scripts.LuaIntegration.AsyncCommandsController gen_to_be_invoked = (Assets.Scripts.LuaIntegration.AsyncCommandsController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _executionTime = (float)LuaAPI.lua_tonumber(L, 2);
                    System.Action _onFinish = translator.GetDelegate<System.Action>(L, 3);
                    
                    gen_to_be_invoked.RunAsyncCommand( _executionTime, _onFinish );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_AsyncExecutionFailed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Assets.Scripts.LuaIntegration.AsyncCommandsController gen_to_be_invoked = (Assets.Scripts.LuaIntegration.AsyncCommandsController)translator.FastGetCSObj(L, 1);
                System.Action<XLua.LuaException> gen_delegate = translator.GetDelegate<System.Action<XLua.LuaException>>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.Action<XLua.LuaException>!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.AsyncExecutionFailed += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.AsyncExecutionFailed -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to Assets.Scripts.LuaIntegration.AsyncCommandsController.AsyncExecutionFailed!");
            return 0;
        }
        
		
		
    }
}
