using Hubtel.Gov.Track.Api.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Hubtel.Gov.Track.Api.Service.Interface
{
    public interface IAthleteService
    {
        public Task<ApiResponse<List<AthleteModel>>> GetAthletes();
        public Task<ApiResponse<AthleteModel>> GetAthlete(string id);
        public Task<ApiResponse<AthleteModel>> AddAthlete(AthleteModel athlete);
        public Task<ApiResponse<AthleteModel>> UpdateAthlete(AthleteModel athlete, string id);
        public Task<ApiResponse<AthleteModel>> RemoveAthlete(string id);
    }
}
