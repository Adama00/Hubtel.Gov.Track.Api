using Hubtel.Gov.Track.Api.Models;
using Hubtel.Gov.Track.Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hubtel.Gov.Track.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly IAthleteService _athleteService;

        public TrackController(IAthleteService athleteService)
        {
            _athleteService = athleteService;            
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
             var yeti = await _athleteService.GetAthletes();

            return StatusCode(int.Parse(yeti.Code), yeti);
            // return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var athlete = await _athleteService.GetAthlete(id);

            return StatusCode(int.Parse(athlete.Code), athlete);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AthleteModel athlete)
        {
            var result =  await _athleteService.AddAthlete(athlete);

            return StatusCode(int.Parse(result.Code), result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] AthleteModel athlete)
        {
            var result = await _athleteService.UpdateAthlete(athlete, id);

            return StatusCode(int.Parse(result.Code), result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _athleteService.RemoveAthlete( id);

            return StatusCode(int.Parse(result.Code), result);
        }
    }
}
