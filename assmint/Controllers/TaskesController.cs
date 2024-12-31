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
using Microsoft.CodeAnalysis;

namespace assmint.Controllers
{
    public class TaskesController : Controller
    {
        private readonly AppDBContext _context;

        public TaskesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Taskes
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.tasks.Include(t => t.Projects).Include(t => t.TeamMembers);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Taskes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taske = await _context.tasks
                .Include(t => t.Projects)
                .Include(t => t.TeamMembers)
                .FirstOrDefaultAsync(m => m.Taskeid == id);
            if (taske == null)
            {
                return NotFound();
            }

            return View(taske);
        }

        // GET: Taskes/Create
        public async Task< IActionResult> Create()
        {
            
            var teemmemper = await _context.TeamMember.ToListAsync();
            var proj = await _context.Projects.ToListAsync();



            listeditviewmodel listeditviewmodel = new listeditviewmodel()
            {
                projects = proj,
                TeamMembers = teemmemper,

            };

            return View();
        }

       
       [HttpPost]

        public async Task<IActionResult> create(listeditviewmodel listeditviewmodel)
        {



            Taske ts = new Taske()
            {

                Taskeid = listeditviewmodel.Taskeid,
                Projectsid = listeditviewmodel.Projectsid,
                title = listeditviewmodel.title,
                descrription = listeditviewmodel.descrription,
                statues = listeditviewmodel.statues,
                priority = listeditviewmodel.priority,
                TeamMembersid = listeditviewmodel.TeamMembersid,
                deadlin = listeditviewmodel.deadlin
            };
            _context.Add(ts);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");

            //ViewData["projectsid"] = new selectlist(_context.projects, "projectid", "projectid", taske.projectsid);
            //viewdata["teammembersid"] = new selectlist(_context.teammember, "teammemberid", "teammemberid", taske.teammembersid);
            //return view(taske);
        }

        // GET: Taskes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taske = await _context.tasks.FindAsync(id);
            var teemmemper = await _context.TeamMember.ToListAsync();
            var proj = await _context.Projects.ToListAsync();



            listeditviewmodel listeditviewmodel = new listeditviewmodel()
            {

                TeamMembers = teemmemper,
                projects=proj,
                Taskeid= taske.Taskeid,
                Projectsid = taske.Projectsid,
                title = taske.title,
                descrription = taske.descrription,
                statues = taske.statues,
                priority = taske.priority,
                TeamMembersid = taske.TeamMembersid,
                deadlin = taske.deadlin
            };

           
            if (listeditviewmodel == null)
            {
                return NotFound();
            }
            //ViewData["Projectsid"] =    _context.Projects.ToList();
            //ViewData["TeamMembersid"] =_context.TeamMember.ToList();

            //ViewBag.TeamMembersid = _context.TeamMember.ToList();
            //ViewBag.Projectsid    =    _context.Projects.ToList();

            return View(listeditviewmodel);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(int id, listeditviewmodel listeditviewmodel)
        {
            if (listeditviewmodel == null)
            {
                return NotFound();
            }
            Taske ts = new Taske() {

                Taskeid = listeditviewmodel.Taskeid,
                Projectsid = listeditviewmodel.Projectsid,
             title = listeditviewmodel.title,
             descrription = listeditviewmodel.descrription,
             statues = listeditviewmodel.statues,
             priority = listeditviewmodel.priority,
             TeamMembersid = listeditviewmodel.TeamMembersid,
              deadlin = listeditviewmodel.deadlin

            };
            try
            {
                    _context.tasks.Update(ts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskeExists(ts.Taskeid))
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

        // GET: Taskes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taske = await _context.tasks
                .Include(t => t.Projects)
                .Include(t => t.TeamMembers)
                .FirstOrDefaultAsync(m => m.Taskeid == id);
            if (taske == null)
            {
                return NotFound();
            }

            return View(taske);
        }

        // POST: Taskes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taske = await _context.tasks.FindAsync(id);
            if (taske != null)
            {
                _context.tasks.Remove(taske);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskeExists(int id)
        {
            return _context.tasks.Any(e => e.Taskeid == id);
        }
    }
}
