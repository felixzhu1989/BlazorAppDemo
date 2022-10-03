using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;
        //将搜索添加到 ASP.NET Core Razor 页面
        //[BindProperty] 会绑定名称与属性相同的表单值和查询字符串。
        //在 HTTP GET 请求中进行绑定需要 [BindProperty(SupportsGet = true)]。
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        // Genres 使用户能够从列表中选择一种流派。
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }



        public async Task OnGetAsync()
        {
            /* if (_context.Movie != null)
             {
                 Movie = await _context.Movie.ToListAsync();
             }*/

            
            var movies = _context.Movie.Select( m=> m);
            if (!string.IsNullOrEmpty(SearchString))
            {
                //根据搜索字符串进行筛选,Contains 映射到 SQL LIKE，这是不区分大小写的。
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            // Use LINQ to get list of genres. 从数据库中检索所有流派。
            var genreQuery = _context.Movie.OrderBy(m => m.Genre).Select(m => m.Genre);
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            //流派的 SelectList 是通过投影不包含重复值的流派创建的。
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());


            Movie = await movies.ToListAsync();
        }
    }
}
