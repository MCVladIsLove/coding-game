namespace Assets.Scripts.LuaIntegration
{
    public interface ILuaScriptPreparer
    {
        string PrepareScript(string script, LuaAPI injectedObject);
    }
}