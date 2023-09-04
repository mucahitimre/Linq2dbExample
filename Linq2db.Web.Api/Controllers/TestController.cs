using Linq2db.Web.Api.Handlers;
using Linq2db.Web.Api.Models;
using LinqToDB;
using LinqToDB.Data;
using Microsoft.AspNetCore.Mvc;

namespace Linq2db.Web.Api.Controllers
{
    /// <summary>
    /// The test controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly AppDataConnection _connection;
        private readonly ILogger<TestController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestController"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="logger">The logger.</param>
        public TestController(
            AppDataConnection connection,
            ILogger<TestController> logger)
        {
            _connection = connection;
            _logger = logger;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetCount")]
        public async Task<IActionResult> GetCount()
        {
            var query = _connection.SmsLogDocuments;

            var count = await query.CountAsync();

            return Ok(count);
        }

        /// <summary>
        /// Gets the success.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetSuccess")]
        public async Task<IActionResult> GetSuccess()
        {
            var query = _connection.SmsLogDocuments;

            var smsList = await query.Where(w => w.IsSuccess).ToArrayAsync();

            return Ok(smsList);
        }

        /// <summary>
        /// Gets the not success.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetNotSuccess")]
        public async Task<IActionResult> GetNotSuccess()
        {
            var query = _connection.SmsLogDocuments;

            var smsList = await query.Where(w => !w.IsSuccess).ToArrayAsync();

            return Ok(smsList);
        }

        /// <summary>
        /// Seacrhes the body.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <param name="useRequestBodyForSearch">if set to <c>true</c> [use request body for search].</param>
        /// <returns></returns>
        [HttpGet(Name = "SearchBody")]
        public async Task<IActionResult> SeacrhBody(string search = "", bool useRequestBodyForSearch = false)
        {
            var query = _connection.SmsLogDocuments;

            var smsList = await query
                .Where(w => w.Body.Contains(search) && (useRequestBodyForSearch ? w.RequestBody.Contains(search) : true))
                .ToArrayAsync();

            return Ok(smsList);
        }

        [HttpGet(Name = "Insert")]
        public async Task<IActionResult> Insert()
        {
            // one
            await _connection.SmsLogDocuments.InsertAsync(() => new SmsLogDocument()
            {
                DocumentId = Guid.NewGuid().ToString(),
                To = "recipient3@example.com",
                MessageId = "MSG003",
                RequestBody = "Request body 3",
                Body = "Body content 3",
                IsSuccess = true,
                ErrorMessage = null,
                CreatedAtUtc = DateTime.UtcNow,
                Provider = "Provider 3"
            }, default);

            // many
            await _connection.SmsLogDocuments.BulkCopyAsync(new List<SmsLogDocument>()
            {
                new SmsLogDocument
                {
                    DocumentId = Guid.NewGuid().ToString(),
                    To = "recipivent3@example.com",
                    MessageId = "MSG5003",
                    RequestBody = "Request body 3",
                    Body = "Body content 3567",
                    IsSuccess = true,
                    ErrorMessage = null,
                    CreatedAtUtc = DateTime.UtcNow,
                    Provider = "Provider 2"
                },
                new SmsLogDocument
                {
                    DocumentId = Guid.NewGuid().ToString(),
                    To = "recipiehnt3@example.com",
                    MessageId = "MSG7003",
                    RequestBody = "Request body 3",
                    Body = "Body content 36789",
                    IsSuccess = true,
                    ErrorMessage = null,
                    CreatedAtUtc = DateTime.UtcNow,
                    Provider = "Provider 3"
                },
                new SmsLogDocument
                {
                    DocumentId = Guid.NewGuid().ToString(),
                    To = "recipiente3@example.com",
                    MessageId = "MSG0003",
                    RequestBody = "Request body 3234",
                    Body = "",
                    IsSuccess = false,
                    ErrorMessage = "Content is null or empty",
                    CreatedAtUtc = DateTime.UtcNow,
                    Provider = "Provider 3"
                }
            }, default);

            return Ok();
        }
    }
}