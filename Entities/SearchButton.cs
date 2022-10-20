using HettisentialMvc;

namespace SearchButtons
{
    public class SearchButton:AuditableEntity{



        public string SearchKeyWord {get ; set; }
        public int NumberOfSearch {get ; set; }




                    //         public async Task<IActionResult> Index(string searchString)
                    // {
                    //     var movies = from m in _context.Movie
                    //                  select m;

                    //     if (!String.IsNullOrEmpty(searchString))
                    //     {
                    //         movies = movies.Where(s => s.Title!.Contains(searchString));
                    //     }

                    //     return View(await movies.ToListAsync());
                    // }

                //                     [HttpPost]
                // public string Index(string searchString, bool notUsed)
                // {
                //     return "From [HttpPost]Index: filter on " + searchString;
                // }












                        //                 @model IEnumerable<MvcMovie.Models.Movie>

                        // @{
                        //     ViewData["Title"] = "Index";
                        // }

                        // <h1>Index</h1>

                        // <p>
                        //     <a asp-action="Create">Create New</a>
                        // </p>

                        // <form asp-controller="Movies" asp-action="Index" method="get">
                        //     <p>
                        //         Title: <input type="text" name="SearchString" />
                        //         <input type="submit" value="Filter" />
                        //     </p>
                        // </form>
               //<table class="table">
    }
}