namespace HetBetereGroepje.HealthCheck.View
{
    public static class SessionExtensions
    {
        public static void SetUInt32(this ISession session, string key, uint value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }

        public static uint GetUInt32(this ISession session, string key)
        {
            byte[] data = session.Get(key);
            return data == null ? 0 : BitConverter.ToUInt32(data);
        }
    }
}
