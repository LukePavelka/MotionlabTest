using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motionlab.DB
{
    /// <summary>
    /// This class contains static methods for basic database operations.
    /// </summary>
    public class InterviewTestControl
    {
        public static async Task SaveAsync(InterviewTestDb Request)
        {
            using var db = new DB.InterviewTestContext();
            db.Add(Request);
            await db.SaveChangesAsync();
        }
        public static async Task<IEnumerable<InterviewTestDb>> GetAllAsync()
        {
            using var db = new DB.InterviewTestContext();
            return await db.InterviewTestDb.Include(p => p.FirstRequest).Include(p => p.SecondaryRequest).ToListAsync();
        }
        public static async Task<InterviewTestDb> FindAsync(Guid Id) 
        {
            using var db = new DB.InterviewTestContext();
            var Search = await db.InterviewTestDb.FindAsync(Id);
            return Search;
        }
        public static async Task<bool> DeleteAsync(Guid Id)
        {
            var Obj = await FindAsync(Id);
            if (Obj != null)
            {
                using var db = new DB.InterviewTestContext();
                db.InterviewTestDb.Remove(Obj);
                await db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static async Task DeleteAllAsync() 
        {
            using var db = new DB.InterviewTestContext();
            foreach (var item in await GetAllAsync())
            {
                db.InterviewTestDb.Remove(item);
            }
            await db.SaveChangesAsync();
        }
    }
}
