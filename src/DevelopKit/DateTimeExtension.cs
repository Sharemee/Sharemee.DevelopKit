namespace Sharemee.DevelopKit;

public static class DateTimeExtension
{
    private static readonly DateTime _utc = new(1970, 1, 1);

    /// <summary>
    /// Unix 时间戳
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static long Timestamp(this DateTime dateTime) => (long)(dateTime.ToUniversalTime() - _utc).TotalSeconds;

    /// <summary>
    /// 毫秒级时间戳
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static long TimestampInMs(this DateTime dateTime) => (long)(dateTime.ToUniversalTime() - _utc).TotalMilliseconds;
}
