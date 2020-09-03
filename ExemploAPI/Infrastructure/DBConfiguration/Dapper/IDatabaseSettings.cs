namespace Infrastructure.DBConfiguration.Dapper
{
    public interface IDatabaseSettings
    {
        string DefaultConnection { get; set; }
    }
}