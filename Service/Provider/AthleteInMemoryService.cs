using Hubtel.Gov.Track.Api.Models;
using Hubtel.Gov.Track.Api.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;


namespace Hubtel.Gov.Track.Api.Service.Provider
{
    public class AthleteInMemoryService : IAthleteService
    {
        private static List<AthleteModel> _Athletes;
        public AthleteInMemoryService()
        {
            _Athletes = new List<AthleteModel>()
            {
                 new AthleteModel()
                 {
                     Id = 1,
                     Name = "Fatima",
                     Group = "A",
                     Age = 23,
                     HasMedal = true,
                     Country = "Pakistan"
                 },
                 new AthleteModel()
                 {
                     Id= 2,
                     Name = "Tristan",
                     Group = "A",
                     Age = 28,
                     HasMedal = false,
                     Country = "Peru"
                 },
                 new AthleteModel()
                 {
                     Id= 3,
                     Name = "Tris",
                     Group = "A",
                     Age = 22,
                     HasMedal = false,
                     Country = "Bolivia"
                 },
            };
        }
        //For Adding Athletes
        public async Task<ApiResponse<AthleteModel>> AddAthlete(AthleteModel athlete)
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
                _Athletes.Add(athlete);

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

        //For getting a specific Athlete
        public async Task<ApiResponse<AthleteModel>> GetAthlete(string id)
        {
            var Athlete = _Athletes.FirstOrDefault(x => x.Id == int.Parse(id));
            try {
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
            catch(Exception ex)
            {
                return new ApiResponse<AthleteModel>
                {
                    Code = $"{(int)HttpStatusCode.InternalServerError}",
                    Message = $"Error getting athlete record, {ex.Message}"

                };
            }
        }

        //For getting all Athletes
        public async Task<ApiResponse<List<AthleteModel>>> GetAthletes()
        {
            try
            {
                if (_Athletes == null)
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
                    Data = _Athletes
                };
            }
            catch( Exception ex )
            {
                return new ApiResponse<List<AthleteModel>>
                {
                    Code = $"{(int)HttpStatusCode.InternalServerError}",
                    Message = $"Error getting athlete record, {ex.Message}"


                };

            }

        }

        //For Deleting an Athlete
        public async Task<ApiResponse<AthleteModel>> RemoveAthlete(string id)
        {
            var Athlete = _Athletes.FirstOrDefault(x => x.Id == int.Parse(id));
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
                _Athletes.Remove(Athlete);
                return new ApiResponse<AthleteModel>
                {
                    Code = $"{(int)HttpStatusCode.Accepted}",
                    Message = "Record Deleted"

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

        //For updating users
        public async Task<ApiResponse<AthleteModel>> UpdateAthlete(AthleteModel athlete, string id)
        {
            var Athlete = _Athletes.FirstOrDefault(x => x.Id == int.Parse(id));
            try { 
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
