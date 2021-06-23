using Microsoft.AspNetCore.Mvc.RazorPages;
using NetCoreSummary.Services;

namespace NetCoreSummary.Pages
{
    public class IndexModel : PageModel
    {
        IScopedService scopedService;
        DisposableServiceSample disposableService;

        public IndexModel(IScopedService scopedService, DisposableServiceSample disposableService)
        {
            this.scopedService = scopedService;
            this.disposableService = disposableService;
        }

        public void OnGet()
        {
            scopedService.Do();
            disposableService.Action();
        }
    }
}
