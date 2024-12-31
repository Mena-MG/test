using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assmint.Data;
using assmint.Models;
using assmint.Models.viewmodels;

namespace assmint.Controllers
{
    public class TeamMembersController : Controller
    {
        private readonly AppDBContext _context;

        public TeamMembersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: TeamMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeamMember.ToListAsync());
        }

        // GET: TeamMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamMember = await _context.TeamMember
                .FirstOrDefaultAsync(m => m.TeamMemberid == id);

        

            var ListOFTasks = await _context.tasks.Include(x => x.TeamMembers).Include(x => x.Projects).Where(x => x.TeamMembersid == id).ToListAsync();

            ViewModelTeamMamperDetals ss = new ViewModelTeamMamperDetals()
            {
                TeamMembers = teamMember,

                taskes = ListOFTasks


            };





            if (teamMember == null)
            {
                return NotFound();
            }

            return View(ss);
        }

        // GET: TeamMembers/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]

        public async Task<IActionResult> Create( TeamMember teamMember)
        {
            
                _context.Add(teamMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            //return View(teamMember);
        }

        // GET: TeamMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamMember = await _context.TeamMember.FindAsync(id);
            if (teamMember == null)
            {
                return NotFound();
            }
            return View(teamMember);
        }

        
        [HttpPost]

        public async Task<IActionResult> Edit(int id,  TeamMember teamMember)
        {
            if (id != teamMember.TeamMemberid)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(teamMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamMemberExists(teamMember.TeamMemberid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Projects");
            
        }

        // GET: TeamMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamMember = await _context.TeamMember
                .FirstOrDefaultAsync(m => m.TeamMemberid == id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        // POST: TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamMember = await _context.TeamMember.FindAsync(id);


            if (teamMember != null)
            {
                _context.TeamMember.Remove(teamMember);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction( "Index", "Projects");
        }

        private bool TeamMemberExists(int id)
        {
            return _context.TeamMember.Any(e => e.TeamMemberid == id);
        }
    }
}
