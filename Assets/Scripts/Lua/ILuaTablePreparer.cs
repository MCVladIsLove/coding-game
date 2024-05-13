using XLua;

namespace Assets.Scripts.LuaIntegration
{
    public interface ILuaTablePreparer
    {
        void PrepareTable(LuaEnv luaEnv, LuaTable table, LuaAPI injectedObject);
    }
}