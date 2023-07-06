using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Azure;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using webapi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SwitchStationsController : ControllerBase
    {
        private readonly ModelContext _context;

        public SwitchStationsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/SwitchStations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SwitchStation>>> GetSwitchStations()
        {
            //string selectTest = "SELECT * FROM C##CAR.SWITCH_STATIONS";
            //string msg = "";
            //DataTable dt = OracleHelper.SelectSql(selectTest, ref msg);
            //return Enumerable.Range(0, dt.Rows.Count).Select(index => new SwitchStation
            //{
            //    SwitchStationId = dt.Rows[index]["Switch_Station_ID"].ToString(),
            //    StationName = dt.Rows[index]["Station_Name"].ToString(),
            //}).ToArray();
            if (_context.Performances == null)
            {
                return NotFound();
            }
            return await _context.SwitchStations.ToListAsync();
        }

        // GET: api/SwitchStations/5
        [HttpGet("{id}")]
        public ActionResult<SwitchStation> GetSwitchStation(string id)
        {
            if (_context.SwitchStations == null)
            {
                return NotFound();
            }
            var switchStation = _context.SwitchStations.Find(id);

            if (switchStation == null)
            {
                return NotFound();
            }

            return switchStation;
        }

        // PUT: api/SwitchStations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutSwitchStation(string id, SwitchStation switchStation)
        {
            if (id != switchStation.SwitchStationId)
            {
                return BadRequest();
            }

            _context.Entry(switchStation).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SwitchStationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SwitchStations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<SwitchStation> PostSwitchStation(SwitchStation switchStation)
        {
            if (_context.SwitchStations == null)
            {
                return Problem("Entity set 'ModelContext.SwitchStations' is null.");
            }
            _context.SwitchStations.Add(switchStation);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SwitchStationExists(switchStation.SwitchStationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSwitchStation", new { id = switchStation.SwitchStationId }, switchStation);
        }

        // DELETE: api/SwitchStations/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSwitchStation(string id)
        {
            if (_context.SwitchStations == null)
            {
                return NotFound();
            }
            var switchStation = _context.SwitchStations.Find(id);
            if (switchStation == null)
            {
                return NotFound();
            }
            _context.SwitchStations.Remove(switchStation);
            _context.SaveChanges();
            return NoContent();
        }
        private bool SwitchStationExists(string id)
        {
            return _context.SwitchStations?.Any(e => e.SwitchStationId == id) ?? false;
        }
    }
 }

