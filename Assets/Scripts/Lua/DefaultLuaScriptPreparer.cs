namespace Assets.Scripts.LuaIntegration
{
    public class DefaultLuaScriptPreparer : ILuaScriptPreparer
    {
        public string PrepareScript(string script)
        {
            return "function __scriptAsFunction()\n" + script + "\nend";
        }
    }
}