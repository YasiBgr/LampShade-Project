using System.Collections.Generic;
using CommentManagement.Application.Contracts.Comment.folder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiseHost.Areas.Administrator.Pages.Comment
{
    public class IndexModel : PageModel
    {
        public CommentSearchModel CommentSearchModel;
        [TempData]
        public string Message { get; set; }


        private readonly ICommentApplication _CommentApplication;
        public List<CommentViewModel> comment { get; set; }
        public IndexModel(ICommentApplication CommentApplication)
        {
            _CommentApplication = CommentApplication;
        }

        public void OnGet(CommentSearchModel command)
        {
            comment = _CommentApplication.Search(command);
        }
        public IActionResult OnPostCancel(long Id)
        {
            var result = _CommentApplication.Delete(Id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;

            return RedirectToPage("./Index");

        }
        public IActionResult OnPostConfirm(long Id)
        {
            var result = _CommentApplication.Confirm(Id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;

            return RedirectToPage("./Index");

        }
    }
}
