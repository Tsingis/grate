using System.Threading.Tasks;
using moo.Configuration;

namespace moo.Migration
{
    public interface IDatabase
    {
        string? ServerName { get; }
        string? DatabaseName { get; set; }
        bool SupportsDdlTransactions { get; }
        Task InitializeConnections(MooConfiguration configuration);
        void OpenConnection();
        void CloseConnection();
        void OpenAdminConnection();
        void CloseAdminConnection();
        void CreateDatabase();
        void RunSupportTasks();
        string GetCurrentVersion();
        string VersionTheDatabase(string newVersion);
        void Rollback();
        void RunSql(string sql, ConnectionType connectionType);
        string GetCurrentHash(string scriptName);
        bool HasRun(string scriptName);
        void InsertScriptRun(string scriptName, string sql, string hash, bool runOnce, object versionId);
        void InsertScriptRunError(string scriptName, string sql, string errorSql, string errorMessage, object versionId);
    }
}