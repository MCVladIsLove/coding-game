namespace Assets.Scripts.LuaIntegration
{
    public interface ICommandReturnResult<ReturnType>
    {
        ReturnType GetResult();
    }
}