namespace LoggingHandler.Infra.FileSystem.Shared;

public class DatePath
{
    public DateTime Date { get; set; }

    public string FilePath { get; set; }

    private DatePath(DateTime date)
    {
        Date = date;

        FilePath = Path.Combine(date.Year.ToString(), date.Month.ToString("D2"), date.Day.ToString("D2"));
    }

    public static DatePath CreateDatePath()
        => new(DateTime.Now);

    public static DatePath CreateDatePath(DateTime date)
        => new(date);

}
