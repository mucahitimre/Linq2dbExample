using Linq2db.Web.Api.Models;
using LinqToDB;
using LinqToDB.Data;

namespace Linq2db.Web.Api.Handlers
{
    /// <summary>
    /// The application data connection
    /// </summary>
    /// <seealso cref="DataConnection" />
    public class AppDataConnection : DataConnection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDataConnection"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public AppDataConnection(DataOptions<AppDataConnection> options)
            : base(options.Options)
        {
        }

        /// <summary>
        /// Gets the SMS log documents.
        /// </summary>
        /// <value>
        /// The SMS log documents.
        /// </value>
        public ITable<SmsLogDocument> SmsLogDocuments => this.GetTable<SmsLogDocument>();
    }
}
