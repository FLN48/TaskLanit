using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskLanit.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> m_logger;
        public IndexModel(ILogger<IndexModel> _logger, IEnumerable<ACarShowroom> _CarShowrooms)
        {
            m_logger = _logger;
            
        }
        public void OnGet()
        {

        }
    }
}