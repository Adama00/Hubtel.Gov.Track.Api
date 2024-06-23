using Hubtel.Gov.Track.Api.Data;
using Hubtel.Gov.Track.Api.Models;
using Hubtel.Gov.Track.Api.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Hubtel.Gov.Track.Api.Service.Provider
{
    public class AthletePgDbService : IAthleteService
    {
        private readonly AthleteDbContext _context;

        public AthletePgDbService(AthleteDbContext context)
        {
            _context = context;
        }
        public  async Task<ApiResponse<AthleteModel>> AddAthlete(AthleteModel athlete)
        {
            try
            {
                if (athlete == null)
                {
                    return new ApiResponse<AthleteModel>
                    {
                        Code = $"{(int)HttpStatusCode.BadRequest}",
                        Message = "Invalid Request!"

                    };
                }
                await Task.CompletedTask;
                _context.Athletes.Add(athlete);
                _context.SaveChanges();
                return new ApiResponse<AthleteModel>
                {
                    Code = $"{(int)HttpStatusCode.Accepted}",
                    Message = "Record Added!",
                    Data = athlete
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<AthleteModel>
                {
                    Code = $"{(int)HttpStatusCode.InternalServerError}",
                    Message = $"Error getting athlete record, {ex.Message}"

                };

            }
        }

        public async Task<ApiResponse<AthleteModel>> GetAthlete(string id)
        {
            var Athlete = _context.Athletes.FirstOrDefault(x => x.Id == int.Parse(id));
            try
            {
                if (Athlete == null)
                {
                    return new ApiResponse<AthleteModel>
                    {
                        Code = $"{(int)HttpStatusCode.NotFound}",
                        Message = "Record Not found!"

                    };
                }
                await Task.CompletedTask;
                return new ApiResponse<AthleteModel>
                {
                    Code = $"{(int)HttpStatusCode.OK}",
                    Message = "Record found!",
                    Data = Athlete
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<AthleteModel>
                {
                    Code = $"{(int)HttpStatusCode.InternalServerError}",
                    Message = $"Error getting athlete record, {ex.Message}"

                };
            }
        }

        //Gets all Athletes
        public async Task<ApiResponse<List<AthleteModel>>> GetAthletes()
        {
            var athletes = _context.Athletes.ToList();
            try
            {
                if (athletes == null)
                {
                    return new ApiResponse<List<AthleteModel>>
                    {

                        Code = $"{(int)HttpStatusCode.NotFound}",
                        Message = "No Records Found!"
                    };
                }

                await Task.CompletedTask;
                return new ApiResponse<List<AthleteModel>>
                {
                    Code = $"{(int)HttpStatusCode.OK}",
                    Message = "Records found!",
                    Data = athletes
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<AthleteModel>>
                {
                    Code = $"{(int)HttpStatusCode.InternalServerError}",
                    Message = $"Error getting athlete record, {ex.Message}"


                };

            }
        }

        //For Deleting Athlete Records
        public async Task<ApiResponse<AthleteModel>> RemoveAthlete(string id)
        {
            var Athlete = _context.Athletes.FirstOrDefault(x => x.Id == int.Parse(id));
            try
            {
                if (Athlete == null)
                {
                    return new ApiResponse<AthleteModel>
                    {
                        Code = $"{(int)HttpStatusCode.NotFound}",
                        Message = "Record Not found!"

                    };

                }
                await Task.CompletedTask;
                _context.Athletes.Remove(Athlete);
                _context.SaveChanges();
                return new ApiResponse<AthleteModel>
                {
                    Code = $"{(int)HttpStatusCode.Accepted}",
                    Message = "Record Deleted",
                    Data = Athlete

                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<AthleteModel>
                {
                    Code = $"{(int)HttpStatusCode.InternalServerError}",
                    Message = $"Error getting snippet record, {ex.Message}"

                };

            }
        }

        public async Task<ApiResponse<AthleteModel>> UpdateAthlete(AthleteModel athlete, string id)
        {
            var Athlete = _context.Athletes.FirstOrDefault(x => x.Id == int.Parse(id));
            try
            {
                if (Athlete == null)
                {
                    return new ApiResponse<AthleteModel>
                    {
                        Code = $"{(int)HttpStatusCode.NotFound}",
                        Message = "Record Not found!"

                    };

                }
                await Task.CompletedTask;
                Athlete.HasMedal = athlete.HasMedal;
                Athlete.Age = athlete.Age;
                Athlete.Country = athlete.Country;
                Athlete.Name = athlete.Name;
                Athlete.Group = athlete.Group;

                _context.Athletes.Update(Athlete);
                _context.SaveChanges();


                return new ApiResponse<AthleteModel>
                {
                    Code = $"{(int)HttpStatusCode.Accepted}",
                    Message = "Record Updated!",
                    Data = Athlete
                };

            }
            catch (Exception ex)
            {
                return new ApiResponse<AthleteModel>
                {
                    Code = $"{(int)HttpStatusCode.InternalServerError}",
                    Message = $"Error getting snippet record, {ex.Message}"

                };

            }

        
    }
    }
}
