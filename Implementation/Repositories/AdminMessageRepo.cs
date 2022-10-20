using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HettisentialMvc
{
   // public class AdminMessageRepo : BaseRepo<AdminMeasage> , IAdminMessageRepo

   // {
        // public  AdminMessageRepo (ApplicationContext context) : base (context)
        // {
        //     _context = context;
        // }

        // public async Task<AdminMeasage> GetAdminMessage(int id)
        // {
        //     var GetAdminMessage = await _context.AdminMeasages
        //     .Include(A => A.ApplicationUserAdminMessages )
        //     .SingleOrDefaultAsync(A => A.Id == id );
        //     return GetAdminMessage;
        // }

        // public async Task<IEnumerable<AdminMeasage>> GetAllAdminMessage()
        // {
        //     var GetAllMessage = await _context.AdminMeasages
        //     .Include(A => A.ApplicationUserAdminMessages )
        //     .ToListAsync();
        //     return GetAllMessage;
        // }
   // }
}