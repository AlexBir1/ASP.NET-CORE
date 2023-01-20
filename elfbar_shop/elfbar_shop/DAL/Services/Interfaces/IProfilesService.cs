using elfbar_shop.Domain.Response;
using elfbar_shop.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace elfbar_shop.DAL.Services.Interfaces
{
    public interface IProfilesService
    {
        public IBaseResponse<ProfilesViewModel> CreateProfile(ProfilesViewModel _profile);
        public IBaseResponse<ProfilesViewModel> DeleteProfile(ProfilesViewModel _profile);
        public IBaseResponse<ProfilesViewModel> EditProfile(ProfilesViewModel _profile);
        public IBaseResponse<IEnumerable<ProfilesViewModel>> GetProfiles();
        public IBaseResponse<ClaimsIdentity> Log_in(LoginViewModel _profile);
    }
}
